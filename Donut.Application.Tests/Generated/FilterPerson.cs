using Donut.SharedKernel.Tabels;
using Donut.Core.CQRS;
using Donut.Core.Pagination;
using Donut.Filters.Execution;
using Donut.Filters;
using Donut.SharedKernel.Results;

namespace Donut.CQRS;
public record FilterPersonQuery: IQuery<PaginatedResponse<Person>>
{
   public required PersonFilter Filter { get; set; }
}
public class FilterPersonQueryHandler: IQueryHandler<FilterPersonQuery,PaginatedResponse<Person>>
{
    private readonly IPersonFilterExecutor _executor;
    public FilterPersonQueryHandler(IPersonFilterExecutor executor)
    {
        _executor = executor;
    }
    public async Task<Result<PaginatedResponse<Person>>> Handle(FilterPersonQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = _executor.Execute(request.Filter);
            return Result.Success(result);
        }
        catch(Exception ex)
        {
            return Result.Failure<PaginatedResponse<Person>>(new Error("FilterPerson", ex.Message));
        }
    }
}
