using System;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Builds a mapping that allows to map inner JSON object. 
    /// http://www.elasticsearch.org/guide/reference/mapping/object-type.html
    /// </summary>
    public class Object<T>: ObjectBase<T,Object<T>>
    {
        /// <summary>
        /// The object type field to map.
        /// </summary>
        public Object<TField> Field<TField>(Expression<Func<T, TField>> field)
        {
            var fieldName = field.GetPropertyName();

            var objectForField = new Object<TField>{Name = fieldName};

            return objectForField;
        }


    }
}