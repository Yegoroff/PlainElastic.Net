using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Represents NoMatchFilter part of Indices filter.
    /// </summary>
    public class NoMatchFilter<T> : Filter<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'no_match_filter': {{ {0} }}".AltQuoteF(body);
        }

    }
}