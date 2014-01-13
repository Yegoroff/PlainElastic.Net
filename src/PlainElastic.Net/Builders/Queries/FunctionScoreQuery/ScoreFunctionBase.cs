using System;

namespace PlainElastic.Net.Queries
{
    public abstract class ScoreFunctionBase<TFunctionQuery, T> : QueryBase<TFunctionQuery> where TFunctionQuery : ScoreFunctionBase<TFunctionQuery, T>
    {

        /// <summary>
        /// Allows you to wrap another query and customize the scoring of it
        /// optionally with a computation derived from other numeric field values in the doc 
        /// using a script expression.
        /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_script_score
        /// </summary>
        public TFunctionQuery ScriprtScore(Func<ScriptScoreFunction<T>, ScriptScoreFunction<T>> scriptScore)
        {
            RegisterJsonPartExpression(scriptScore);
            return (TFunctionQuery)this;
        }

        /// <summary>
        /// Allows you to multiply the score by the provided boost_factor.
        /// This can sometimes be desired since boost value set on specific queries gets normalized,
        /// while for this score function it does not.
        /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_boost_factor
        /// </summary>
        public TFunctionQuery BoostFactor(Func<BoostFactorFunction<T>, BoostFactorFunction<T>> boostFactor)
        {
            RegisterJsonPartExpression(boostFactor);
            return (TFunctionQuery)this;
        }

        /// <summary>
        /// The random_score generates scores via a pseudo random number algorithm that is initialized with a seed.
        /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_random
        /// </summary>
        public TFunctionQuery RandomScore(Func<RandomScoreFunction<T>, RandomScoreFunction<T>> randomScore)
        {
            RegisterJsonPartExpression(randomScore);
            return (TFunctionQuery)this;
        }

        /// <summary>
        /// Score a document with a function that decays depending on the distance of a numeric field value of the document
        /// from a user given origin. This is similar to a range query, but with smooth edges instead of boxes.
        /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_decay_functions
        /// </summary>
        public TFunctionQuery DecayFunction(Func<DecayFunction<T>, DecayFunction<T>> decayFunction)
        {
            RegisterJsonPartExpression(decayFunction);
            return (TFunctionQuery)this;
        }
    }
}