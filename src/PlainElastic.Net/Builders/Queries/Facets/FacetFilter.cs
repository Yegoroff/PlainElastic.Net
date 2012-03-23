using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// All facets can be configured with an additional filter, which will reduce the documents they use for computing results.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/index.html
    /// </summary>
    public class FacetFilter<T> : Filter<T>
    {
        protected override string ApplyJsonTemplate(string body)
        {
            return "'facet_filter': {0}".AltQuoteF(body);
        }
    }
}