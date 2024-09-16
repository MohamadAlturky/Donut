using System.Reflection;


namespace Donut.Generation.Core.Scanner;

public class TypeScanner
{
    public static List<Type> Read(Assembly assembly, Type _type)
    {
        List<Type> classesImplementingITabel = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && _type.IsAssignableFrom(t))
            .ToList();
        return classesImplementingITabel;
    }
}