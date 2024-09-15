using System.Text;

namespace Donut.Filters.Generator;

public class CQRSGenerator
{
    public static string GenerateAddCommand(Type inputType, string commandType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string recordName = inputType.Name + "Command";
        string handlerName = commandType+inputType.Name + "CommandHandler";
        string namespaceName = "Donut.CQRS";

        classBuilder.AppendLine($"""
            using Donut.SharedKernel.DatabaseConnection;
            using Donut.SharedKernel.Repositories;
            using Donut.SharedKernel.Tabels;
            using System.Data;
            using Donut.Core.CQRS;
            using Dapper;
            using Donut.SharedKernel.Results;
            using Donut.Repositories;
            """);
        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public record {commandType}{recordName}: ICommand<{inputType.Name}>");
        classBuilder.AppendLine($"{{");

        classBuilder.AppendLine($"   public required {inputType.Name} {inputType.Name} {{ get; set; }}");
        classBuilder.AppendLine("}");
        classBuilder.AppendLine($"public class {handlerName}: ICommandHandler<{commandType}{recordName},{inputType.Name}>");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    private readonly I{inputType.Name}Repository _repository;");
        classBuilder.AppendLine($"    public {handlerName}(I{inputType.Name}Repository repository)");
        classBuilder.AppendLine("""
                {
                    _repository=repository;
                }
            """);
        classBuilder.AppendLine($"    public async Task<Result<{inputType.Name}>> Handle({commandType}{inputType.Name}Command request, CancellationToken cancellationToken)");
        classBuilder.AppendLine($"    {{");
        classBuilder.AppendLine($"        try");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            var entity = await _repository.{commandType}(request.{inputType.Name});");
        classBuilder.AppendLine($"            return Result.Success(entity);");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"        catch(Exception ex)");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            return Result.Failure<{inputType.Name}>(new Error(\"{commandType}{inputType.Name}\", ex.Message));");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"    }}");

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
    public static string GenerateCommand(Type inputType, string commandType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string recordName = inputType.Name + "Command";
        string handlerName = commandType+inputType.Name + "CommandHandler";
        string namespaceName = "Donut.CQRS";

        classBuilder.AppendLine($"""
            using Donut.SharedKernel.DatabaseConnection;
            using Donut.SharedKernel.Repositories;
            using Donut.SharedKernel.Tabels;
            using System.Data;
            using Donut.Core.CQRS;
            using Dapper;
            using Donut.SharedKernel.Results;
            using Donut.Repositories;
            """);
        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public record {commandType}{recordName}: ICommand");
        classBuilder.AppendLine($"{{");

        classBuilder.AppendLine($"   public required {inputType.Name} {inputType.Name} {{ get; set; }}");
        classBuilder.AppendLine("}");
        classBuilder.AppendLine($"public class {handlerName}: ICommandHandler<{commandType}{recordName}>");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    private readonly I{inputType.Name}Repository _repository;");
        classBuilder.AppendLine($"    public {handlerName}(I{inputType.Name}Repository repository)");
        classBuilder.AppendLine("""
                {
                    _repository=repository;
                }
            """);
        classBuilder.AppendLine($"    public async Task<Result> Handle({commandType}{inputType.Name}Command request, CancellationToken cancellationToken)");
        classBuilder.AppendLine($"    {{");
        classBuilder.AppendLine($"        try");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            await _repository.{commandType}(request.{inputType.Name});");
        classBuilder.AppendLine($"            return Result.Success();");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"        catch(Exception ex)");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            return Result.Failure(new Error(\"{commandType}{inputType.Name}\", ex.Message));");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"    }}");

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }

    public static string GenerateFilterQuery(Type inputType, string commandType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string recordName = inputType.Name + "Query";
        string handlerName = commandType+inputType.Name + "QueryHandler";
        string namespaceName = "Donut.CQRS";

        classBuilder.AppendLine($"""
            using Donut.SharedKernel.Tabels;
            using Donut.Core.CQRS;
            using Donut.Core.Pagination;
            using Donut.Filters.Execution;
            using Donut.Filters;
            using Donut.SharedKernel.Results;
            """);
        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public record {commandType}{recordName}: IQuery<PaginatedResponse<{inputType.Name}>>");
        classBuilder.AppendLine($"{{");

        classBuilder.AppendLine($"   public required {inputType.Name}Filter Filter {{ get; set; }}");
        classBuilder.AppendLine("}");
        classBuilder.AppendLine($"public class {handlerName}: IQueryHandler<{commandType}{recordName},PaginatedResponse<{inputType.Name}>>");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    private readonly I{inputType.Name}FilterExecutor _executor;");
        classBuilder.AppendLine($"    public {handlerName}(I{inputType.Name}FilterExecutor executor)");
        classBuilder.AppendLine("""
                {
                    _executor = executor;
                }
            """);
        classBuilder.AppendLine($"    public async Task<Result<PaginatedResponse<{inputType.Name}>>> Handle({commandType}{inputType.Name}Query request, CancellationToken cancellationToken)");
        classBuilder.AppendLine($"    {{");
        classBuilder.AppendLine($"        try");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            var result = _executor.Execute(request.Filter);");
        classBuilder.AppendLine($"            return Result.Success(result);");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"        catch(Exception ex)");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            return Result.Failure<PaginatedResponse<{inputType.Name}>>(new Error(\"{commandType}{inputType.Name}\", ex.Message));");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"    }}");

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
}
