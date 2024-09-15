////using Donut.Filters;
////using Donut.Filters.Execution.Grouping;
////using System.Reflection;


////class Program
////{
////    static void Main(string[] args)
////    {
////        var groupedProperties = FilterPropertiesGrouper.GroupPropertiesByName(typeof(PersonFilter));

////        var selectProperties = groupedProperties.Item1;
////        var orderByProperties = groupedProperties.Item2;
////        var otherProperties = groupedProperties.Item3;

////        Console.WriteLine("Select Properties:");
////        selectProperties.ForEach(p => Console.WriteLine(p.Name));

////        Console.WriteLine("\nOrderBy Properties:");
////        orderByProperties.ForEach(p => Console.WriteLine(p.Name));

////        Console.WriteLine("\nOther Properties:");
////        otherProperties.ForEach(p => Console.WriteLine(p.Name));

////    }
////}
//using Donut.Filters;
//using Donut.Filters.Files;
//using Donut.Filters.Generator;




//var content = FilterExecutionGenerator.GenerateFilter(typeof(PersonFilter));
//FileWriter fileWriter = new();
//string projectDirectory = "C:\\New folder\\Donut\\Donut.Filters.Execution.Tests";
//Console.WriteLine(projectDirectory);
//fileWriter.CreateFolder($"{projectDirectory}/Generated");
//fileWriter.CreateFile($"{projectDirectory}/Generated/PersonFilterExecutor.cs");
//fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/PersonFilterExecutor.cs");



using Donut.Filters.Execution;
using Donut.QueryBuilding.Execution;
PersonFilterExecutor s = new PersonFilterExecutor(new QueryExecutor());

s.Execute(new Donut.Filters.PersonFilter()
{
    AgeEquals=1,
    AliveEquals=false
});
