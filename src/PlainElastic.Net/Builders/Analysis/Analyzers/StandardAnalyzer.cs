using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// An analyzer of type standard that is built of using
    /// Standard Tokenizer, with Standard Token Filter, Lower Case Token Filter, and Stop Token Filter.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-analyzer.html
    /// </summary>
    public class StandardAnalyzer : AnalyzerBase<StandardAnalyzer>
    {
        protected override string GetComponentType()
        {
            return DefaultAnalizers.standard.ToString();
        }


        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the english stop words.
        /// </summary>
        public StandardAnalyzer Stopwords(IEnumerable<string> stopwords)
        {
            RegisterJsonStringsProperty("stopwords", stopwords);
            return this;
        }

        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the english stop words.
        /// </summary>
        public StandardAnalyzer Stopwords(params string[] stopwords)
        {
            return Stopwords((IEnumerable<string>)stopwords);
        }

        /// <summary>
        /// Sets the maximum token length. If a token is seen that exceeds this length then it is discarded.
        /// Defaults to 255.
        /// </summary>
        public StandardAnalyzer MaxTokenLength(int maxTokenLength = 255)
        {
            RegisterJsonPart("'max_token_length': {0}", maxTokenLength.AsString());
            return this;
        }
    }
}