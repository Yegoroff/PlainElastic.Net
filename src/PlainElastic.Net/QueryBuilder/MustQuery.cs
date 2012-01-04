namespace PlainElastic.Net.QueryBuilder
{
    internal class MustQuery<T> : Query<T>
    {
        #region Query Templates

        private const string queryTemplate = @"
    ""must"": [
{0}
    ]";

        #endregion


        public override string QueryTemplate
        {
            get { return queryTemplate; }
        }

    }
}