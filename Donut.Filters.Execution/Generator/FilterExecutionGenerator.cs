using System.Reflection;
using System.Text;

namespace Donut.Filters.Generator;

public class FilterExecutionGenerator
{
    public static string GenerateFilter(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = inputType.Name + "Executor";
        string namespaceName = "Donut.Filters.Execution";

        classBuilder.AppendLine($"using Donut.Core.Filter;");
        classBuilder.AppendLine($"using Donut.Core.Pagination;\n");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}: IFilterExecutor");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    // For Every Filter");
        classBuilder.AppendLine($"    public PaginatedResponse<TEntity> Execute(TEntityFilter filter)\n");
        classBuilder.AppendLine($"{{\n");
        classBuilder.AppendLine($"}}\n");

        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
}
