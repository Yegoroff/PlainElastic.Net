using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class MustFilter<T> : Filter<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'must': [ {0} ]".AltQuoteF(body);
        }

    }
}