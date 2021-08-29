using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that matches all documents. Maps to Lucene MatchAllDocsQuery.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/match-all-query.html
    /// </summary>
    public class MatchAllQuery<T> : QueryBase<MatchAllQuery<T>>, IJsonConvertible
    {

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public MatchAllQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }


        /// <summary>
        /// Allows to specify which field the boosting will be done on.
        /// </summary>
        public MatchAllQuery<T> NormsField(string normsField)
        {
            RegisterJsonPart("'norms_field': {0}", normsField.Quotate());
            return this;
        }

        /// <summary>
        /// Allows to specify which field the boosting will be done on.
        /// </summary>
        public MatchAllQuery<T> NormsField(Expression<Func<T, object>> normsField)
        {
            return NormsField(normsField.GetPropertyPath());
        }

        /// <summary>
        /// Allows to specify field of object from the collection of such objects to which the boosting will be done on.
        /// </summary>
        /// <param name="collectionField">The collection type field.</param>
        /// <param name="normsField">The field of object inside collection.</param>
        public MatchAllQuery<T> NormsFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> normsField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + normsField.GetPropertyPath();

            return NormsField(fieldName);
        }



        string IJsonConvertible.ToJson()
        {
            var body = JsonParts.JoinWithComma();
            return ApplyJsonTemplate(body);
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'match_all': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}