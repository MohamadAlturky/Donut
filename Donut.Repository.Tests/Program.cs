using Donut.Filters.Files;
using Donut.Repository.Generator;
using Donut.SharedKernel.SQL;
using Donut.SharedKernel.Tabels;
using Donut.SharedKernel.TableSpecifications.Scanner;

var types = TypeScanner.Read(typeof(Person).Assembly, typeof(ITabel));

foreach (var type in types)
{
    var content = RepositoryGenerator.GenerateRepository(type);
    FileWriter fileWriter = new();
    string projectDirectory = "C:\\New folder\\Donut\\Donut.Repository.Tests";
    Console.WriteLine(projectDirectory);
    fileWriter.CreateFolder($"{projectDirectory}/Generated");
    fileWriter.CreateFile($"{projectDirectory}/Generated/{type.Name}Repository.cs");
    fileWriter.WriteToFile(content, $"{projectDirectory}/Generated/{type.Name}Repository.cs");
}

