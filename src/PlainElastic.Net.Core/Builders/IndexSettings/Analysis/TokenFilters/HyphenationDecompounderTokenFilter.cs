using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type hyphenation_decompounder that allows to decompose compound words.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/compound-word-tokenfilter.html
    /// </summary>
    public class HyphenationDecompounderTokenFilter : DictionaryDecompounderTokenFilter
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.hyphenation_decompounder.AsString();
        }
    }
}