using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that allows  query allows to wrap another query and multiply its score by the provided boost_factor.
    /// This can sometimes be desired since boost value set on specific queries gets normalized, while this query boost factor does not.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/custom-boost-factor-query.html
    /// </summary>
    [Obsolete("Use FunctionScore instead")]
    public class CustomBoostFactorQuery<T> : QueryBase<CustomBoostFactorQuery<T>>
    {
        private bool hasValues;

        public CustomBoostFactorQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost factor for this query.
        /// </summary>
        public CustomBoostFactorQuery<T> BoostFactor(double boostFactor)
        {
            RegisterJsonPart("'boost_factor': {0}", boostFactor.AsString());

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'custom_boost_factor': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}