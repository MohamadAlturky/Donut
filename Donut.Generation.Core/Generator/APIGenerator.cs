using System.Text;

namespace Donut.Generation.Core.Generator;

public class APIGenerator
{
    public static string GenerateCreate(Type inputType, string commandType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string recordName = inputType.Name + "Command";
        string handlerName = "Create" + inputType.Name + "EndPoint";
        string namespaceName = "Donut.EndPoint";

        classBuilder.AppendLine($"""
            using Carter;
            using MediatR;
            using Donut.EndPoints.Requests;
            using Microsoft.AspNetCore.Http;
            using Microsoft.AspNetCore.Builder;
            using Microsoft.AspNetCore.Routing;
            """);
        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"namespace {namespaceName};");
        //classBuilder.AppendLine($"public record {commandType}{recordName}: ICommand<{inputType.Name}>");
        //classBuilder.AppendLine($"{{");

        //classBuilder.AppendLine($"   public required {inputType.Name} {inputType.Name} {{ get; set; }}");
        //classBuilder.AppendLine("}");
        classBuilder.AppendLine($"public class {handlerName}: ICarterModule");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    public void AddRoutes(IEndpointRouteBuilder app)");
        classBuilder.AppendLine($"    {{");
        classBuilder.AppendLine($"        app.MapPost(\"/api/{inputType.Name.ToLower()}\", async (Create{inputType.Name}Request request, ISender sender) =>");

        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            var result = await sender.Send(command);");
        classBuilder.AppendLine($"            ");
        classBuilder.AppendLine("""
                        if (result.IsFailure)
                        {
                            return Results.BadRequest(result.Error);
                        }
            """);
        classBuilder.AppendLine($"            return Results.Ok(result.Value);");
        

        classBuilder.AppendLine("        });");
        classBuilder.AppendLine("    }");
        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
    public static string GenerateCommand(Type inputType, string commandType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string recordName = inputType.Name + "Command";
        string handlerName = commandType + inputType.Name + "CommandHandler";
        string namespaceName = "Donut.CQRS";

        classBuilder.AppendLine($"""
            using Donut.Core.CQRS;
            using Donut.Core.Results;
            using Donut.Core.Tabels;
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
    private static string RemoveFilterSuffix(string input)
    {
        const string suffix = "Filter";

        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        if (input.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
        {
            return input.Substring(0, input.Length - suffix.Length);
        }

        return input;
    }
    public static string GenerateFilterQuery(Type inputType, string commandType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string recordName = inputType.Name + "Query";
        string handlerName = commandType + inputType.Name + "QueryHandler";
        string namespaceName = "Donut.CQRS";
        string entityName = RemoveFilterSuffix(inputType.Name);

        classBuilder.AppendLine($"""
            using Donut.Core.CQRS;
            using Donut.Core.Pagination;
            using Donut.Filters;
            using Donut.Core.Tabels;
            using Donut.Filters.Execution;
            using Donut.Core.Results;
            """);
        classBuilder.AppendLine($"");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public record {commandType}{recordName}: IQuery<PaginatedResponse<{entityName}>>");
        classBuilder.AppendLine($"{{");

        classBuilder.AppendLine($"   public required {inputType.Name} Filter {{ get; set; }}");
        classBuilder.AppendLine("}");
        classBuilder.AppendLine($"public class {handlerName}: IQueryHandler<{commandType}{recordName},PaginatedResponse<{entityName}>>");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    private readonly I{entityName}FilterExecutor _executor;");
        classBuilder.AppendLine($"    public {handlerName}(I{entityName}FilterExecutor executor)");
        classBuilder.AppendLine("""
                {
                    _executor = executor;
                }
            """);
        classBuilder.AppendLine($"    public async Task<Result<PaginatedResponse<{entityName}>>> Handle({commandType}{inputType.Name}Query request, CancellationToken cancellationToken)");
        classBuilder.AppendLine($"    {{");
        classBuilder.AppendLine($"        try");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            var result = _executor.Execute(request.Filter);");
        classBuilder.AppendLine($"            return Result.Success(result);");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"        catch(Exception ex)");
        classBuilder.AppendLine($"        {{");
        classBuilder.AppendLine($"            return Result.Failure<PaginatedResponse<{entityName}>>(new Error(\"Filter{inputType.Name}\", ex.Message));");
        classBuilder.AppendLine($"        }}");
        classBuilder.AppendLine($"    }}");

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
}
