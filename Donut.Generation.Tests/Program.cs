//using Donut.Core.Tabels;
//using Donut.Generation.Core.Files;
//using Donut.Generation.Core.Generator;
//using Donut.Generation.Core.Scanner;

//var types = TypeScanner.Read(typeof(Person).Assembly, typeof(ITabel));

//foreach (var type in types)
//{
//    var content = CQRSGenerator.GenerateAddCommand(type,"Add");
//    FileWriter fileWriter = new();
//    string projectDirectory = "C:\\Users\\hp\\source\\repos\\Donut\\Donut.Generation.Tests";
//    fileWriter.CreateFolder($"{projectDirectory}/{type.Name}");
//    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Add{type.Name}.cs");
//    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Add{type.Name}.cs");

//    content = CQRSGenerator.GenerateCommand(type, "Update");
//    fileWriter = new();
//    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Update{type.Name}.cs");
//    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Update{type.Name}.cs");

//    content = CQRSGenerator.GenerateCommand(type, "Delete");
//    fileWriter = new();
//    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Delete{type.Name}.cs");
//    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Delete{type.Name}.cs");

//    content = CQRSGenerator.GenerateFilterQuery(type, "Filter");
//    fileWriter = new();
//    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Filter{type.Name}.cs");
//    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Filter{type.Name}.cs");

//    content = RepositoryGenerator.GenerateRepository(type);
//    fileWriter = new();
//    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Repository.cs");
//    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Repository.cs");

//    content = FilterGenerator.GenerateFilter(type);
//    fileWriter = new();
//    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Filter.cs");
//    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Filter.cs");

//}



using Donut.Core.Filter;
using Donut.Core.Pagination;
using Donut.Generation.Core.Generator;
using Donut.Generation.Core.Grouping;
using System.Reflection;
using System.Text;

public class PersonFilter : IFilter
{
    // For Every Filter
    public PaginatedRequest PaginatedRequest { get; set; }
    public bool EagerLoading { get; set; } = true;

    // Id
    public int? IdEquals { get; set; }
    public int? IdNotEqual { get; set; }
    public bool SelectId { get; set; }
    public bool OrderByIdAscending { get; set; }
    public bool OrderByIdDescending { get; set; }
    public int? IdLessThanNumber { get; set; }
    public int? IdBiggerThanNumber { get; set; }
    public int? IdLessThanOrEqualNumber { get; set; }
    public int? IdBiggerThanOrEqualNumber { get; set; }


    // Name
    public string? NameEquals { get; set; }
    public string? NameNotEqual { get; set; }
    public bool SelectName { get; set; }
    public bool OrderByNameAscending { get; set; }
    public bool OrderByNameDescending { get; set; }
    public string? NameContains { get; set; }
    public string? NameStartsWith { get; set; }
    public string? NameEndsWith { get; set; }


    // Age
    public int? AgeEquals { get; set; }
    public int? AgeNotEqual { get; set; }
    public bool SelectAge { get; set; }
    public bool OrderByAgeAscending { get; set; }
    public bool OrderByAgeDescending { get; set; }
    public int? AgeLessThanNumber { get; set; }
    public int? AgeBiggerThanNumber { get; set; }
    public int? AgeLessThanOrEqualNumber { get; set; }
    public int? AgeBiggerThanOrEqualNumber { get; set; }


    // Wifes
    public long? WifesEquals { get; set; }
    public long? WifesNotEqual { get; set; }
    public bool SelectWifes { get; set; }
    public bool OrderByWifesAscending { get; set; }
    public bool OrderByWifesDescending { get; set; }
    public long? WifesLessThanNumber { get; set; }
    public long? WifesBiggerThanNumber { get; set; }
    public long? WifesLessThanOrEqualNumber { get; set; }
    public long? WifesBiggerThanOrEqualNumber { get; set; }


    // Char
    public char? CharEquals { get; set; }
    public char? CharNotEqual { get; set; }
    public bool SelectChar { get; set; }
    public bool OrderByCharAscending { get; set; }
    public bool OrderByCharDescending { get; set; }


    // Alive
    public bool? AliveEquals { get; set; }
    public bool? AliveNotEqual { get; set; }
    public bool SelectAlive { get; set; }
    public bool OrderByAliveAscending { get; set; }
    public bool OrderByAliveDescending { get; set; }


    // Importance
    public double? ImportanceEquals { get; set; }
    public double? ImportanceNotEqual { get; set; }
    public bool SelectImportance { get; set; }
    public bool OrderByImportanceAscending { get; set; }
    public bool OrderByImportanceDescending { get; set; }
    public double? ImportanceLessThanNumber { get; set; }
    public double? ImportanceBiggerThanNumber { get; set; }
    public double? ImportanceLessThanOrEqualNumber { get; set; }
    public double? ImportanceBiggerThanOrEqualNumber { get; set; }


    // NonImportance
    public decimal? NonImportanceEquals { get; set; }
    public decimal? NonImportanceNotEqual { get; set; }
    public bool SelectNonImportance { get; set; }
    public bool OrderByNonImportanceAscending { get; set; }
    public bool OrderByNonImportanceDescending { get; set; }
    public decimal? NonImportanceLessThanNumber { get; set; }
    public decimal? NonImportanceBiggerThanNumber { get; set; }
    public decimal? NonImportanceLessThanOrEqualNumber { get; set; }
    public decimal? NonImportanceBiggerThanOrEqualNumber { get; set; }


    // Year
    public DateOnly? YearEquals { get; set; }
    public DateOnly? YearNotEqual { get; set; }
    public bool SelectYear { get; set; }
    public bool OrderByYearAscending { get; set; }
    public bool OrderByYearDescending { get; set; }
    public DateOnly? YearLessThanDate { get; set; }
    public DateOnly? YearBiggerThanDate { get; set; }
    public DateOnly? YearLessThanOrEqualDate { get; set; }
    public DateOnly? YearBiggerThanOrEqualDate { get; set; }


    // DateOfBirth
    public DateTime? DateOfBirthEquals { get; set; }
    public DateTime? DateOfBirthNotEqual { get; set; }
    public bool SelectDateOfBirth { get; set; }
    public bool OrderByDateOfBirthAscending { get; set; }
    public bool OrderByDateOfBirthDescending { get; set; }
    public DateTime? DateOfBirthLessThanDate { get; set; }
    public DateTime? DateOfBirthBiggerThanDate { get; set; }
    public DateTime? DateOfBirthLessThanOrEqualDate { get; set; }
    public DateTime? DateOfBirthBiggerThanOrEqualDate { get; set; }


}

public class Program
{
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

                orderByList.Add($"[{ propertyName}] { FilterExecutionGenerator.RepresentDirection(direction)}");
            }
        }
        foreach (var prefix in dict.Keys)
        {
            dict[prefix].ForEach(p =>
            {
                if(p.GetValue(filter) is not null)
                {
                    whereList.Add($"{FilterExecutionGenerator.Represent(FilterExecutionGenerator.RemoveSuffix(p.Name, prefix), "@"+FilterExecutionGenerator.RemoveSuffix(p.Name, prefix), prefix)}");
                }
            });
            Console.WriteLine();
        }


        var selects = "*";
        if (selectList.Count > 0)
        {
            selects = string.Join(", ", selectList.Select(p => "["+FilterExecutionGenerator.RemovePrefix(p,"Select")+"]"));
        }
        var orderByCluase = "";
        if (orderByList.Count > 0)
        {
            orderByCluase = string.Join(", ", orderByList.Select(p => p));
        }
        var whereClause = "";
        if(whereList.Count > 0)
        {
            whereClause = string.Join(" AND ", whereList.Select(p => p));

        }
        return "select : "+selects+ ", orderBy : "+ orderByCluase + ", where : \n"+ whereClause;
    }
    public static void Main()
    {
        var sql = Build(new PersonFilter()
        {
            SelectAge = true,
            SelectAlive = true,
            OrderByAgeAscending = true,
        });
        Console.WriteLine(sql);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        sql = Build(new PersonFilter()
        {
        });
        Console.WriteLine(sql);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        sql = Build(new PersonFilter()
        {
            SelectAge = true,
            SelectAlive = true,
            SelectChar = true,
            OrderByAgeAscending = true,
            OrderByCharDescending = true,
            IdEquals = 9,
            AgeEquals = 10,
        });
        Console.WriteLine(sql);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
    }
}


