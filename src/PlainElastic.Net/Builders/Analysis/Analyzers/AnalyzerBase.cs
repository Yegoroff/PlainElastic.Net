using System.Collections.Generic;

namespace PlainElastic.Net.IndexSettings
{
    public abstract class AnalyzerBase<TPart> : AnalysisComponentBase<TPart> where TPart : AnalyzerBase<TPart>
    {
        /// <summary>
        /// Sets analyzer aliases to have several registered lookup names associated with analyzer.
        /// </summary>
        public TPart Alias(IEnumerable<string> aliases)
        {
            RegisterJsonStringsProperty("alias", aliases);
            return (TPart)this;
        }

        /// <summary>
        /// Sets analyzer aliases to have several registered lookup names associated with analyzer.
        /// </summary>
        public TPart Alias(params string[] aliases)
        {
            return Alias((IEnumerable<string>) aliases);
        }
    }
}