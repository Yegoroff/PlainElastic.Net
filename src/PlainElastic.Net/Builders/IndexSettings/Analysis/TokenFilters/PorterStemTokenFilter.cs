using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type porterStem that transforms the token stream as per the Porter stemming algorithm.
    /// Note, the input to the stemming filter must already be in lower case, so you will need to use Lower Case Token Filter
    /// or Lower Case Tokenizer farther down the Tokenizer chain in order for this to work properly!
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/porterstem-tokenfilter.html
    /// </summary>
    public class PorterStemTokenFilter : NamedComponentBase<PorterStemTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.porterStem.AsString();
        }
    }
}