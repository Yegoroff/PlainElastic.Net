namespace PlainElastic.Net.Queries
{
    public class MustNotQuery<T> : Query<T>
    {
        protected override string QueryTemplate
        {
            get { return " 'must_not': [ {0} ]"; }
        }

    }
}