using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    public abstract class AnalyzerBase<TPart> : NamedComponentBase<TPart> where TPart : AnalyzerBase<TPart>
    {
        /// <summary>
        /// Sets analyzer aliases to have several registered lookup names associated with analyzer.
        /// </summary>
        public TPart Alias(IEnumerable<string> aliases)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("alias", aliases);
            RegisterJsonPart(propertyJson);

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