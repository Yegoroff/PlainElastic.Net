using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents with fields that have terms within a certain range. 
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-query.html
    /// </summary>
    public class RangeQuery<T>: RangeBase<T, RangeQuery<T>>
    {

        public RangeQuery<T> Boost(double boost)
        {
            RegisterJsonPart("'boost': {0}".AltQuoteF(boost.AsString()));
            return this;
        }
    }
}