using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Analyzes the text and creates a phrase query out of the analyzed text and
    /// allows for prefix matches on the last term in the text.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
    /// </summary>
    public class TextPhrasePrefixQuery<T> : MatchQueryBase<T, TextPhrasePrefixQuery<T>>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'text_phrase_prefix': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'text_phrase_prefix': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}