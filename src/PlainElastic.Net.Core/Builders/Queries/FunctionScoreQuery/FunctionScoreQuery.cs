using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that allows you to modify the score of documents that are retrieved by a query. 
    /// This can be useful if, for example, a score function is computationally expensive 
    /// and it is sufficient to compute the score on a filtered set of documents.
    /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html
    /// </summary>
    public class FunctionScoreQuery<T> : QueryBase<FunctionScoreQuery<T>>
    {
        private bool hasValues;

        public FunctionScoreQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        public FunctionScoreQuery<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }


        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public FunctionScoreQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// Defines how newly computed score is combined with the score of the query.
        /// </summary>
        public FunctionScoreQuery<T> BoostMode(FunctionBoostMode boostMode)
        {
            RegisterJsonPart("'boost_mode': {0}", boostMode.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Restricts the new score to not exceed a certain limit.
        /// </summary>
        public FunctionScoreQuery<T> MaxBoost(double maxBoost)
        {
            RegisterJsonPart("'max_boost': {0}", maxBoost.AsString());
            return this;
        }


        /// <summary>
        /// Specifies how the computed scores are combined
        /// </summary>
        public FunctionScoreQuery<T> ScoreMode(FunctionScoreMode scoreMode = FunctionScoreMode.first)
        {
            RegisterJsonPart("'score_mode': {0}", scoreMode.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Defines function that compute a new score for each document returned by the query.
        /// </summary>
        public FunctionScoreQuery<T> Function(Func<ScoreFunction<T>, ScoreFunction<T>> function)
        {
            RegisterJsonPartExpression(function);
            return this;
        }

        /// <summary>
        /// Defines functions that can be combined to calculate a new score for each document returnaed by the query.
        /// You can specify filter that will apply the function only if a document matches a given filter.
        /// </summary>
        public FunctionScoreQuery<T> Functions(Func<FilteredScoreFunctions<T>, FilteredScoreFunctions<T>> functions)
        {
            RegisterJsonPartExpression(functions);
            return this;
        } 




        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'function_score': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}