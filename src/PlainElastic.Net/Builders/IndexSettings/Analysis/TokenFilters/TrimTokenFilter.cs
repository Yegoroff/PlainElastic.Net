using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The trim token filter trims surrounding whitespaces around a token.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/trim-tokenfilter.html
    /// </summary>
    public class TrimTokenFilter : NamedComponentBase<TrimTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.trim.AsString();
        }
    }
}