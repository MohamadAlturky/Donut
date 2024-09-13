using Donut.QueryBuilding.Enum;

namespace Donut.QueryBuilding.Utils;

public class Where<T>
{
    public string Column { get; set; }
    public T Value { get; set; }
    public Operator Action { get; set; }
}
