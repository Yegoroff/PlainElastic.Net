using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// The has_child query accepts a query and the child type to run against,
    /// and results in parent documents that have child docs matching the query.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-child-query.html
    /// </summary>
    public class HasChildQuery<T> : QueryBase<HasChildQuery<T>>
    {
        private bool hasValues;

        /// <summary>
        /// The child type to query against. 
        /// The parent type to return is automatically detected based on the mappings.
        /// </summary>
        public HasChildQuery<T> Type(string type)
        {
            RegisterJsonPart("'type': {0}", type.Quotate());
            return this;
        }

        /// <summary>
        /// The query to run against child documents.
        /// </summary>
        public HasChildQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public HasChildQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }

        /// <summary>
        /// Allows to run facets on the same scope name that will work against the child documents.
        /// </summary>
        public HasChildQuery<T> Scope(string scope)
        {
            RegisterJsonPart("'_scope': {0}", scope.Quotate());
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