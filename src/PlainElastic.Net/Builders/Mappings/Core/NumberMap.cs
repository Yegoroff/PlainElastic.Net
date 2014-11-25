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
            customNumberType = mappingType.AsString().ToLower();
            FieldType = customNumberType;

            return this;
        }

        /// <summary>
        /// Allow to configure a fuzzy_factor mapping value (defaults to 1), which will be used to multiply the fuzzy value by it when used in a query_string type query.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/fuzzy-query.html
        /// </summary>
        public NumberMap<T> FuzzyFactor(int fuzzyFactor = 1)
        {
            RegisterCustomJsonMap("'fuzzy_factor': {0}", fuzzyFactor.AsString());
            return this;
        }


        protected override string GetElasticFieldType(Type fieldType)
        {
            if (!customNumberType.IsNullOrEmpty())
                return customNumberType;

            string mappingType = ElasticCoreTypeMapper.GetElasticNumericType(fieldType);

            return mappingType ?? "double";
        }

        /// <summary>
        /// The fields options allows to map several core types fields into a single json source field
        /// </summary>
        public virtual NumberMap<T> Fields(Func<CoreFields<NumberMap<T>>, CoreFields<NumberMap<T>>> fields)
        {
            RegisterMapAsJson(fields);
            return this;
        }
    }
}