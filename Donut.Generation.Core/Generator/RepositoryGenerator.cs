using Donut.Generation.Core.Scanner;
using System.Reflection;
using System.Text;

namespace Donut.Generation.Core.Generator;

public class RepositoryGenerator
{
    public static string GenerateRepository(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = inputType.Name + "Repository";
        string namespaceName = "Donut.Repositories";

        classBuilder.AppendLine($"""
            using System.Data;
            using Dapper;
            using Donut.Core.DatabaseConnection;
            using Donut.Core.Repositories;
            using Donut.Core.Tabels;
            """);
        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public interface I{className}: IRepository<{inputType.Name}>");
        classBuilder.AppendLine($"{{");

        classBuilder.AppendLine("}");
        classBuilder.AppendLine($"public class {className}: I{className}");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine("""

                private readonly IDbConnectionFactory _factory;

            """);
        classBuilder.AppendLine($"    public {inputType.Name}Repository(IDbConnectionFactory factory)");
        classBuilder.AppendLine($"    {{");
        classBuilder.AppendLine($"        _factory=factory;");
        classBuilder.AppendLine($"    }}");



        CreateAddFunctions(inputType, classBuilder);
        CreateUpdateFunctions(inputType, classBuilder);
        CreateDeleteFunctions(inputType, classBuilder);
        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }

    private static void CreateDeleteFunctions(Type inputType, StringBuilder classBuilder)
    {
        classBuilder.AppendLine($"    public async Task Delete({inputType.Name} entity)");
        classBuilder.AppendLine("    {");
        classBuilder.AppendLine("         using (var connection = _factory.CreateConnection())");
        classBuilder.AppendLine("         {");
        classBuilder.AppendLine($"            var sql = \"DELETE FROM {inputType.Name} WHERE Id = @Id;\";");
        classBuilder.AppendLine("            await connection.ExecuteAsync(sql, entity);");
        classBuilder.AppendLine("         }");
        classBuilder.AppendLine("    }");

        classBuilder.AppendLine($"    public async Task DeleteTransactional({inputType.Name} entity, IDbConnection connection, IDbTransaction transaction)");
        classBuilder.AppendLine("    {");
        classBuilder.AppendLine($"         var sql = \"DELETE FROM {inputType.Name} WHERE Id = @Id;\";");
        classBuilder.AppendLine("         await connection.ExecuteAsync(sql, entity, transaction);");
        classBuilder.AppendLine("    }");
    }

    private static void CreateUpdateFunctions(Type inputType, StringBuilder classBuilder)
    {
        var parameterNames = GetFormattedPropertiesForUpdate(inputType);

        classBuilder.AppendLine($"    public async Task Update({inputType.Name} entity)");
        classBuilder.AppendLine("    {");
        classBuilder.AppendLine("         using (var connection = _factory.CreateConnection())");
        classBuilder.AppendLine("         {");
        classBuilder.AppendLine("           ");
        classBuilder.AppendLine($"           var sql = \"UPDATE {inputType.Name} SET {parameterNames} WHERE Id = @Id;\";");
        classBuilder.AppendLine("           await connection.ExecuteAsync(sql, entity);");

        classBuilder.AppendLine("         }");
        classBuilder.AppendLine("    }");

        classBuilder.AppendLine($"    public async Task UpdateTransactional({inputType.Name} entity, IDbConnection connection, IDbTransaction transaction)");
        classBuilder.AppendLine("    {");
        classBuilder.AppendLine($"        var sql = \"UPDATE {inputType.Name} SET {parameterNames} WHERE Id = @Id;\";");
        classBuilder.AppendLine("        await connection.ExecuteAsync(sql, entity, transaction);");
        classBuilder.AppendLine("    }");
    }

    private static void CreateAddFunctions(Type inputType, StringBuilder classBuilder)
    {
        var (propertyNames, parameterNames) = GetFormattedProperties(inputType);
        classBuilder.AppendLine($"    public async Task<{inputType.Name}> Add({inputType.Name} entity)");
        classBuilder.AppendLine("    {");
        classBuilder.AppendLine("         using (var connection = _factory.CreateConnection())");
        classBuilder.AppendLine("         {");
        classBuilder.AppendLine("           ");
        classBuilder.AppendLine($"           var sql = \"INSERT INTO Persons ({propertyNames}) VALUES ({parameterNames}); SELECT CAST(SCOPE_IDENTITY() AS int);\";");
        classBuilder.AppendLine("           var id = await connection.ExecuteScalarAsync<int>(sql, entity);");
        classBuilder.AppendLine("           entity.Id = id; // Assuming Person has an Id property");
        classBuilder.AppendLine("           return entity;");

        classBuilder.AppendLine("         }");
        classBuilder.AppendLine("    }");

        classBuilder.AppendLine($"    public async Task<{inputType.Name}> AddTransactional({inputType.Name} entity, IDbConnection connection, IDbTransaction transaction)");
        classBuilder.AppendLine("    {");
        classBuilder.AppendLine($"        var sql = \"INSERT INTO Persons ({propertyNames}) VALUES ({parameterNames}); SELECT CAST(SCOPE_IDENTITY() AS int);\";");
        classBuilder.AppendLine("        var id = await connection.ExecuteScalarAsync<int>(sql, entity, transaction);");
        classBuilder.AppendLine("        entity.Id = id; // Assuming Person has an Id property");
        classBuilder.AppendLine("        return entity;");
        classBuilder.AppendLine("    }");
    }
    public static (string, string) GetFormattedProperties(Type inputType)
    {
        // Get the properties of the type T
        var properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        properties = properties.Where(e => e.Name != "Id").ToArray();

        // Create the formatted strings
        var propertyNames = string.Join(", ", properties.Select(p => "[" + p.Name + "]"));
        var parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

        return (propertyNames, parameterNames);
    }
    public static string GetFormattedPropertiesForUpdate(Type inputType)
    {
        // Get the properties of the type T
        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        properties = properties.Where(e => e.Name != "Id").ToArray();
        // Create the formatted strings
        var parameterNames = string.Join(", ", properties.Select(p => p.Name + " = " + "@" + p.Name));

        return parameterNames;
    }
}
