using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Wraps any query to be used as a filter. Can be placed within queries that accept a filter.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/query-filter.html
    /// </summary>
    public class QueryFilter<T> : Query<T>
    {
        private readonly List<string> modes = new List<string>();


        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public QueryFilter<T> Name(string filterName)
        {
            modes.Add("'_name': {0}".AltQuoteF(filterName.Quotate()));

            return this;
        }

        /// <summary>
        /// Allows to specify Cache Key that will be used as the caching key for that filter.
        /// </summary>
        public QueryFilter<T> CacheKey(string cacheKey)
        {
            modes.Add("'_cache_key': {0}".AltQuoteF(cacheKey.Quotate()));

            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public QueryFilter<T> Cache(bool cache)
        {
            modes.Add("'_cache': {0}".AltQuoteF(cache.AsString()));

            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            string query = "'query': {0}".AltQuoteF(body);

            modes.Insert(0, query);

            string filterBody = modes.JoinWithComma();

            return "{{ 'fquery': {{ {0} }} }}".AltQuoteF(filterBody);
        }
    }
}