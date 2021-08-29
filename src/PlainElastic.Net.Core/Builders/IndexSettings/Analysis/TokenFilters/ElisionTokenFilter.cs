using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter which removes elisions. For example, "l'avion" (the plane) will be tokenized as "avion" (plane).
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/elision-tokenfilter.html
    /// </summary>
    public class ElisionTokenFilter : NamedComponentBase<ElisionTokenFilter>
    {

        /// <summary>
        /// Sets a list of stop words articles.
        /// </summary>
        public ElisionTokenFilter Articles(IEnumerable<string> articles)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("articles", articles);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of stop words articles.
        /// </summary>
        public ElisionTokenFilter Articles(params string[] articles)
        {
            return Articles((IEnumerable<string>)articles);
        }


        protected override string GetComponentType()
        {
            return DefaultTokenFilters.elision.AsString();
        }
    }
}