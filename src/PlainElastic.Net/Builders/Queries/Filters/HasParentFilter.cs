using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The has_parent filter accepts a query or filterand the parent type to run against,
    /// The filter is executed in the parent document space, which is specified by the parent type. 
    /// This filer return child documents which associated parents have matched.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-parent-filter/
    /// </summary>

    public class HasParentFilter<T, TParent> : QueryBase<HasParentFilter<T, TParent>>
    {
        private bool hasValues;

        /// <summary>
        /// The child type to query against. 
        /// The parent type to return is automatically detected based on the mappings.
        /// </summary>
        public HasParentFilter<T, TParent> ParentType(string parentType)
        {
            RegisterJsonPart("'parent_type': {0}", parentType.Quotate());
            return this;
        }

        /// <summary>
        /// The query to run against parent documents.
        /// </summary>
        public HasParentFilter<T, TParent> Query(Func<Query<TParent>, Query<TParent>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The filter to run against parent documents.
        /// </summary>
        public HasParentFilter<T, TParent> Filter(Func<Filter<TParent>, Filter<TParent>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }



        /// <summary>
        /// Allows to run facets on the same scope name that will work against the child documents.
        /// </summary>
        public HasParentFilter<T, TParent> Scope(string scope)
        {
            RegisterJsonPart("'_scope': {0}", scope.Quotate());
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public HasParentFilter<T, TParent> Name(string filterName)
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
            return "{{ 'has_parent': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}