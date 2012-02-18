using System;


namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents numeric fields mapping.
    /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
    /// </summary>
    public class NumberMap<T> : PropertyBase<T, NumberMap<T>>
    {
        private string customNumberType;


        /// <summary>
        /// Allows explicitly specify type of the number.
        /// By default type inferred from mapped property type.
        /// </summary>
        public NumberMap<T> Type(NumberMappingType mappingType)
        {           
            customNumberType = mappingType.ToString();
            FieldType = customNumberType;

            return this;
        }


        protected override string GetFieldType(Type fieldType)
        {
            if (!customNumberType.IsNullOrEmpty())
                return customNumberType;

            // Elastic Search stores enums as long.
            if (fieldType.IsEnum)
                return "long";

            var typeCode = System.Type.GetTypeCode(fieldType);
            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
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

            return "double";
        }
    }

    
}