using System;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Queries
{
    public class Filter<T> : CompositeQueryBase
    {

        protected override string QueryTemplate
        {
            get { return " 'filter': {{ {0} }}"; }
        }


        /// <summary>
        /// A filter that matches documents using AND boolean operator on other queries.
        /// This filter is more performant then bool filter. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/and-filter.html
        /// </summary>
        public Filter<T> And (Func<AndFilter<T>, Filter<T>> andFilter)
        {
            RegisterQueryExpression(andFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields that contain a term (not analyzed).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-filter.html
        /// </summary>
        public Filter<T> Term(Func<TermFilter<T>, TermFilter<T>> termFilter)
        {
            RegisterQueryExpression(termFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields that match any of the provided terms (not analyzed).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/terms-filter.html
        /// </summary>
        public Filter<T> Terms(Func<TermsFilter<T>, TermsFilter<T>> termsFilter)
        {
            RegisterQueryExpression(termsFilter);
            return this;
        }
        
        /// <summary>
        /// Filters documents where a specific field has a value in them.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/exists-filter.html
        /// </summary>
        public Filter<T> Exists(Func<ExistsFilter<T>, ExistsFilter<T>> existsFilter)
        {
            RegisterQueryExpression(existsFilter);
            return this;
        }

    }
}