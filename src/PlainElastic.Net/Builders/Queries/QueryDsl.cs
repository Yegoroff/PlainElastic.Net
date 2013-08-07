using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public class QueryDsl<T> : Query<T>
    {
        protected override string ApplyJsonTemplate(string body)
        {
            return "{0}".AltQuoteF(body);            
        }
    }
}