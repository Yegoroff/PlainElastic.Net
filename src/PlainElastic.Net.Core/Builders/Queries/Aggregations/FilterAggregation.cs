using System;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// Defines a single bucket of all the documents in the current document set context that match a specified filter.
	/// Often this will be used to narrow down the current aggregation context to a specific set of documents.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-filter-aggregation.html
    /// </summary>
    public class FilterAggregation<T> : AggregationBase<FilterAggregation<T>, T>
    {
       
        /// <summary>
        /// Filter that will be used to filter aggregation matches.
        /// </summary>
		public FilterAggregation<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }


        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
			return body;
        }
        
    }
}