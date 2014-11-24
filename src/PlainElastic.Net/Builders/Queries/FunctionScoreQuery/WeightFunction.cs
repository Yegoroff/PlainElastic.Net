using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows you to multiply the score by the provided weight.
    /// This can sometimes be desired since boost value set on specific queries gets normalized,
    /// while for this score function it does not.
    /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#weight
    /// </summary>
    public class WeightFunction<T> : QueryBase<WeightFunction<T>>
    {
        /// <summary>
        /// Allows you to multiply the score by the provided weight.
        /// </summary>
        public WeightFunction<T> Weight(double boostFactor)
        {
            RegisterJsonPart("'weight': {0}", boostFactor.AsString());
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