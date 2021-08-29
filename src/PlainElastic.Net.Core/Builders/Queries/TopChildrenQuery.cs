using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The top_children query runs the child query with an estimated hits size,
    /// and out of the hit docs, aggregates it into parent docs. 
    /// If there aren’t enough parent docs matching the requested from/size search request,
    /// then it is run again with a wider (more hits) search.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/top-children-query.html
    /// </summary>
    public class TopChildrenQuery<T> : QueryBase<TopChildrenQuery<T>>
    {
        private bool hasValues;
        

        /// <summary>
        /// The child type to query against. 
        /// </summary>
        public TopChildrenQuery<T> Type(string type)
        {
            RegisterJsonPart("'type': {0}", type.Quotate());
            return this;
        }

        /// <summary>
        /// The query to run against child documents.
        /// </summary>
        public TopChildrenQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Allows to run facets on the same scope name that will work against the child documents.
        /// </summary>
        public TopChildrenQuery<T> Scope(string scope)
        {
            RegisterJsonPart("'_scope': {0}", scope.Quotate());
            return this;
        }

        /// <summary>
        /// Controls how to compute the score.
        /// Defaults to max.
        /// </summary>
        public TopChildrenQuery<T> Score(TopChildrenScoreMode score = TopChildrenScoreMode.max)
        {
            RegisterJsonPart("'score': {0}", score.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Controls the multiplication factor of the initial hits required from the child query over the main query request.
        /// Defaults to 5.
        /// </summary>
        public TopChildrenQuery<T> Factor(int factor = 5)
        {
            RegisterJsonPart("'factor': {0}", factor.AsString());
            return this;
        }

        /// <summary>
        /// Sets the incremental factor when the query needs to be re-run in order to fetch more results.
        /// Defaults to 2.
        /// </summary>
        public TopChildrenQuery<T> IncrementalFactor(int incrementalFactor = 2)
        {
            RegisterJsonPart("'incremental_factor': {0}", incrementalFactor.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public TopChildrenQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'top_children': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}