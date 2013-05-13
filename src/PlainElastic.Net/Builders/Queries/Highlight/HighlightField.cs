using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Represents document's field with highlight options.
    /// </summary>
    public class HighlightField<T> : HighlightBase<T, HighlightField<T>>
    {
        private string fieldName;


        /// <summary>
        /// Allows to specify field name to highlight.
        /// </summary>
        public HighlightField<T> FieldName(string fieldName)
        {
            this.fieldName = fieldName;
            return this;
        }

        /// <summary>
        /// Allows to specify field of object to highlight.
        /// </summary>
        public HighlightField<T> FieldName(Expression<Func<T, object>> field)
        {
            return FieldName(field.GetPropertyPath());
        }

        /// <summary>
        /// Allows to specify field of object from the collection of such objects to execute highlight.
        /// </summary>
        /// <param name="collectionField">The collection type field.</param>
        /// <param name="field">The field of object inside collection.</param>
        public HighlightField<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fullName = collectionProperty + "." + field.GetPropertyPath();

            return FieldName(fullName);
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ '{0}': {{ {1} }} }}".AltQuoteF(fieldName, body);
        }


        protected override bool ForceJsonBuild()
        {
            return true;
        }
    }
}