using Donut.Generation.Core.Scanner;
using System.Reflection;
using System.Text;

namespace Donut.Generation.Core.Generator;

public class DTOGenerator
{
    public static string Generate(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = inputType.Name + "DTO";
        string namespaceName = "Donut.DTO";

        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    ");

        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
            BuildProperties(classBuilder, property);
        }

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
    public static string GenerateRequest(Type inputType,string prefix,string suffix)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = prefix+inputType.Name + suffix;
        string namespaceName = "Donut.EndPoints.Requests";

        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    ");

        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
            BuildProperties(classBuilder, property);
        }

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }

    private static void BuildProperties(StringBuilder classBuilder, PropertyInfo property)
    {
        string nonNullTypeName = TypeReader.GetPrimitiveTypeName(GetNullableTypeName(property));

        string typeName = nonNullTypeName;
        classBuilder.AppendLine($"    public {typeName} {property.Name} {{ get; set; }}");
        //classBuilder.AppendLine($"    ");
    }

    private static string GetNullableTypeName(PropertyInfo property)
    {
        Type type = GetNonNullableType(property);
        return $"{type.Name}";
    }
    private static Type GetNonNullableType(PropertyInfo propertyInfo)
    {
        Type propertyType = propertyInfo.PropertyType;

        if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            return Nullable.GetUnderlyingType(propertyType);
        }

        return propertyType.IsByRef ? propertyType.GetElementType() : propertyType;
    }
}
