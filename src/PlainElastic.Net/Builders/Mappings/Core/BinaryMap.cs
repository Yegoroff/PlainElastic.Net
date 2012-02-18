using System;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents binary data fields mapping.
    /// see http://www.elasticsearch.org/guide/reference/mapping/core-types.html
    /// </summary>
    public class BinaryMap<T> : PropertyBase<T, BinaryMap<T>>
    {

        protected override string GetFieldType(Type fieldType)
        {
            return "binary";
        }
    }
}