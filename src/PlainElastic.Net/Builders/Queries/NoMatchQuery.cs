using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Represents NoMatchQuery part of Indices query.
    /// </summary>
    public class NoMatchQuery<T> : Query<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'no_match_query': {{ {0} }}".AltQuoteF(body);
        }

    }
}