using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type standard that normalizes tokens extracted with the Standard Tokenizer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/standard-tokenfilter.html
    /// </summary>
    public class StandardTokenFilter : NamedComponentBase<StandardTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.standard.AsString();
        }
    }
}