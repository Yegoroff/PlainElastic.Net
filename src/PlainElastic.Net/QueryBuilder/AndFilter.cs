namespace PlainElastic.Net.QueryBuilder
{
    public class AndFilter<T> : Filter<T>
    {

        #region Query Templates

        private const string filterTemplate = @"
    ""and"": [ 
{0}
    ]";

        #endregion


        public override string QueryTemplate
        {
            get { return filterTemplate; }
        }

    }
}