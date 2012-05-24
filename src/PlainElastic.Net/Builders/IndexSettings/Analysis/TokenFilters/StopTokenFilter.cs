using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type stop that removes stop words from token streams.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/stop-tokenfilter.html
    /// </summary>
    public class StopTokenFilter : NamedComponentBase<StopTokenFilter>
    {

        /// <summary>
        /// Sets a list of stopwords to initialize the filter with.
        /// Defaults to English stop words.
        /// stopwords allow for custom language specific expansion of default stopwords. It follows the _lang_ notation.
        /// </summary>
        public StopTokenFilter Stopwords(IEnumerable<string> stopwords)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("stopwords", stopwords);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the filter with.
        /// Defaults to English stop words.
        /// stopwords allow for custom language specific expansion of default stopwords. It follows the _lang_ notation.
        /// </summary>
        public StopTokenFilter Stopwords(params string[] stopwords)
        {
            return Stopwords((IEnumerable<string>)stopwords);
        }

        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a stopwords file configuration.
        /// </summary>
        public StopTokenFilter StopwordsPath(string stopwordsPath)
        {
            RegisterJsonPart("'stopwords_path': {0}", stopwordsPath.Quotate());
            return this;
        }

        /// <summary>
        /// Sets flag indicating that token positions should record the removed stop words.
        /// Defaults to true.
        /// </summary>
        public StopTokenFilter EnablePositionIncrements(bool enablePositionIncrements = true)
        {
            RegisterJsonPart("'enable_position_increments': {0}", enablePositionIncrements.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag indicating that filter should lower case all words first.
        /// Defaults to false.
        /// </summary>
        public StopTokenFilter IgnoreCase(bool ignoreCase = false)
        {
            RegisterJsonPart("'ignore_case': {0}", ignoreCase.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.stop.AsString();
        }
    }
}