using System;
using System.Linq;

namespace PlainElastic.T4Generators.Utils
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string elasticId)
        {
            var idParts = elasticId
                            .Split('_')
                            .Select(part => part.Substring(0, 1).ToUpper() + part.Substring(1));
            return string.Join(string.Empty, idParts);
        }


        public static string Uncapitalize(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }

        public static string ToCodeSummary(this string description, int indentSpaces)
        {
            var prefix = new string(' ', indentSpaces) + "/// ";
            var lines = description.Split('\n');
            var indentedNextLines = lines.Skip(1).Select(s => Environment.NewLine + prefix + s);
            return lines[0] + string.Join(string.Empty, indentedNextLines);
        }

        public static NetTypeCategory GetNetTypeCategory(this string netType)
        {
            switch (netType)
            {
                case "int":
                case "double":
                case "bool":
                    return NetTypeCategory.Primitive;
                case "string":
                    return NetTypeCategory.String;
                default:
                    return NetTypeCategory.Enum;
            }
        }
    }

    public enum NetTypeCategory
    {
        None,
        Primitive,
        Enum,
        String
    }
}