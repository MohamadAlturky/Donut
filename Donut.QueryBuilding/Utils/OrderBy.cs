using Donut.QueryBuilding.Enum;

namespace Donut.QueryBuilding.Utils;

public class OrderBy
{
    public string Column { get; set; }
    public OrderDirection Direction { get; set; }
}
