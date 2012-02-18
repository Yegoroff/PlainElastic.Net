namespace PlainElastic.Net.Queries
{
    public class MustQuery<T> : Query<T>
    {
        protected override string QueryTemplate
        {
            get { return " 'must': [ {0} ]"; }
        }

    }
}