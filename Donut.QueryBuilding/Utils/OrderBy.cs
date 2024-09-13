using Donut.QueryBuilding.Enum;

namespace Donut.SharedKernel.Filters.Utils;

public class OrderBy
{
    public string Column { get; set; }
    public OrderDirection Direction { get; set; }
}
