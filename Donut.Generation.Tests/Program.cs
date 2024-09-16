using Donut.Core.Filter;
using Donut.Core.Tabels;
using Donut.Generation.Core.Files;
using Donut.Generation.Core.Generator;
using Donut.Generation.Core.Scanner;

var types = TypeScanner.Read(typeof(Person).Assembly, typeof(ITabel));

while (true)
{
    var key = Console.ReadLine();
    if (key == "0")
    {
        foreach (var type in types)
        {
            var content = "";
            FileWriter fileWriter = new();
            string projectDirectory = "C:\\Users\\hp\\source\\repos\\Donut\\Donut.Generation.Tests";

            content = RepositoryGenerator.GenerateRepository(type);
            fileWriter = new();
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Repository.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Repository.cs");

            content = FilterGenerator.GenerateFilter(type);
            fileWriter = new();
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Filter.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Filter.cs");

            content = CQRSGenerator.GenerateAddCommand(type, "Add");
            fileWriter.CreateFolder($"{projectDirectory}/{type.Name}");
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Add{type.Name}.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Add{type.Name}.cs");

            content = CQRSGenerator.GenerateCommand(type, "Update");
            fileWriter = new();
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Update{type.Name}.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Update{type.Name}.cs");

            content = CQRSGenerator.GenerateCommand(type, "Delete");
            fileWriter = new();
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Delete{type.Name}.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Delete{type.Name}.cs");

        }
    }
    if (key == "1")
    {
        types = TypeScanner.Read(typeof(Program).Assembly, typeof(IFilter));

        foreach (var type in types)
        {
            var content = "";
            FileWriter fileWriter = new();
            string projectDirectory = "C:\\Users\\hp\\source\\repos\\Donut\\Donut.Generation.Tests";

            content = FilterExecutionGenerator.GenerateFilter(type);
            fileWriter = new();
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Executor.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Executor.cs");

        }
    }
    if (key == "2")
    {
        foreach (var type in types)
        {
            var content = "";
            FileWriter fileWriter = new();
            string projectDirectory = "C:\\Users\\hp\\source\\repos\\Donut\\Donut.Generation.Tests";

            content = CQRSGenerator.GenerateFilterQuery(type,"Filter");
            fileWriter = new();
            fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}FilterQuery.cs");
            fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}FilterQuery.cs");
        }
    }
    if (key == "3")
    {
        break;
    }
}


//using Donut.Core.Filter;
//using Donut.Core.Pagination;
//using Donut.Generation.Core.Generator;
//using Donut.Generation.Core.Grouping;
//using System.Reflection;
//using System.Text;

//public class PersonFilter : IFilter
//{
//    // For Every Filter
//    public PaginatedRequest PaginatedRequest { get; set; }
//    public bool EagerLoading { get; set; } = true;

//    // Id
//    public bool IdEquals { get; set; }
//    public bool IdNotEqual { get; set; }
//    public bool SelectId { get; set; }
//    public bool OrderByIdAscending { get; set; }
//    public bool OrderByIdDescending { get; set; }
//    public bool IdLessThanNumber { get; set; }
//    public bool IdBiggerThanNumber { get; set; }
//    public bool IdLessThanOrEqualNumber { get; set; }
//    public bool IdBiggerThanOrEqualNumber { get; set; }


//    // Name
//    public bool NameEquals { get; set; }
//    public bool NameNotEqual { get; set; }
//    public bool SelectName { get; set; }
//    public bool OrderByNameAscending { get; set; }
//    public bool OrderByNameDescending { get; set; }
//    public bool NameContains { get; set; }
//    public bool NameStartsWith { get; set; }
//    public bool NameEndsWith { get; set; }


//    // Age
//    public bool AgeEquals { get; set; }
//    public bool AgeNotEqual { get; set; }
//    public bool SelectAge { get; set; }
//    public bool OrderByAgeAscending { get; set; }
//    public bool OrderByAgeDescending { get; set; }
//    public bool AgeLessThanNumber { get; set; }
//    public bool AgeBiggerThanNumber { get; set; }
//    public bool AgeLessThanOrEqualNumber { get; set; }
//    public bool AgeBiggerThanOrEqualNumber { get; set; }


//    // Wifes
//    public bool WifesEquals { get; set; }
//    public bool WifesNotEqual { get; set; }
//    public bool SelectWifes { get; set; }
//    public bool OrderByWifesAscending { get; set; }
//    public bool OrderByWifesDescending { get; set; }
//    public bool WifesLessThanNumber { get; set; }
//    public bool WifesBiggerThanNumber { get; set; }
//    public bool WifesLessThanOrEqualNumber { get; set; }
//    public bool WifesBiggerThanOrEqualNumber { get; set; }


//    // Char
//    public bool CharEquals { get; set; }
//    public bool CharNotEqual { get; set; }
//    public bool SelectChar { get; set; }
//    public bool OrderByCharAscending { get; set; }
//    public bool OrderByCharDescending { get; set; }


//    // Alive
//    public bool AliveEquals { get; set; }
//    public bool AliveNotEqual { get; set; }
//    public bool SelectAlive { get; set; }
//    public bool OrderByAliveAscending { get; set; }
//    public bool OrderByAliveDescending { get; set; }


//    // Importance
//    public bool ImportanceEquals { get; set; }
//    public bool ImportanceNotEqual { get; set; }
//    public bool SelectImportance { get; set; }
//    public bool OrderByImportanceAscending { get; set; }
//    public bool OrderByImportanceDescending { get; set; }
//    public bool ImportanceLessThanNumber { get; set; }
//    public bool ImportanceBiggerThanNumber { get; set; }
//    public bool ImportanceLessThanOrEqualNumber { get; set; }
//    public bool ImportanceBiggerThanOrEqualNumber { get; set; }


//    // NonImportance
//    public bool NonImportanceEquals { get; set; }
//    public bool NonImportanceNotEqual { get; set; }
//    public bool SelectNonImportance { get; set; }
//    public bool OrderByNonImportanceAscending { get; set; }
//    public bool OrderByNonImportanceDescending { get; set; }
//    public bool NonImportanceLessThanNumber { get; set; }
//    public bool NonImportanceBiggerThanNumber { get; set; }
//    public bool NonImportanceLessThanOrEqualNumber { get; set; }
//    public bool NonImportanceBiggerThanOrEqualNumber { get; set; }


//    // Year
//    public bool YearEquals { get; set; }
//    public bool YearNotEqual { get; set; }
//    public bool SelectYear { get; set; }
//    public bool OrderByYearAscending { get; set; }
//    public bool OrderByYearDescending { get; set; }
//    public bool YearLessThanDate { get; set; }
//    public bool YearBiggerThanDate { get; set; }
//    public bool YearLessThanOrEqualDate { get; set; }
//    public bool YearBiggerThanOrEqualDate { get; set; }


//    // DateOfBirth
//    public bool DateOfBirthEquals { get; set; }
//    public bool DateOfBirthNotEqual { get; set; }
//    public bool SelectDateOfBirth { get; set; }
//    public bool OrderByDateOfBirthAscending { get; set; }
//    public bool OrderByDateOfBirthDescending { get; set; }
//    public bool DateOfBirthLessThanDate { get; set; }
//    public bool DateOfBirthBiggerThanDate { get; set; }
//    public bool DateOfBirthLessThanOrEqualDate { get; set; }
//    public bool DateOfBirthBiggerThanOrEqualDate { get; set; }


//}

//public class Program
//{
//    public static string Build<T>(T filter)
//    {
//        var selectList = new List<string>();
//        var whereList = new List<string>();
//        var orderByList = new List<string>();

//        var groupedProperties = FilterPropertiesGrouper.GroupPropertiesByName(typeof(T));
//        var selectProperties = groupedProperties.Item1;
//        var orderByProperties = groupedProperties.Item2;
//        var otherProperties = groupedProperties.Item3;

//        PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

//        var dict = FilterPropertiesGrouper.GroupPropertiesBySuffix(otherProperties);

//        foreach (var select in selectProperties)
//        {
//            bool value = (bool)select.GetValue(filter);
//            if (value)
//            {
//                selectList.Add(select.Name);
//            }
//        }
//        foreach (var orderby in orderByProperties)
//        {
//            bool value = (bool)orderby.GetValue(filter);
//            if (value)
//            {
//                var (propertyName, direction) = FilterExecutionGenerator.ParseOrderByString(orderby.Name);

//                orderByList.Add($"[{ propertyName}] { FilterExecutionGenerator.RepresentDirection(direction)}");
//            }
//        }
//        foreach (var prefix in dict.Keys)
//        {
//            dict[prefix].ForEach(p =>
//            {
//                if (p.GetValue(filter) is not null)
//                {
//                    whereList.Add($"{FilterExecutionGenerator.Represent(FilterExecutionGenerator.RemoveSuffix(p.Name, prefix), "@"+ p.Name, prefix)}");
//                }
//            });
//            Console.WriteLine();
//        }


//        var selects = "*";
//        if (selectList.Count > 0)
//        {
//            selects = string.Join(", ", selectList.Select(p => "["+FilterExecutionGenerator.RemovePrefix(p,"Select")+"]"));
//        }
//        var orderByCluase = "";
//        if (orderByList.Count > 0)
//        {
//            orderByCluase = string.Join(", ", orderByList.Select(p => p));
//            orderByCluase = string.Concat(" ORDER BY ", orderByCluase);
//        }
//        var whereClause = "";
//        if(whereList.Count > 0)
//        {
//            whereClause = string.Join(" AND ", whereList.Select(p => p));
//            whereClause = string.Concat(" WHERE ", whereClause);
//        }
//        return $"""
//            SELECT {selects} FROM {FilterExecutionGenerator.RemoveSuffix(typeof(T).Name,"Filter")}{whereClause}{orderByCluase};
//            """;
//    }

//    public static void Main()
//    {
//        //var sql = Build(new PersonFilter()
//        //{
//        //    SelectAge = true,
//        //    SelectAlive = true,
//        //    OrderByAgeAscending = true,
//        //});
//        //Console.WriteLine(sql);
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //sql = Build(new PersonFilter()
//        //{
//        //});
//        //Console.WriteLine(sql);
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //sql = Build(new PersonFilter()
//        //{
//        //    SelectAge = true,
//        //    SelectAlive = true,
//        //    SelectChar = true,
//        //    OrderByAgeAscending = true,
//        //    OrderByCharDescending = true,
//        //    IdEquals = true,
//        //    AgeEquals = true
//        //});
//        //Console.WriteLine(sql);
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //Console.WriteLine();
//        //Console.WriteLine();
//        var sql = Build(new SomeTabelFilter()
//        {
//            OrderByIdAscending = true,
//            SelectId = true,
//        });
//        Console.WriteLine(sql);

//    }
//    public class SomeTabelFilter
//    {
//        public bool SelectId { get; set; }
//        public int? IdEquals { get; set; }
//        public bool OrderByIdAscending { get; set; }
//        public bool OrderByIdDescending { get; set; }
//        public string? NameContains { get; set; }
//        public string? NameEndsWith { get; set; }

//    }

//    public string[] supported = [
//        "BiggerThanOrEqualDate",
//        "BiggerThanDate",
//        "LessThanOrEqualDate",
//        "LessThanDate",

//        "BiggerThanOrEqualNumber",
//        "BiggerThanNumber",
//        "LessThanOrEqualNumber",
//        "LessThanNumber",

//        "Contains",
//        "StartsWith",
//        "EndsWith",

//        "Equals",
//        "NotEqual"
//     ];
//}


