using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type nGram that builds N-characters substrings from text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/ngram-tokenfilter.html
    /// </summary>
    public class NGramTokenFilter : NGramComponentBase<NGramTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.nGram.AsString();
        }
    }
}