namespace PlainElastic.Net.QueryBuilder
{
    public class AndFilter<T> : Filter<T>
    {
        private const string filterTemplate = " \"and\": [ {0} ]";


        protected override string QueryTemplate
        {
            get { return filterTemplate; }
        }

    }
}