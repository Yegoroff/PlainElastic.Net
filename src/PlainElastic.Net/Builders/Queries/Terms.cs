using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that match on any (configurable) of the provided terms.
    /// This is a simpler syntax query for using a bool query with several term queries in the should clauses
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/terms-query.html
    /// </summary>    
    public class Terms<T> : IJsonConvertible
    {
        private string termsValues;
        private string termsField;
        private string minimumMatchValue;


        public Terms<T> Field(Expression<Func<T, object>> field)
        {
            termsField = field.GetQuotatedPropertyPath();

            return this;
        }

        public Terms<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            termsField = fieldName.Quotate();

            return this;
        }


        public Terms<T> Values(IEnumerable<string> values)
        {
            if (values != null)
                termsValues = values.Where(v => !v.IsNullOrEmpty()).LowerAndQuotate().JoinWithComma();

            return this;
        }
    
        public Terms<T> MinimumMatch(int count)
        {
            minimumMatchValue = count.AsString();

            return this;
        }


        string IJsonConvertible.ToJson()
        {
            if (termsValues.IsNullOrEmpty())
                return "";

            var minimumMatchPart = "";
            if (!minimumMatchValue.IsNullOrEmpty())
                minimumMatchPart = ", 'minimum_match' :{0}".SmartQuoteF(minimumMatchValue);

            var result = "{{ 'terms': {{ {0} : [ {1} ] {2} }} }}".SmartQuoteF(termsField, termsValues, minimumMatchPart);

            return result;
        }


        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }
    }
}