using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// A special single bucket aggregation that enables aggregating nested documents.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-nested-aggregation.html
    /// </summary>
	public class NestedAggregation<T> : AggregationBase<NestedAggregation<T>, T>
    {
        /// <summary>
        /// The path of the nested documents within the top level documents.
        /// </summary>
		public NestedAggregation<T> Path(string path)
        {
			RegisterJsonPart("'path': {0}", path.Quotate());            
            return this;
        }

        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
            return "'nested': {{ {0} }}".AltQuoteF(body);
        }
        
    }
}