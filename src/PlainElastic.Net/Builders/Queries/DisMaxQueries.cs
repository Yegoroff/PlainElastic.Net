namespace PlainElastic.Net.Queries
{
    public class DisMaxQueries<T>: Query<T>
    {
        protected override string ApplyJsonTemplate(string body)
        {
            return " 'queries': [ {0} ]".SmartQuoteF(body);
        }

    }
}