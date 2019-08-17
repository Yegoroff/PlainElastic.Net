using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter allowing to define scripts as filters
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/script-filter.html
    /// </summary>
    public class ScriptFilter<T> : QueryBase<ScriptFilter<T>>
    {
        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScriptFilter<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScriptFilter<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public ScriptFilter<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }

        /// <summary>
        /// Sets the script used to filter documents.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public ScriptFilter<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public ScriptFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }

        /// <summary>
        /// Allows to specify Cache Key that will be used as the caching key for that filter.
        /// </summary>
        public ScriptFilter<T> CacheKey(string cacheKey)
        {
            RegisterJsonPart("'_cache_key': {0}", cacheKey.Quotate());
            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public ScriptFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
           return "{{ 'script': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}