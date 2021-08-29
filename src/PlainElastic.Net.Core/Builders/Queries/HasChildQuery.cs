using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// The has_child query accepts a query and the child type to run against,
    /// and results in parent documents that have child docs matching the query.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-child-query.html
    /// </summary>
    public class HasChildQuery<T, TChild> : QueryBase<HasChildQuery<T, TChild>>
    {
        private bool hasValues;

        /// <summary>
        /// The child type to query against. 
        /// The parent type to return is automatically detected based on the mappings.
        /// </summary>
        public HasChildQuery<T, TChild> Type(string type)
        {
            RegisterJsonPart("'type': {0}", type.Quotate());
            return this;
        }


        /// <summary>
        /// The score type for the has_child query.
        /// The supported score types are "max", "sum", "avg" or "none". 
        /// The default is "none" and yields the same behaviour as in previous versions.
        /// If the score type is set to another value than "none", the scores of all the matching child documents are aggregated into the associated parent documents.
        /// </summary>
        public HasChildQuery<T, TChild> ScoreType(HasChildScoreType scoreType)
        {
            RegisterJsonPart("'score_type': {0}", scoreType.AsString().Quotate());
            return this;
        }
        

        /// <summary>
        /// The query to run against child documents.
        /// </summary>
        public HasChildQuery<T, TChild> Query(Func<Query<TChild>, Query<TChild>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public HasChildQuery<T, TChild> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }

        /// <summary>
        /// Allows to run facets on the same scope name that will work against the child documents.
        /// </summary>
        public HasChildQuery<T, TChild> Scope(string scope)
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