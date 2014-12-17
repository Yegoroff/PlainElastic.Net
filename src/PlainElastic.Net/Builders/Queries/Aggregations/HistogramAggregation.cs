using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The histogram aggregation works with numeric data by building a histogram across intervals of the field values.
    /// Each value is "rounded" into an interval (or placed in a bucket),
    /// and statistics are provided per interval/bucket (count and total)
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-histogram-aggregation.html
    /// </summary>
	public class HistogramAggregation<T> : HistogramAggregationBase<HistogramAggregation<T>, T>
    {
        /// <summary>
        ///  The interval used to control the bucket "size" where each key value of a hit will fall into.
        /// </summary>
		public HistogramAggregation<T> Interval(long interval)
        {
            RegisterJsonPart("'interval': {0}", interval.AsString());
            return this;
        }

        /// <summary>
        /// Formats the response as a hash instead keyed by the buckets keys.
        /// </summary>
        public HistogramAggregation<T> Keyed(bool keyed)
        {
            RegisterJsonPart("'keyed': {0}", keyed.AsString());
            return this;
        }


        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
            return "'histogram': {{ {0} }}".AltQuoteF(body);
        }

    }
}