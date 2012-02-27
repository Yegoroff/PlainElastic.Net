namespace PlainElastic.Net.Queries
{
    public class ShouldQuery<T> : Query<T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return " 'should': [ {0} ]".SmartQuoteF(body);
        }

    }
}