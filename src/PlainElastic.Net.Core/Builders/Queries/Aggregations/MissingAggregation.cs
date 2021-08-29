using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// A field data based single bucket aggregation, that creates a bucket of all documents in the current document set context that are missing a field value 
	/// (effectively, missing a field or having the configured NULL value set).
	/// This aggregator will often be used in conjunction with other field data bucket aggregators (such as ranges)
	/// to return information for all the documents that could not be placed in any of the other buckets due to missing field data values.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-missing-aggregation.html
    /// </summary>
	public class MissingAggregation<T> : ValueAggregationBase<MissingAggregation<T>, T>
    {

        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
            return "'missing': {{ {0} }}".AltQuoteF(body);
        }
        
    }
}