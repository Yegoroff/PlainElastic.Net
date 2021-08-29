using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The histogram facet works with numeric data by building a histogram across intervals of the field values.
    /// Each value is "rounded" into an interval (or placed in a bucket),
    /// and statistics are provided per interval/bucket (count and total)
    /// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-facets-histogram-facet.html
    /// </summary>
    public class HistogramFacet<T> : HistogramFacetBase<HistogramFacet<T>, T>
    {
        /// <summary>
        ///  The interval used to control the bucket "size" where each key value of a hit will fall into.
        /// </summary>
        public HistogramFacet<T> Interval(long interval)
        {
            RegisterJsonPart("'interval': {0}", interval.AsString());
            return this;
        }

        /// <summary>
        /// The time based interval (using the time format).
        /// This mainly make sense when working on date fields or field that represent absolute milliseconds
        /// </summary>
        public HistogramFacet<T> TimeInterval(string timeInterval)
        {
            RegisterJsonPart("'time_interval': {0}", timeInterval.Quotate());
            return this;
        }


        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return "'histogram': {{ {0} }}".AltQuoteF(body);
        }

    }
}