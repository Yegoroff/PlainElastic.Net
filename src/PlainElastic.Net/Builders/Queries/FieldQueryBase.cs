using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class FieldQueryBase<T, TQuery>: QueryBase<TQuery> where TQuery: FieldQueryBase<T, TQuery>
    {
        protected string RegisteredField { get; set; }


        public TQuery Field(string fieldName)
        {
            RegisteredField = fieldName.Quotate();
            return (TQuery)this;
        }

        public TQuery Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        public TQuery FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }
    }
}