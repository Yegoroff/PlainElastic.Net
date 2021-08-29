using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type edgeNGram that builds N-characters substrings from text. Substrings are built from one side of a text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenfilter.html
    /// </summary>
    public class EdgeNGramTokenFilter : EdgeNGramComponentBase<EdgeNGramTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.edgeNGram.AsString();
        }
    }
}