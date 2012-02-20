using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents that have fields that contain a term (not analyzed).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-filter.html
    /// </summary>    
    public class TermFilter<T> : IJsonConvertible
    {
        private string termField;
        private string termValue;


        public TermFilter<T> Field(string field)
        {
            termField = field.Quotate();

            return this;
        }

        public TermFilter<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        public TermFilter<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        public TermFilter<T> Value(object value)
        {
            termValue = value.ToString().LowerAndQuotate();

            return this;
        }      

        public TermFilter<T> Value(string value)
        {
            termValue = value.Quotate();            

            return this;
        }


        //TODO: Common filter Cache ??

        string IJsonConvertible.ToJson()
        {
            if (termValue.IsNullOrEmpty())
                return "";

            var result = "{{ 'term': {{ {0} : {1} }} }}".SmartQuoteF(termField, termValue);

            return result;
        }


        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }    
    }
}