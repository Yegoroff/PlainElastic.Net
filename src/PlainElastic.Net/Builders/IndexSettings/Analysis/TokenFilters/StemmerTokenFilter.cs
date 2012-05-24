using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter that stems words (similar to snowball, but with more options).
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stemmer-tokenfilter.html
    /// </summary>
    public class StemmerTokenFilter : NamedComponentBase<StemmerTokenFilter>
    {

        /// <summary>
        /// Sets the stemmer language.
        /// </summary>
        public StemmerTokenFilter Language(string language)
        {
            RegisterJsonPart("'language': {0}", language.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the stemmer language.
        /// </summary>
        public StemmerTokenFilter Language(StemmerTokenFilterLanguages language)
        {
            Language(language.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.stemmer.AsString();
        }
    }
}