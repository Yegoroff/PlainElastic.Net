using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    public abstract class StopAnalyzerBase<TPart> : AnalyzerBase<TPart> where TPart : StopAnalyzerBase<TPart>
    {
        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public TPart Stopwords(IEnumerable<string> stopwords)
        {
            this.RegisterJsonStringsProperty("stopwords", stopwords);
            return (TPart)this;
        }

        /// <summary>
        /// Sets a list of stopword to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public TPart Stopwords(params string[] stopwords)
        {
            return (TPart)Stopwords((IEnumerable<string>)stopwords);
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