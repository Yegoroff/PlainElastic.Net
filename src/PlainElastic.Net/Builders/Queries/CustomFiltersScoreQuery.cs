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

        public CustomFiltersScoreQuery<T> Filters(Func<FiltersQuery<T>, FiltersQuery<T>> filters)
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
            RegisterJsonPart("'score_mode': {0}", scoreMode.ToString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for filters boost calculation scripts.
        /// </summary>
        public CustomFiltersScoreQuery<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets parameters used for filters boost calculation scripts.
        /// </summary>
        public CustomFiltersScoreQuery<T> Params(string paramsFormat, params string[] args)
        {
            RegisterJsonPart("'params': {0}", paramsFormat.AltQuoteF(args));
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