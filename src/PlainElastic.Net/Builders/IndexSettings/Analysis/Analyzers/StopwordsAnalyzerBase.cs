using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    public abstract class StopwordsAnalyzerBase<TPart> : AnalyzerBase<TPart> where TPart : StopwordsAnalyzerBase<TPart>
    {
        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public TPart Stopwords(IEnumerable<string> stopwords)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("stopwords", stopwords);
            RegisterJsonPart(propertyJson);
            return (TPart)this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public TPart Stopwords(params string[] stopwords)
        {
            return Stopwords((IEnumerable<string>)stopwords);
        }


        /// <summary>
        /// Sets a path (either relative to config location, or absolute) to a stopwords file configuration.
        /// </summary>
        public TPart StopwordsPath(string stopwordsPath)
        {
            RegisterJsonPart("'stopwords_path': {0}", stopwordsPath.Quotate());
            return (TPart)this;
        }
    }
}