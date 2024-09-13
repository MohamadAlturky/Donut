using Donut.Filters;
using Donut.Filters.Execution.Grouping;
using System.Reflection;


class Program
{
    static void Main(string[] args)
    {
        var groupedProperties = FilterPropertiesGrouper.GroupPropertiesByName(typeof(PersonFilter));

        var selectProperties = groupedProperties.Item1;
        var orderByProperties = groupedProperties.Item2;
        var otherProperties = groupedProperties.Item3;

        Console.WriteLine("Select Properties:");
        selectProperties.ForEach(p => Console.WriteLine(p.Name));

        Console.WriteLine("\nOrderBy Properties:");
        orderByProperties.ForEach(p => Console.WriteLine(p.Name));

        Console.WriteLine("\nOther Properties:");
        otherProperties.ForEach(p => Console.WriteLine(p.Name));

    }
}
