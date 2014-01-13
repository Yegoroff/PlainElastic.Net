using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows you to wrap another query and customize the scoring of it
    /// optionally with a computation derived from other numeric field values in the doc 
    /// using a script expression.
    /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html#_script_score
    /// </summary>
    public class ScriptScoreFunction<T> : QueryBase<ScriptScoreFunction<T>>
    {

        /// <summary>
        /// Sets the script used to calculate score value.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScriptScoreFunction<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScriptScoreFunction<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScriptScoreFunction<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }


        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public ScriptScoreFunction<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'script_score': {{ {0} }}".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}