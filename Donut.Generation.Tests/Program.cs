using Donut.Core.Tabels;
using Donut.Generation.Core.Files;
using Donut.Generation.Core.Generator;
using Donut.Generation.Core.Scanner;

var types = TypeScanner.Read(typeof(Person).Assembly, typeof(ITabel));

foreach (var type in types)
{
    var content = CQRSGenerator.GenerateAddCommand(type,"Add");
    FileWriter fileWriter = new();
    string projectDirectory = "C:\\Users\\hp\\source\\repos\\Donut\\Donut.Generation.Tests";
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

    content = CQRSGenerator.GenerateFilterQuery(type, "Filter");
    fileWriter = new();
    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/Filter{type.Name}.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/Filter{type.Name}.cs");

    content = RepositoryGenerator.GenerateRepository(type);
    fileWriter = new();
    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Repository.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Repository.cs");

    content = FilterGenerator.GenerateFilter(type);
    fileWriter = new();
    fileWriter.CreateFile($"{projectDirectory}/{type.Name}/{type.Name}Filter.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/{type.Name}/{type.Name}Filter.cs");

}

