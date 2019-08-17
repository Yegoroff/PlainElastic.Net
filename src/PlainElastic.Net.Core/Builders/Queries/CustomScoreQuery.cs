using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// A query that allows to wrap another query and customize the scoring of it 
    /// optionally with a computation derived from other field values in the doc (numeric ones) using script expression. 
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/custom-score-query.html
    /// </summary>
    [Obsolete("Use Function Score")]
    public class CustomScoreQuery<T> : QueryBase<CustomScoreQuery<T>>
    {
        private bool hasValues;

        public CustomScoreQuery<T> Query(Func<Query<T>, Query<T>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public CustomScoreQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public CustomScoreQuery<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public CustomScoreQuery<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }


        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public CustomScoreQuery<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }

        /// <summary>
        /// Sets the script used to calculate score value.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public CustomScoreQuery<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }

        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'custom_score': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}