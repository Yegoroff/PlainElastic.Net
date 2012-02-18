using System;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents boolean fields mapping.
    /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
    /// </summary>
    public class BooleanMap<T> : PropertyBase<T, BooleanMap<T>>
    {
        protected override string GetFieldType(Type fieldType)
        {
            return "boolean";
        }

    }
}