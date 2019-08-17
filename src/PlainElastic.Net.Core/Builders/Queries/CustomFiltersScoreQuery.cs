using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that allows to execute a query, and if the hit matches a provided filter (ordered),
    /// use either a boost or a script associated with it to compute the score. 
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/custom-filters-score-query.html
    /// </summary>
    public class CustomFiltersScoreQuery<T> : QueryBase<CustomFiltersScoreQuery<T>>
    {
        private bool hasQuery;


        public CustomFiltersScoreQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var queryPart = RegisterJsonPartExpression(query);

            if (!queryPart.GetIsEmpty())
            {
                hasQuery = true;
            }

            return this;
        }

        public CustomFiltersScoreQuery<T> Filters(Func<ScoredFilters<T>, ScoredFilters<T>> filters)
        {
            RegisterJsonPartExpression(filters);
            return this;
        }

        /// <summary>
        /// Controls how multiple matching filters control the score.
        /// By default, it is set to first which means the first matching filter will control the score of the result.
        /// </summary>
        public CustomFiltersScoreQuery<T> ScoreMode(CustomFiltersScoreMode scoreMode = CustomFiltersScoreMode.first)
        {
            RegisterJsonPart("'score_mode': {0}", scoreMode.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for filters boost calculation scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public CustomFiltersScoreQuery<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for filters boost calculation scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public CustomFiltersScoreQuery<T> Lang(ScriptLangs lang)
        {
            return Lang( lang.AsString());
        }


        /// <summary>
        /// Sets parameters used for filters boost calculation scripts.
        /// </summary>
        public CustomFiltersScoreQuery<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }


        /// <summary>
        /// Sets the boost for this query. Documents matching this query will (in addition to the normal weightings) 
        /// have their score multiplied by the boost provided.
        /// </summary>
        public CustomFiltersScoreQuery<T> Boost(double boost)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasQuery;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'custom_filters_score': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}