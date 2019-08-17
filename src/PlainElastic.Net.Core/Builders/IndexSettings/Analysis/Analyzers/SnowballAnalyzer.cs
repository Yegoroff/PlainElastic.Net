using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type snowball that uses the standard tokenizer, with standard filter, lowercase filter, stop filter, and snowball filter.
    /// The Snowball Analyzer is a stemming analyzer from Lucene that is originally based on the snowball project from snowball.tartarus.org.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-analyzer.html
    /// </summary>
    public class SnowballAnalyzer : StopwordsAnalyzerBase<SnowballAnalyzer>
    {

        /// <summary>
        /// Sets the Snowball-generated stemmer language.
        /// Defaults to English.
        /// </summary>
        public SnowballAnalyzer Language(string language = "English")
        {
            RegisterJsonPart("'language': {0}", language.Quotate());
            return this;
        }

        /// <summary>
        /// Sets the Snowball-generated stemmer language.
        /// Defaults to English.
        /// </summary>
        public SnowballAnalyzer Language(SnowballLanguages language = SnowballLanguages.English)
        {
            return Language(language.AsString());
        }


        protected override string GetComponentType()
        {
            return DefaultAnalyzers.snowball.AsString();
        }
    }
}