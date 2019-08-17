using System;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents boolean fields mapping.
    /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
    /// </summary>
    public class BooleanMap<T> : PropertyBase<T, BooleanMap<T>>
    {
        protected override string GetElasticFieldType(Type fieldType)
        {
            return "boolean";
        }

        /// <summary>
        /// The fields options allows to map several core types fields into a single json source field
        /// </summary>
        public virtual BooleanMap<T> Fields(Func<CoreFields<BooleanMap<T>>, CoreFields<BooleanMap<T>>> fields)
        {
            RegisterMapAsJson(fields);
            return this;
        }
    }
}