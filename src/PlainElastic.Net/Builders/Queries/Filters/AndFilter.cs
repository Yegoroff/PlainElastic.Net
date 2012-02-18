namespace PlainElastic.Net.Queries
{
    public class AndFilter<T> : Filter<T>
    {

        protected override string QueryTemplate
        {
            get { return " 'and': [ {0} ]"; }
        }

    }
}