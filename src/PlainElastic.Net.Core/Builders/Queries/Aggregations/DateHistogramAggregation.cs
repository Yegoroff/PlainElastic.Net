using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The histogram aggregation works with numeric data by building a histogram across intervals of the field values.
    /// Each value is "rounded" into an interval (or placed in a bucket),
    /// and statistics are provided per interval/bucket (count and total)
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-histogram-aggregation.html
    /// </summary>
	public class DateHistogramAggregation<T> : HistogramAggregationBase<DateHistogramAggregation<T>, T>
    {
        /// <summary>
        ///  The interval used to control the bucket "size" where each key value of a hit will fall into. Check
        ///  the docs for all available values.
        /// </summary>
		public DateHistogramAggregation<T> Interval(string interval)
        {
            RegisterJsonPart("'interval': {0}", interval.Quotate());
            return this;
        }

        /// <summary>
        /// Should pre zone be adjusted for large (day and above) intervals. Defaults to false.
        /// </summary>
		public DateHistogramAggregation<T> PreZoneAdjustLargeInterval(bool preZoneAdjustLargeInterval)
        {
            RegisterJsonPart("'pre_zone_adjust_large_interval': {0}", preZoneAdjustLargeInterval.AsString());
            return this;
        }

        /// <summary>
        ///  Sets the pre time zone to use when bucketing the values. This timezone will be applied before 
        ///  rounding off the result.
        ///  Can either be in the form of "-10:00" or
        ///  one of the values listed here: http://joda-time.sourceforge.net/timezones.html.
        /// </summary>
		public DateHistogramAggregation<T> PreZone(string preZone)
        {
            RegisterJsonPart("'pre_zone': {0}", preZone.Quotate());
            return this;
        }

        /// <summary>
        /// The time_zone parameter simply sets the pre_zone parameter.
        /// </summary>
        public DateHistogramAggregation<T> TimeZone(string timeZone)
        {
            RegisterJsonPart("'time_zone': {0}", timeZone.Quotate());
            return this;
        }      

        /// <summary>
        /// Sets the post time zone to use when bucketing the values. This timezone will be applied after
        /// rounding off the result.
        /// Can either be in the form of "-10:00" or
        /// one of the values listed here: http://joda-time.sourceforge.net/timezones.html.
        /// </summary>
		public DateHistogramAggregation<T> PostZone(string postZone)
        {
            RegisterJsonPart("'post_zone': {0}", postZone.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a pre offset that will be applied before rounding the results.
        /// </summary>
		public DateHistogramAggregation<T> PreOffset(string preOffset)
        {
            RegisterJsonPart("'pre_offset': {0}", preOffset.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a post offset that will be applied after rounding the results.
        /// </summary>
		public DateHistogramAggregation<T> PostOffset(string postOffset)
        {
            RegisterJsonPart("'post_offset': {0}", postOffset.Quotate());
            return this;
        }

        /// <summary>
        /// Defines a date format, which will result in returning the dates as formatted strings next to the numeric key values.
        /// </summary>
		public DateHistogramAggregation<T> Format(string format)
        {
            RegisterJsonPart("'format': {0}", format);
            return this;
        }


        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
            return "'date_histogram': {{ {0} }}".AltQuoteF(body);
        }

    }
}