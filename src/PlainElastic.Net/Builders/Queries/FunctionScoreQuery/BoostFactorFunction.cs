using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows you to multiply the score by the provided boost_factor.
    /// This can sometimes be desired since boost value set on specific queries gets normalized,
    /// while for this score function it does not.
    /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_boost_factor
    /// </summary>
    public class BoostFactorFunction<T> : QueryBase<BoostFactorFunction<T>>
    {

        /// <summary>
        /// Allows you to multiply the score by the provided boost_factor.
        /// </summary>
        public BoostFactorFunction<T> BoostFactor(double boostFactor)
        {
            RegisterJsonPart("'boost_factor': {0}", boostFactor.AsString());
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return body;
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}