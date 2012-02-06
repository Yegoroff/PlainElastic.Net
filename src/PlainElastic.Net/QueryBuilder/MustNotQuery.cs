namespace PlainElastic.Net.QueryBuilder
{
    public class MustNotQuery<T> : Query<T>
    {
        private const string queryTemplate = " \"must_not\": [ {0} ]";


        protected override string QueryTemplate
        {
            get { return queryTemplate; }
        }

    }
}