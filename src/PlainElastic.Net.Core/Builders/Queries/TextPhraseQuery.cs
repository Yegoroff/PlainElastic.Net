using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Analyzes the text and creates a phrase query out of the analyzed text.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
    /// </summary>
    public class TextPhraseQuery<T> : MatchQueryBase<T, TextPhraseQuery<T>>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'text_phrase': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'text_phrase': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}