using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// The attachment type allows to index different “attachment” type field (encoded as base64),
    /// for example, microsoft office formats, open document formats, ePub, HTML, and so on.
    /// see http://www.elasticsearch.org/guide/reference/mapping/attachment-type.html
    /// </summary>
    public class Attachment<T> : MappingBase<Attachment<T>> 
    {

        /// <summary>
        /// The field name to assign to attachment mapping.
        /// </summary>
        public Attachment<T> Field(string fieldName)
        {           
            Name = fieldName;

            return this;
        }

        /// <summary>
        /// The field to assign to attachment mapping.
        /// </summary>
        public Attachment<T> Field<TField>(Expression<Func<T, TField>> field)
        {
            var fieldName = field.GetPropertyPath();

            return Field(fieldName);
        }

        /// <summary>
        /// The field which is a collection to assign to attachment mapping.
        /// </summary>
        public Attachment<T> Field<TField>(Expression<Func<T, IEnumerable<TField>>> field)
        {
            var fieldName = field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The name of mapped field.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Mapping fields, to which attachment fields will be mapped.
        /// </summary>
        public Attachment<T> Fields(Func<CoreFields<T>, CoreFields<T>> fields)
        {
            RegisterMapAsJson(fields);

            return this;
        }



        protected override string ApplyMappingTemplate(string mappingBody)
        {
            if (mappingBody.IsNullOrEmpty())
                return "{0}: {{ 'type': 'attachment' }}".AltQuoteF(Name.Quotate());

            return "{0}: {{ 'type': 'attachment',{1} }}".AltQuoteF(Name.Quotate(), mappingBody);
        }
    }
}