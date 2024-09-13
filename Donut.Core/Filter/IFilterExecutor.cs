using Donut.Core.Pagination;

namespace Donut.Core.Filter;

public interface IFilterExecutor<TEntity, TEntityFilter>
{
    PaginatedResponse<TEntity> Execute(TEntityFilter filter);
}
