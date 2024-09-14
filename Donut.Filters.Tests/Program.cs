using Donut.Filters.Files;
using Donut.Filters.Generator;
using Donut.SharedKernel.SQL;
using Donut.SharedKernel.Tabels;
using Donut.SharedKernel.TableSpecifications.Scanner;

var types = TypeScanner.Read(typeof(Person).Assembly, typeof(ITabel));

foreach (var type in types)
{
    var content = FilterGenerator.GenerateFilter(type);
    Console.WriteLine(content);
    FileWriter fileWriter = new();
    string projectDirectory = "C:\\New folder\\Donut\\Donut.Filters.Tests";
    Console.WriteLine(projectDirectory);
    fileWriter.CreateFolder($"{projectDirectory}/Generated");
    fileWriter.CreateFile($"{projectDirectory}/Generated/{type.Name}Filter.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/{type.Name}Filter.cs");
}

