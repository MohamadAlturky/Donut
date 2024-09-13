using System.Reflection;

namespace Donut.Filters.Execution.Grouping;

public class FilterPropertiesGrouper
{
    public static Tuple<List<PropertyInfo>, List<PropertyInfo>, List<PropertyInfo>> GroupPropertiesByName(Type type)
    {
        // Get all properties of the given type
        PropertyInfo[] properties = type.GetProperties();

        // Group properties based on their names
        var selectProperties = new List<PropertyInfo>();
        var orderByProperties = new List<PropertyInfo>();
        var otherProperties = new List<PropertyInfo>();

        foreach (var property in properties)
        {
            if (property.Name.StartsWith("Select"))
            {
                selectProperties.Add(property);
            }
            else if (property.Name.StartsWith("OrderBy"))
            {
                orderByProperties.Add(property);
            }
            else
            {
                otherProperties.Add(property);
            }
        }

        // Return the three lists in a Tuple
        return Tuple.Create(selectProperties, orderByProperties, otherProperties);
    }
}
