using Donut.Filters.Execution.Grouping;
using System.Reflection;
using System.Text;

namespace Donut.Filters.Generator;

public class FilterExecutionGenerator
{
    public static string GenerateFilter(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = inputType.Name + "Executor";
        string entityName = RemoveFilterSuffix(inputType.Name);
        string namespaceName = "Donut.Filters.Execution";

        classBuilder.AppendLine($"using Donut.Core.Filter;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Enum;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Utils;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Builder;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Execution;");
        classBuilder.AppendLine($"using Donut.Core.Pagination;\n");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}: IFilterExecutor<{entityName},{inputType.Name}>");
        classBuilder.AppendLine("{");
        var privateMembers = """
                private readonly QueryExecutor _executor;

                public PersonFilterExecutor(QueryExecutor executor)
                {
                    _executor=executor;
                }
            """;
        classBuilder.AppendLine(privateMembers);
        classBuilder.AppendLine($"    // For Every Filter");
        classBuilder.AppendLine($"    public PaginatedResponse<{entityName}> Execute({inputType.Name} filter)");
        classBuilder.AppendLine($"    {{\n");
        classBuilder.AppendLine($"        var selectList = new List<Select>();");
        classBuilder.AppendLine($"        var whereList = new List<Where<object>>();");
        classBuilder.AppendLine($"        var orderByList = new List<OrderBy>();");

        var groupedProperties = FilterPropertiesGrouper.GroupPropertiesByName(inputType);

        var selectProperties = groupedProperties.Item1;
        var orderByProperties = groupedProperties.Item2;
        var otherProperties = groupedProperties.Item3;


        foreach(var select in selectProperties)
        {
            classBuilder.AppendLine($"        if (filter.{select.Name})");
            classBuilder.AppendLine($"        {{");
            classBuilder.AppendLine($"             selectList.Add(new Select()" +
                $" {{" +
                $" Column = \"{select.Name}\"" +
                $" }});");
            classBuilder.AppendLine($"        }}");

        }
        foreach (var orderby in orderByProperties)
        {
            var (propertyName, direction) = ParseOrderByString(orderby.Name);
            classBuilder.AppendLine($"        if (filter.{orderby.Name})");
            classBuilder.AppendLine($"        {{");
            classBuilder.AppendLine($"             orderByList.Add(new OrderBy()" +
                $" {{" +
                $" Column = \"{propertyName}\",Direction=OrderDirection.{direction}" +
                $" }});");
            classBuilder.AppendLine($"        }}");


        }
        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var dict = FilterPropertiesGrouper.GroupPropertiesBySuffix(otherProperties);
        foreach (var prefix in dict.Keys)
        {
            Console.WriteLine($"{prefix} Properties:");
            dict[prefix].ForEach(p =>
            {
                classBuilder.AppendLine($"        if (filter.{p.Name} is not null)");
                classBuilder.AppendLine($"        {{");
                classBuilder.AppendLine($"             whereList.Add(new Where<object>()" +
                    $" {{" +
                    $" Column = \"{RemoveSuffix(p.Name, prefix)}\",Value=filter.{p.Name},Action=Operator.{prefix}" +
                    $" }});");
                classBuilder.AppendLine($"        }}");
            });
            Console.WriteLine();
        }
        var lists = $"""
                
                // Query Building 
                var orderByClause = SQLQueryBuilder.BuildOrderByClause(orderByList);
                var (whereClause,parameters) = SQLQueryBuilder.BuildWhereClause(whereList);
                var selectClause = SQLQueryBuilder.BuildSelectClause(selectList);

                // Query Execution
                return _executor.ExecuteQuery<{entityName}>(selectClause, "{entityName}", whereClause, parameters, orderByClause, filter.PaginatedRequest);
        """;

        classBuilder.AppendLine(lists);
        classBuilder.AppendLine($"    }}\n");

        
        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
    private static string RemoveFilterSuffix(string input)
    {
        const string suffix = "Filter";

        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        if (input.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
        {
            return input.Substring(0, input.Length - suffix.Length);
        }

        return input;
    }
    private static string RemoveSuffix(string input,string suffix)
    {

        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        if (input.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
        {
            return input.Substring(0, input.Length - suffix.Length);
        }

        return input;
    }
    private static (string,string) ParseOrderByString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
        }

        const string ascendingPrefix = "OrderBy";
        const string ascendingSuffix = "Ascending";
        const string descendingSuffix = "Descending";

        if (!input.StartsWith(ascendingPrefix))
        {
            throw new ArgumentException($"Input string must start with '{ascendingPrefix}'.", nameof(input));
        }

        string propertyName;
        string direction;

        if (input.EndsWith(ascendingSuffix))
        {
            propertyName = input.Substring(ascendingPrefix.Length, input.Length - ascendingPrefix.Length - ascendingSuffix.Length);
            direction = "Ascending";
        }
        else if (input.EndsWith(descendingSuffix))
        {
            propertyName = input.Substring(ascendingPrefix.Length, input.Length - ascendingPrefix.Length - descendingSuffix.Length);
            direction = "Descending";
        }
        else
        {
            throw new ArgumentException("Input string must end with 'Ascending' or 'Descending'.", nameof(input));
        }

        if (string.IsNullOrEmpty(propertyName))
        {
            throw new ArgumentException("Property name cannot be empty.", nameof(input));
        }

        return (propertyName,direction);
    }
}
