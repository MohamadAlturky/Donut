using Donut.Generation.Core.Scanner;
using System.Reflection;
using System.Text;

namespace Donut.Generation.Core.Generator;

public class MapperGenerator
{
    public static string Generate(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = inputType.Name + "DTOMapper";
        string mappedClassName = inputType.Name + "DTO";
        string namespaceName = "Donut.DTO.Mapper";

        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    ");

        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
            BuildProperties(classBuilder, property, mappedClassName,inputType.Name);
        }

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }
    public static string GenerateRequest(Type inputType,string prefix,string suffix)
    {
        StringBuilder classBuilder = new StringBuilder();
        string mappedClassName = prefix+inputType.Name + suffix;
        string className = prefix+inputType.Name + suffix+ "Mapper";
        string namespaceName = "Donut.EndPoints.Mapper";

        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    ");

        PropertyInfo[] properties = inputType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
            BuildProperties(classBuilder, property, mappedClassName, inputType.Name);
        }

        classBuilder.AppendLine("}");

        return classBuilder.ToString();
    }

    private static void BuildProperties(StringBuilder classBuilder, PropertyInfo property,string mappedClassName,string entity)
    {
        string nonNullTypeName = TypeReader.GetPrimitiveTypeName(GetNullableTypeName(property));

        string typeName = nonNullTypeName;
        classBuilder.AppendLine($"    public {entity} {property.Name} {{ get; set; }}");
        classBuilder.AppendLine($"    public {entity} {property.Name} {{ get; set; }}");
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
