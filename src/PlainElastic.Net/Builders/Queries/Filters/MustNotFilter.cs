using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class MustNotFilter<T> : Filter<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'must_not': [ {0} ]".AltQuoteF(body);
        }

    }
}