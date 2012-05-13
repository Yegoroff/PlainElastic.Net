using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class MustNotQuery<T> : Query<T>
    {
        protected override string ApplyJsonTemplate(string body)
        {
            return "'must_not': [ {0} ]".AltQuoteF(body);
        }

    }
}