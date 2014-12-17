using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// Defines a single bucket of all the documents within the search execution context.
	/// This context is defined by the indices and the document types you’re searching on, but is not influenced by the search query itself.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-global-aggregation.html
	/// </summary>
	public class GlobalAggregation<T> : AggregationBase<GlobalAggregation<T>, T>
    {
        protected override string ApplyAggregationBodyJsonTemplate(string body)
        {
            return "'global': {}";
        }
        
    }
}