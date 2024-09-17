using BenchmarkDotNet.Attributes;
using Donut.Filters.Execution;
using Donut.Generation.Core.Generator;
using Donut.Generation.Core.Grouping;
using System.Reflection;


namespace Donut.Generation.Performance;

[MemoryDiagnoser]
public class QueryBuilder
{
   // private readonly
   //     PersonFilterExecutor f = new PersonFilterExecutor(new QueryBuilding.Execution.QueryExecutor());
   // private readonly Filters.PersonFilter x = new Filters.PersonFilter()
   // {
   //     OrderByIdAscending = true,
   //     SelectId = true,
   // };

   // [GlobalSetup]
   //public void Set()
   // {

   // }
    public static string Build<T>(T filter)
    {
        var selectList = new List<string>();
        var whereList = new List<string>();
        var orderByList = new List<string>();

        var groupedProperties = FilterPropertiesGrouper.GroupPropertiesByName(typeof(T));
        var selectProperties = groupedProperties.Item1;
        var orderByProperties = groupedProperties.Item2;
        var otherProperties = groupedProperties.Item3;

        PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var dict = FilterPropertiesGrouper.GroupPropertiesBySuffix(otherProperties);

        foreach (var select in selectProperties)
        {
            bool value = (bool)select.GetValue(filter);
            if (value)
            {
                selectList.Add(select.Name);
            }
        }
        foreach (var orderby in orderByProperties)
        {
            bool value = (bool)orderby.GetValue(filter);
            if (value)
            {
                var (propertyName, direction) = FilterExecutionGenerator.ParseOrderByString(orderby.Name);

                orderByList.Add($"[{propertyName}] {FilterExecutionGenerator.RepresentDirection(direction)}");
            }
        }
        foreach (var prefix in dict.Keys)
        {
            dict[prefix].ForEach(p =>
            {
                if (p.GetValue(filter) is not null)
                {
                    whereList.Add($"{FilterExecutionGenerator.Represent(FilterExecutionGenerator.RemoveSuffix(p.Name, prefix), "@" + p.Name, prefix)}");
                }
            });
            Console.WriteLine();
        }


        var selects = "*";
        if (selectList.Count > 0)
        {
            selects = string.Join(", ", selectList.Select(p => "[" + FilterExecutionGenerator.RemovePrefix(p, "Select") + "]"));
        }
        var orderByCluase = "";
        if (orderByList.Count > 0)
        {
            orderByCluase = string.Join(", ", orderByList.Select(p => p));
            orderByCluase = string.Concat(" ORDER BY ", orderByCluase);
        }
        var whereClause = "";
        if (whereList.Count > 0)
        {
            whereClause = string.Join(" AND ", whereList.Select(p => p));
            whereClause = string.Concat(" WHERE ", whereClause);
        }
        return $"""
            SELECT {selects} FROM {FilterExecutionGenerator.RemoveSuffix(typeof(T).Name, "Filter")}{whereClause}{orderByCluase};
            """;
    }

    public class SomeTabelFilter
    {
        public bool SelectId { get; set; }
        public int? IdEquals { get; set; }
        public bool OrderByIdAscending { get; set; }
        public bool OrderByIdDescending { get; set; }
        public string? NameContains { get; set; }
        public string? NameEndsWith { get; set; }

    }

    public string[] supported = [
        "BiggerThanOrEqualDate",
        "BiggerThanDate",
        "LessThanOrEqualDate",
        "LessThanDate",

        "BiggerThanOrEqualNumber",
        "BiggerThanNumber",
        "LessThanOrEqualNumber",
        "LessThanNumber",

        "Contains",
        "StartsWith",
        "EndsWith",

        "Equals",
        "NotEqual"
     ];
    [Benchmark]
    public string ReturnSQLStringDirectly()
    {
        SomeTabelFilter someTabelFilter = new SomeTabelFilter()
        {
            OrderByIdAscending = true,
            SelectId = true,
            IdEquals = 8,
        };
        return "sadkasjkj klj kj lkj jljl kj l j lk jlk j kl ljk  jll kj lk ";

    }

    [Benchmark]
    public string BuildSQL()
    {
        var sql = Build(new SomeTabelFilter()
        {
            OrderByIdAscending = true,
            SelectId = true,
        });
        return sql;
    }

    //[Benchmark]
    //public string SMTH()
    //{
    //    var sql = f.Execute(x);
    //    return "sql";
    //}
}
