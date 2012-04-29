using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type stop that is built using a Lower Case Tokenizer, with Stop Token Filter.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-analyzer.html
    /// </summary>
    public class StopAnalyzer : AnalyzerBase<StopAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalyzers.stop.ToString();
        }


        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the english stop words.
        /// </summary>
        public StopAnalyzer Stopwords(IEnumerable<string> stopwords)
        {
            RegisterJsonStringsProperty("stopwords", stopwords);
            return this;
        }

        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the english stop words.
        /// </summary>
        public StopAnalyzer Stopwords(params string[] stopwords)
        {
            return Stopwords((IEnumerable<string>)stopwords);
        }


        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a stopwords file configuration.
        /// </summary>
        public StopAnalyzer StopwordsPath(string stopwordsPath)
        {
            RegisterJsonPart("'stopwords_path': {0}", stopwordsPath.Quotate());
            return this;
        }
    }
}