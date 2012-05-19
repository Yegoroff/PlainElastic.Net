using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The kstem token filter is a high performance filter for english.
    /// All terms must already be lowercased (use lowercase filter) for this filter to work correctly.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/kstem-tokenfilter.html
    /// </summary>
    public class KstemTokenFilter : NamedComponentBase<KstemTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.kstem.AsString();
        }
    }
}