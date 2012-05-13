using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents with fields that have terms within a certain range. 
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-query.html
    /// </summary>
    public class RangeQuery<T>: RangeBase<T, RangeQuery<T>>
    {

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public RangeQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }
    }
}