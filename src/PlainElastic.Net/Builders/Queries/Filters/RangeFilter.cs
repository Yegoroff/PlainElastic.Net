using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents with fields that have terms within a certain range.
    /// Similar to range query, except that it acts as a filter
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-filter.html
    /// </summary>
    public class RangeFilter<T> : RangeBase<T, RangeFilter<T>>
    {
        private readonly List<string> modes = new List<string>();


        /// <summary>
        /// Allows to specify filter Name.
        /// </summary>
        public RangeFilter<T> Name(string filterName)
        {
            modes.Add("'_name': {0}".AltQuoteF(filterName.Quotate()));

            return this;
        }

        /// <summary>
        /// Allows to specify Cache Key that will be used as the caching key for that filter.
        /// </summary>
        public RangeFilter<T> CacheKey(string cacheKey)
        {
            modes.Add("'_cache_key': {0}".AltQuoteF(cacheKey.Quotate()));

            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public RangeFilter<T> Cache(bool cache)
        {
            modes.Add("'_cache': {0}".AltQuoteF(cache.AsString()));

            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            string criterion = RegisteredField.IsNullOrEmpty() ? "{{ {0} }}".F(body) 
                                                               : "{0}: {{ {1} }}".F(RegisteredField, body);
            modes.Insert(0, criterion);

            string filterBody = modes.JoinWithComma();

            return "{{ 'range': {{ {0} }} }}".AltQuoteF(filterBody);
        }
    }
}