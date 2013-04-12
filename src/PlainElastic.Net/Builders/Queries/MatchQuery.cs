using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A family of match queries that accept text/numerics/dates, analyzes it, and constructs a query out of it.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/match-query/
    /// </summary>
    public class MatchQuery<T> : MatchQueryBase<T, MatchQuery<T>>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'match': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'match': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}