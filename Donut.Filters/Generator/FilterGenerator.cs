using Donut.SharedKernel.SQL.Scanner;
using System.Reflection;
using System.Text;

namespace Donut.Filters.Generator;

public class FilterGenerator
{
    public static string GenerateFilter(Type inputType)
    {
        StringBuilder classBuilder = new StringBuilder();
        string className = inputType.Name + "Filter";
        string namespaceName = "Donut.Filters";

        classBuilder.AppendLine($"using Donut.Core.Filter;");
        classBuilder.AppendLine($"using Donut.Core.Pagination;\n");
        classBuilder.AppendLine($"namespace {namespaceName};");
        classBuilder.AppendLine($"public class {className}: IFilter");
        classBuilder.AppendLine("{");
        classBuilder.AppendLine($"    // For Every Filter");
        classBuilder.AppendLine($"    public PaginatedRequest PaginatedRequest {{ get; set; }}");
        classBuilder.AppendLine($"    public bool EagerLoading {{ get; set; }} = true;\n");

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
        string typeName = nonNullTypeName+"?";
        classBuilder.AppendLine($"    // {property.Name}");
        classBuilder.AppendLine($"    public {typeName} {property.Name}Equals {{ get; set; }}");
        classBuilder.AppendLine($"    public {typeName} {property.Name}NotEqual {{ get; set; }}");
        classBuilder.AppendLine($"    public bool Select{property.Name} {{ get; set; }}");
        classBuilder.AppendLine($"    public bool OrderBy{property.Name}Ascending {{ get; set; }}");
        classBuilder.AppendLine($"    public bool OrderBy{property.Name}Descending {{ get; set; }}");
        if (nonNullTypeName=="string")
        {
            classBuilder.AppendLine($"    public {typeName} {property.Name}Contains {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}StartsWith {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}EndsWith {{ get; set; }}");
        }
        if (nonNullTypeName=="int"||nonNullTypeName=="decimal"||nonNullTypeName=="double"||nonNullTypeName=="long")
        {
            classBuilder.AppendLine($"    public {typeName} {property.Name}LessThanNumber {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}BiggerThanNumber {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}LessThanOrEqualNumber {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}BiggerThanOrEqualNumber {{ get; set; }}");
        }
        if (nonNullTypeName=="DateTime"||nonNullTypeName=="DateOnly")
        {
            classBuilder.AppendLine($"    public {typeName} {property.Name}LessThanDate {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}BiggerThanDate {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}LessThanOrEqualDate {{ get; set; }}");
            classBuilder.AppendLine($"    public {typeName} {property.Name}BiggerThanOrEqualDate {{ get; set; }}");
        }
        classBuilder.AppendLine($"\n");
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
