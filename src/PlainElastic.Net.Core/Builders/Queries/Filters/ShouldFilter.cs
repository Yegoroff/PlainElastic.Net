using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class ShouldFilter<T> : Filter<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return "'should': [ {0} ]".AltQuoteF(body);
        }

    }
}