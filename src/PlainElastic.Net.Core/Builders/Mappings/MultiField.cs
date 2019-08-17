using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// The multi_field type allows to map several core types of the same value. 
    /// This can come very handy, for example, when wanting to map a string type, 
    /// once when its analyzed and once when its not_analyzed.
    /// see http://www.elasticsearch.org/guide/reference/mapping/multi-field-type.html
    /// </summary>
    public class MultiField<T> : MappingBase<MultiField<T>> 
    {

        /// <summary>
        /// The field name to assign to multi field mapping.
        /// </summary>
        public MultiField<T> Field(string fieldName)
        {           
            Name = fieldName;

            return this;
        }

        /// <summary>
        /// The field to assign to multi field mapping.
        /// </summary>
        public MultiField<T> Field<TField>(Expression<Func<T, TField>> field)
        {
            var fieldName = field.GetPropertyPath();

            return Field(fieldName);
        }

        /// <summary>
        /// The field which is a collection to assign to multi field mapping.
        /// </summary>
        public MultiField<T> Field<TField>(Expression<Func<T, IEnumerable<TField>>> field)
        {
            var fieldName = field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The name of mapped field.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Mapping fields, to which original field will be mapped.
        /// </summary>
        public MultiField<T> Fields(Func<CoreFields<T>, CoreFields<T>> fields)
        {
            RegisterMapAsJson(fields);

            return this;
        }



        protected override string ApplyMappingTemplate(string mappingBody)
        {
            return "{0}: {{ 'type': 'multi_field',{1} }}".AltQuoteF(Name.Quotate(), mappingBody);
        }
    }
}