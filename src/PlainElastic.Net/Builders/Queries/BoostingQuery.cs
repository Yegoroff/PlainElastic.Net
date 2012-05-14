using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that can be used to effectively demote results that match a given query. 
    /// Unlike the “NOT” clause in bool query, this still selects documents 
    /// that contain undesirable terms, but reduces their overall score.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/boosting-query.html
    /// </summary>
    public class BoostingQuery<T> : QueryBase<BoostingQuery<T>>
    {
        private bool hasRequiredParts;


        /// <summary>
        /// The positive part of boosting query.
        /// </summary>
        public BoostingQuery<T> Positive(Func<PositiveQuery<T>, Query<T>> positiveQuery)
        {
            var result = RegisterJsonPartExpression(positiveQuery);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The negative part of boosting query.
        /// </summary>
        public BoostingQuery<T> Negative(Func<NegativeQuery<T>, Query<T>> negativeQuery)
        {
            var result = RegisterJsonPartExpression(negativeQuery);
            hasRequiredParts = hasRequiredParts || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost value of the positive query. Defaults to 1.0.
        /// </summary>
        public BoostingQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the negative query.
        /// </summary>
        public BoostingQuery<T> NegativeBoost(double negativeBoost)
        {
            RegisterJsonPart("'negative_boost': {0}", negativeBoost.AsString());
            return this;
        }



        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'boosting': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}