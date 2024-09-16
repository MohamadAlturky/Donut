using Donut.Generation.Core.Grouping;
using System.Reflection;
using System.Text;

namespace Donut.Generation.Core.Generator;

public class FilterExecutionGenerator
{
    public static string GenerateFilter(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        StringBuilder selectBuilder = new StringBuilder();
        StringBuilder whereBuilder = new StringBuilder();
        StringBuilder orderByBuilder = new StringBuilder();
        string className = inputType.Name + "Executor";
        string entityName = RemoveFilterSuffix(inputType.Name);
        string namespaceName = "Donut.Filters.Execution";

        classBuilder.AppendLine($"using Donut.Core.Filter;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Enum;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Utils;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Execution;");
        classBuilder.AppendLine($"using Donut.QueryBuilding.Builder;");
        classBuilder.AppendLine($"using Microsoft.Data.SqlClient;");
        classBuilder.AppendLine($"using System.Text;");
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
        classBuilder.AppendLine($"        var whereQueryBuilder = new StringBuilder();");
        classBuilder.AppendLine($"        var selectQueryBuilder = new StringBuilder();");
        classBuilder.AppendLine($"        var orderByQueryBuilder = new StringBuilder();");
        classBuilder.AppendLine($"        var parameters = new List<SqlParameter>();");

        var groupedProperties = FilterPropertiesGrouper.GroupPropertiesByName(inputType);

        var selectProperties = groupedProperties.Item1;
        var orderByProperties = groupedProperties.Item2;
        var otherProperties = groupedProperties.Item3;

        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"        bool isFirstSelect = true;");
        classBuilder.AppendLine($"        if (filter.EagerLoading)");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            selectQueryBuilder.Append(\"*\");");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"        else");
        classBuilder.AppendLine($"        {{");

        foreach (var select in selectProperties)
        {
            classBuilder.AppendLine($"            if (filter.{select.Name})");
            classBuilder.AppendLine($"            {{");
            classBuilder.AppendLine($"                if (isFirstSelect)");
            classBuilder.AppendLine($"                {{");
            classBuilder.AppendLine($"                     selectQueryBuilder.Append({RemovePrefix(select.Name, "Select")});");
            classBuilder.AppendLine($"                }}");
            classBuilder.AppendLine($"                else");
            classBuilder.AppendLine($"                {{");
            classBuilder.AppendLine($"                     selectQueryBuilder.Append(\", \"+{RemovePrefix(select.Name, "Select")});");
            classBuilder.AppendLine($"                     isFirstSelect = false;");
            classBuilder.AppendLine($"                }}");
            classBuilder.AppendLine($"            }}");

            selectBuilder.AppendLine($"    private static readonly string {RemovePrefix(select.Name, "Select")} = \"[{RemovePrefix(select.Name, "Select")}]\";");

        }
        classBuilder.AppendLine($"        }}");

        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"        bool isFirstOrderBy = true;");

        foreach (var orderby in orderByProperties)
        {
            var (propertyName, direction) = ParseOrderByString(orderby.Name);
            classBuilder.AppendLine($"        if (filter.{orderby.Name})");
            classBuilder.AppendLine($"        {{");
            //classBuilder.AppendLine($"             orderByList.Add(new OrderBy()" +
            //    $" {{" +
            //    $" Column = \"{propertyName}\",Direction=OrderDirection.{direction}" +
            //    $" }});");
            classBuilder.AppendLine($"            if (isFirstOrderBy)");
            classBuilder.AppendLine($"            {{");
            classBuilder.AppendLine($"                 orderByQueryBuilder.Append(OrderBy{propertyName}{direction});");
            classBuilder.AppendLine($"                 isFirstOrderBy = false;");
            classBuilder.AppendLine($"            }}");
            classBuilder.AppendLine($"            else");
            classBuilder.AppendLine($"            {{");
            classBuilder.AppendLine($"                 orderByQueryBuilder.Append(\", \"+OrderBy{propertyName}{direction});");
            classBuilder.AppendLine($"            }}");
            classBuilder.AppendLine($"        }}");
            orderByBuilder.AppendLine($"    private static readonly string OrderBy{propertyName}{direction} = \"[{propertyName}] {RepresentDirection(direction)}\";");

        }
        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var dict = FilterPropertiesGrouper.GroupPropertiesBySuffix(otherProperties);
        var parameterIndex = 1;
        classBuilder.AppendLine($"");

        classBuilder.AppendLine($"        bool isFirstWhere = true;");
        foreach (var prefix in dict.Keys)
        {

            Console.WriteLine($"{prefix} Properties:");

            dict[prefix].ForEach(p =>
            {
                string parameterName = $"@p{parameterIndex++}";
                classBuilder.AppendLine($"        if (filter.{p.Name} is not null)");
                classBuilder.AppendLine($"        {{");
                //classBuilder.AppendLine($"             whereList.Add(new Where<object>()" +
                //    $" {{" +
                //    $" Column = \"{RemoveSuffix(p.Name, prefix)}\",Value=filter.{p.Name},Action=Operator.{prefix}" +
                //    $" }});");
                whereBuilder.AppendLine($"    private static readonly string {p.Name} = \"{Represent(RemoveSuffix(p.Name, prefix), parameterName, prefix)}\";");
                classBuilder.AppendLine($"             if(isFirstWhere)");
                classBuilder.AppendLine($"             {{");
                classBuilder.AppendLine($"                  whereQueryBuilder.Append({p.Name});");
                classBuilder.AppendLine($"                  isFirstWhere = false;");
                classBuilder.AppendLine($"             }}");

                classBuilder.AppendLine($"             else");
                classBuilder.AppendLine($"             {{");
                classBuilder.AppendLine($"                  whereQueryBuilder.Append(\" AND \"+{p.Name});");
                classBuilder.AppendLine($"             }}");

                classBuilder.AppendLine($"             parameters.Add(new SqlParameter(\"{parameterName}\", filter.{p.Name}));");
                classBuilder.AppendLine($"        }}");


            });
            Console.WriteLine();
        }
        var lists = $"""
                
               
                // Query Execution
                return _executor.ExecuteQuery<{entityName}>(selectQueryBuilder.ToString(), "{entityName}", whereQueryBuilder.ToString(), parameters, orderByQueryBuilder.ToString(), filter.PaginatedRequest);
        """;

        classBuilder.AppendLine(lists);

        classBuilder.AppendLine($"    }}\n");

        classBuilder.AppendLine(selectBuilder.ToString());
        classBuilder.AppendLine(orderByBuilder.ToString() + "\n");
        classBuilder.AppendLine(whereBuilder.ToString());

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }

    public static string Represent(string column, string parameterName, string action)
    {
        string whereClause;
        switch (action)
        {
            case "Equals":
                whereClause = $"[{column}] = {parameterName}";
                break;
            case "NotEqual":
                whereClause = $"[{column}] <> {parameterName}";
                break;
            case "LessThanNumber":
                whereClause = $"[{column}] < {parameterName}";
                break;
            case "LessThanOrEqualNumber":
                whereClause = $"[{column}] <= {parameterName}";
                break;
            case "BiggerThanNumber":
                whereClause = $"[{column}] > {parameterName}";
                break;
            case "BiggerThanOrEqualNumber":
                whereClause = $"[{column}] >= {parameterName}";
                break;
            case "Contains":
                whereClause = $"[{column}] LIKE '%' + {parameterName} + '%'";
                break;
            case "StartsWith":
                whereClause = $"[{column}] LIKE {parameterName} + '%'";
                break;
            case "EndsWith":
                whereClause = $"[{column}] LIKE '%' + {parameterName}";
                break;
            case "BiggerThanOrEqualDate":
                whereClause = $"[{column}] >= CAST({parameterName} AS DATE)";
                break;
            case "BiggerThanDate":
                whereClause = $"[{column}] > CAST({parameterName} AS DATE)";
                break;
            case "LessThanOrEqualDate":
                whereClause = $"[{column}] <= CAST({parameterName} AS DATE)";
                break;
            case "LessThanDate":
                whereClause = $"[{column}] < CAST({parameterName} AS DATE)";
                break;
            default:
                whereClause = $"{column}, {action}, {parameterName}";
                break;
        }

        return whereClause;
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
    private static string RemovePrefix(string input, string prefix)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(prefix))
        {
            return input;
        }

        if (input.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
        {
            return input.Substring(prefix.Length);
        }

        return input;
    }

    private static string RemoveSuffix(string input, string suffix)
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
    private static (string, string) ParseOrderByString(string input)
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

        return (propertyName, direction);
    }
    public static string RepresentDirection(string direction)
    {
        if (direction == "Ascending")
        {
            return "ASC";
        }
        else
        {
            return "DESC";
        }
    }
}
