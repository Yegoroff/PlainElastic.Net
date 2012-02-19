namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A filter that matches documents using AND boolean operator on other queries.
    /// This filter is more performant then bool filter. 
    /// Can be placed within queries that accept a filter.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/and-filter.html
    /// </summary>
    public class AndFilter<T> : Filter<T>
    {

        protected override string QueryTemplate
        {
            get { return " 'and': [ {0} ]"; }
        }

    }
}