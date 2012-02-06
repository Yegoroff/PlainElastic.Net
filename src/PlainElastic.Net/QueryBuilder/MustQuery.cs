namespace PlainElastic.Net.QueryBuilder
{
    public class MustQuery<T> : Query<T>
    {
        #region Query Templates

        private const string queryTemplate = @"
    ""must"": [
{0}
    ]";

        #endregion


        protected override string QueryTemplate
        {
            get { return queryTemplate; }
        }

    }
}