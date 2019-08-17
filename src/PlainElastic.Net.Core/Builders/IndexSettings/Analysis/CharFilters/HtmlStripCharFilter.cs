using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A char filter of type html_strip stripping out HTML elements from an analyzed text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/htmlstrip-charfilter.html
    /// </summary>
    public class HtmlStripCharFilter : NamedComponentBase<HtmlStripCharFilter>
    {
        protected override string GetComponentType()
        {
            return DefaultCharFilters.html_strip.AsString();
        }
    }
}