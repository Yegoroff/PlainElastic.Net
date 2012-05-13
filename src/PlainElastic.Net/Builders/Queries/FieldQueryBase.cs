using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class FieldQueryBase<T, TQuery>: QueryBase<TQuery> where TQuery: FieldQueryBase<T, TQuery>
    {
        protected string RegisteredField { get; set; }

        /// <summary>
        /// Allows to specify field name to execute query/filter against.
        /// </summary>
        public TQuery Field(string fieldName)
        {
            RegisteredField = fieldName.Quotate();
            return (TQuery)this;
        }

        /// <summary>
        /// Allows to specify field of object to execute query/filter against.
        /// </summary>
        public TQuery Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// Allows to specify field of object from the collection of such objects to execute query/filter against.
        /// </summary>
        /// <param name="collectionField">The collection type field.</param>
        /// <param name="field">The field of object inside collection.</param>
        public TQuery FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }
    }
}