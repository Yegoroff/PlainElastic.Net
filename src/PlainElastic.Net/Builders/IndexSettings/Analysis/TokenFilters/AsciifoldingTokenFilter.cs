using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A token filter of type asciifolding that converts alphabetic, numeric, and symbolic Unicode characters
    /// which are not in the first 127 ASCII characters (the "Basic Latin" Unicode block) into their ASCII equivalents, if one exists.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/asciifolding-tokenfilter.html
    /// </summary>
    public class AsciifoldingTokenFilter : NamedComponentBase<AsciifoldingTokenFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenFilters.asciifolding.AsString();
        }
    }
}