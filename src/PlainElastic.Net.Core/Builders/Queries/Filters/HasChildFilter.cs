using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// The has_child filter accepts a query and the child type to run against,
    /// and results in parent documents that have child docs matching the query.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-child-filter.html
    /// </summary>
    public class HasChildFilter<T, TChild> : QueryBase<HasChildFilter<T, TChild>>
    {
        private bool hasValues;

        /// <summary>
        /// The child type to query against. 
        /// The parent type to return is automatically detected based on the mappings.
        /// </summary>
        public HasChildFilter<T, TChild> Type(string type)
        {
            RegisterJsonPart("'type': {0}", type.Quotate());
            return this;
        }

        /// <summary>
        /// The query to run against child documents.
        /// </summary>
        public HasChildFilter<T, TChild> Query(Func<Query<TChild>, Query<TChild>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The filter to run against child documents.
        /// </summary>
        public HasChildFilter<T, TChild> Filter(Func<Filter<TChild>, Filter<TChild>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }



        /// <summary>
        /// Allows to run facets on the same scope name that will work against the child documents.
        /// </summary>
        public HasChildFilter<T, TChild> Scope(string scope)
        {
            RegisterJsonPart("'_scope': {0}", scope.Quotate());
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public HasChildFilter<T, TChild> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }

        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'has_child': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}