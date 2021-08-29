using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// A multi-bucket value source based aggregation that enables the user to define a set of ranges - each representing a bucket.
	/// During the aggregation process, the values extracted from each document will be checked against each bucket range and "bucket" the relevant/matching document.
	/// Note that this aggregration includes the from value and excludes the to value for each range.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-range-aggregation.html
    /// </summary>
	public class RangeAggregation<T> : ValueAggregationBase<RangeAggregation<T>, T>
    {
        private bool hasValue;


        /// <summary>
		/// Setting the key flag to true will associate a unique string key with each bucket and return the ranges as a hash rather than an array
        /// </summary>
		public RangeAggregation<T> Keyed(bool keyed)
        {
			RegisterJsonPart("'keyed': {0}", keyed.AsString());
            return this;
        }

        /// <summary>
        /// The ranges of values to aggregate against, in format (from, to)
        /// </summary>
		public RangeAggregation<T> Ranges(Func<RangeAggregationFromTo, RangeAggregationFromTo> ranges)
        {
            hasValue = !RegisterJsonPartExpression(ranges).GetIsEmpty();
            return this;
        }


        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
			return "'range': {{ {0} }}".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

    }
}