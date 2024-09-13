using Donut.QueryBuilding.Enum;

namespace Donut.SharedKernel.Filters.Utils;

public class Where<T>
{
    public string Column { get; set; }
    public T Value { get; set; }
    public Operator Action { get; set; }
}
