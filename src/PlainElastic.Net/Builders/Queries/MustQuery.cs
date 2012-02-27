namespace PlainElastic.Net.Queries
{
    public class MustQuery<T> : Query<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return " 'must': [ {0} ]".SmartQuoteF(body);
        }

    }
}