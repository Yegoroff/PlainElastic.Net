using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type reverse that simply reverses the tokens.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/reverse-tokenfilter.html
    /// </summary>
    public class ReverseTokenFilter : NamedComponentBase<ReverseTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.reverse.AsString();
        }
    }
}