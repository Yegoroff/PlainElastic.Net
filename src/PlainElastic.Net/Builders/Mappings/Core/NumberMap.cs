using System;
using PlainElastic.Net.Utils;


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
            customNumberType = mappingType.ToString().ToLower();
            FieldType = customNumberType;

            return this;
        }


        protected override string GetElasticFieldType(Type fieldType)
        {
            if (!customNumberType.IsNullOrEmpty())
                return customNumberType;

            string mappingType = ElasticCoreTypeMapper.GetElasticNumericType(fieldType);

            return mappingType ?? "double";
        }
    }

    
}