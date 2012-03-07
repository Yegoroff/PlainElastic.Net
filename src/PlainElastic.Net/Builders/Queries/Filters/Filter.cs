using System;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to filter result hits without changing facet results.
    /// see http://www.elasticsearch.org/guide/reference/api/search/filter.html
    /// </summary>
    public class Filter<T> : QueryBase<Filter<T>>
    {


        /// <summary>
        /// A filter that matches documents using AND boolean operator on other queries.
        /// This filter is more performant then bool filter. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/and-filter.html
        /// </summary>
        public Filter<T> And (Func<AndFilter<T>, Filter<T>> andFilter)
        {
            RegisterJsonPartExpression(andFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields that contain a term (not analyzed).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-filter.html
        /// </summary>
        public Filter<T> Term(Func<TermFilter<T>, TermFilter<T>> termFilter)
        {
            RegisterJsonPartExpression(termFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields that match any of the provided terms (not analyzed).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/terms-filter.html
        /// </summary>
        public Filter<T> Terms(Func<TermsFilter<T>, TermsFilter<T>> termsFilter)
        {
            RegisterJsonPartExpression(termsFilter);
            return this;
        }
        
        /// <summary>
        /// Filters documents where a specific field has a value in them.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/exists-filter.html
        /// </summary>
        public Filter<T> Exists(Func<ExistsFilter<T>, ExistsFilter<T>> existsFilter)
        {
            RegisterJsonPartExpression(existsFilter);
            return this;
        }

        /// <summary>
        /// A filter that allows to filter nested objects / docs.
        /// The filter is executed against the nested objects / docs as if they were indexed 
        /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-filter.html
        /// </summary>
        public Filter<T> Nested(Func<NestedFilter<T>, NestedFilter<T>> nestedFilter)
        {
            RegisterJsonPartExpression(nestedFilter);
            return this;
        }

        /// <summary>
        /// Filters documents with fields that have terms within a certain range.
        /// Similar to range query, except that it acts as a filter
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-filter.html
        /// </summary>
        public Filter<T> Range(Func<RangeFilter<T>, RangeFilter<T>> rangeFilter)
        {
            RegisterJsonPartExpression(rangeFilter);
            return this;
        }


        // http://www.elasticsearch.org/guide/reference/api/search/named-filters.html
        //TODO: fquery

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'filter': {0}".AltQuoteF(body);
        }
    }
}