using System.Reflection;

namespace Donut.SharedKernel.SQL.Scanner
{
    public class TypeReader
    {
        public static string GetPrimitiveTypeName(string typeName) => typeName switch
        {
            "Int32" => "int",
            "String" => "string",
            "Int64" => "long",
            "Char" => "char",
            "Boolean" => "bool",
            "Double" => "double",
            "Decimal" => "decimal",
            "DateOnly" => "DateOnly",
            "DateTime" => "DateTime",
            _ => throw new ArgumentException($"Unsupported type: {typeName}")
        };
    }

}
