using Donut.Core.Pagination;

namespace Donut.Core.Filter
{
    public interface IFilter
    {
        PaginatedRequest PaginatedRequest { get; set; }
        bool SelectAll { get; set; }
    }
}
