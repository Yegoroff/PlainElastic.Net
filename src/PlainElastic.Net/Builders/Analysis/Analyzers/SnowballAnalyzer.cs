using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type snowball that uses the standard tokenizer, with standard filter, lowercase filter, stop filter, and snowball filter.
    /// The Snowball Analyzer is a stemming analyzer from Lucene that is originally based on the snowball project from snowball.tartarus.org.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/snowball-analyzer.html
    /// </summary>
    public class SnowballAnalyzer : AnalyzerBase<SnowballAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalyzers.snowball.ToString();
        }


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
            return Language(language.ToString());
        }


        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public SnowballAnalyzer Stopwords(IEnumerable<string> stopwords)
        {
            RegisterJsonStringsProperty("stopwords", stopwords);
            return this;
        }

        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public SnowballAnalyzer Stopwords(params string[] stopwords)
        {
            return Stopwords((IEnumerable<string>)stopwords);
        }


        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a stopwords file configuration.
        /// </summary>
        public SnowballAnalyzer StopwordsPath(string stopwordsPath)
        {
            RegisterJsonPart("'stopwords_path': {0}", stopwordsPath.Quotate());
            return this;
        }
    }
}