namespace PlainElastic.Net.QueryBuilder
{
    public class ShouldQuery<T> : Query<T>
    {
        #region Query Templates

        private const string queryTemplate = @"
    ""should"": [
{0}
    ]";

        #endregion


        protected override string QueryTemplate
        {
            get { return queryTemplate; }
        }

    }
}