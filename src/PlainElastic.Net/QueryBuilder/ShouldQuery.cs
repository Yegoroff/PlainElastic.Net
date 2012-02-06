namespace PlainElastic.Net.QueryBuilder
{
    public class ShouldQuery<T> : Query<T>
    {
        private const string queryTemplate = " \"should\": [ {0} ]";


        protected override string QueryTemplate
        {
            get { return queryTemplate; }
        }

    }
}