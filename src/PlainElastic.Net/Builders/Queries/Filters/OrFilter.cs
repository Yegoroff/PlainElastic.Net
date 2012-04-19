using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that matches documents using OR boolean operator on other queries. 
    /// This filter is more performant then bool filter. 
    /// Can be placed within queries that accept a filter.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/or-filter.html
    /// </summary>
    public class OrFilter<T> : Filter<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'or': [ {0} ] }}".AltQuoteF(body);
        }

    }
}