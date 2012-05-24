using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type lowercase that normalizes token text to lower case.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/lowercase-tokenfilter.html
    /// </summary>
    public class LowercaseTokenFilter : NamedComponentBase<LowercaseTokenFilter>
    {

        /// <summary>
        /// Sets non-Latin lowercase filter language.
        /// </summary>
        public LowercaseTokenFilter Language(string language)
        {
            RegisterJsonPart("'language': {0}", language.Quotate());
            return this;
        }

        /// <summary>
        /// Sets non-Latin lowercase filter language.
        /// </summary>
        public LowercaseTokenFilter Language(LowercaseTokenFilterLanguages language)
        {
            Language(language.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.lowercase.AsString();
        }
    }
}