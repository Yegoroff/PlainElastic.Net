using System;

namespace PlainElastic.Net.Mappings
{
    public static class ElasticCoreTypeMapper
    {

        public static string GetElasticType(Type fieldType)
        {
            if (fieldType == typeof(String))
                return "string";

            if (fieldType == typeof(Boolean))
                return "boolean";

            if (fieldType == typeof(DateTime))
                return "date";

            return GetElasticNumericType(fieldType) ?? "string";
        }


        public static string GetElasticNumericType(Type fieldType)
        {           
            if (fieldType.IsEnum)
                return "long";

            // Map numeric types.
            var typeCode = Type.GetTypeCode(fieldType);
            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Boolean:
                    return "byte";

                case TypeCode.UInt16:
                case TypeCode.Int16:
                    return "short";

                case TypeCode.UInt32:
                case TypeCode.Int32:
                    return "integer";

                case TypeCode.UInt64:
                case TypeCode.Int64:
                    return "long";

                case TypeCode.Single:
                    return "float";

                case TypeCode.Double:
                    return "double";
            }
            return null;
        }

    }
}