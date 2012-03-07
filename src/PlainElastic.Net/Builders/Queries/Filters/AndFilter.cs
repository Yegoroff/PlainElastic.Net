using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that matches documents using AND boolean operator on other queries.
    /// This filter is more performant then bool filter. 
    /// Can be placed within queries that accept a filter.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/and-filter.html
    /// </summary>
    public class AndFilter<T> : Filter<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'and': [ {0} ] }}".AltQuoteF(body);
        }

    }
}