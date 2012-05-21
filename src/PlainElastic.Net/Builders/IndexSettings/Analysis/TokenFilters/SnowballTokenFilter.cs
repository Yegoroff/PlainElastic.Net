using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter that stems words using a Snowball-generated stemmer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-tokenfilter.html
    /// </summary>
    public class SnowballTokenFilter : NamedComponentBase<SnowballTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.snowball.AsString();
        }


        /// <summary>
        /// Sets the Snowball-generated stemmer language.
        /// Defaults to "English".
        /// </summary>
        public SnowballTokenFilter Language(string language = "English")
        {
            RegisterJsonPart("'language': {0}", language.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the Snowball-generated stemmer language.
        /// Defaults to English.
        /// </summary>
        public SnowballTokenFilter Language(SnowballLanguages language = SnowballLanguages.English)
        {
            RegisterJsonPart("'language': {0}", language.AsString().Quotate());
            return this;
        }
    }
}