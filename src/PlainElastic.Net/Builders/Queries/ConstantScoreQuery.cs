using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that wraps a filter or another query and simply returns a constant score equal 
    /// to the query boost for every document in the filter. Maps to Lucene ConstantScoreQuery.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/constant-score-query.html
    /// </summary>    
    public class ConstantScoreQuery<T> : QueryBase<ConstantScoreQuery<T>>
    {
        private bool hasValues;

        public ConstantScoreQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        public ConstantScoreQuery<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            var result = RegisterJsonPartExpression(filter);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public ConstantScoreQuery<T> Boost(double boost = 1)
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
            return "{{ 'constant_score': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}