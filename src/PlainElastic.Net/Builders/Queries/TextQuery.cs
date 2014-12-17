using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A family of text queries that accept text, analyzes it, and constructs a query out of it.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
    /// </summary>
    [Obsolete("Use MatchQuery instead")]
    public class TextQuery<T> : MatchQueryBase<T, TextQuery<T>>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'text': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'text': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}