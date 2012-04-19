using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that filters out matched documents using a query.
    /// This filter is more performant then bool filter. Can be placed within queries that accept a filter
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/not-filter.html
    /// </summary>
    public class NotFilter<T> : QueryBase<NotFilter<T>>
    {
        private bool hasRequiredParts;

        /// <summary>
        /// The clause must appear in matching documents.
        /// </summary>
        public NotFilter<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasRequiredParts = !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public NotFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'not': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}