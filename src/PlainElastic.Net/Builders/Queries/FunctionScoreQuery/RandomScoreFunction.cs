using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The random_score generates scores via a pseudo random number algorithm that is initialized with a seed.
    /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_random
    /// </summary>
    public class RandomScoreFunction<T> : QueryBase<RandomScoreFunction<T>>
    {

        /// <summary>
        /// Defines intial state of random number algorithm. 
        /// </summary>
        public RandomScoreFunction<T> Seed(double seed)
        {
            RegisterJsonPart("'seed': {0}", seed.AsString());
            return this;
        }


        protected override bool ForceJsonBuild()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'random_score': {{ {0} }}".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}