using Donut.Filters.Files;
using Donut.Filters.Generator;
using Donut.SharedKernel.SQL;
using Donut.SharedKernel.Tabels;
using Donut.SharedKernel.TableSpecifications.Scanner;

var types = TypeScanner.Read(typeof(Person).Assembly, typeof(ITabel));

foreach (var type in types)
{
    var content = CQRSGenerator.GenerateAddCommand(type,"Add");
    FileWriter fileWriter = new();
    string projectDirectory = "C:\\New folder\\Donut\\Donut.Application.Tests";
    Console.WriteLine(projectDirectory);
    fileWriter.CreateFolder($"{projectDirectory}/Generated");
    fileWriter.CreateFile($"{projectDirectory}/Generated/Add{type.Name}.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/Add{type.Name}.cs");

    content = CQRSGenerator.GenerateCommand(type, "Update");
    fileWriter = new();
    projectDirectory = "C:\\New folder\\Donut\\Donut.Application.Tests";
    Console.WriteLine(projectDirectory);
    fileWriter.CreateFile($"{projectDirectory}/Generated/Update{type.Name}.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/Update{type.Name}.cs");

    content = CQRSGenerator.GenerateCommand(type, "Delete");
    fileWriter = new();
    projectDirectory = "C:\\New folder\\Donut\\Donut.Application.Tests";
    Console.WriteLine(projectDirectory);
    fileWriter.CreateFile($"{projectDirectory}/Generated/Delete{type.Name}.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/Delete{type.Name}.cs");

    content = CQRSGenerator.GenerateFilterQuery(type, "Filter");
    fileWriter = new();
    projectDirectory = "C:\\New folder\\Donut\\Donut.Application.Tests";
    Console.WriteLine(projectDirectory);
    fileWriter.CreateFile($"{projectDirectory}/Generated/Filter{type.Name}.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/Filter{type.Name}.cs");

}

