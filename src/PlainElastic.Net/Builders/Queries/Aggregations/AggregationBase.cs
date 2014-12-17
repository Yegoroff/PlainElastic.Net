using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
	public abstract class AggregationBase<TAggregation, T> : QueryBase<TAggregation> where TAggregation : AggregationBase<TAggregation, T>
    {
		private string aggregationName;
		private string subAggregations;

        /// <summary>
        /// The name of the aggregation used to identify aggregation results.
        /// </summary>
		public TAggregation AggregationName(string name)
        {
			this.aggregationName = name.Quotate();

			return (TAggregation)this;
        }

		/// <summary>
		/// Allows to collect aggregated data based on a search query. 
		/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations.html
		/// </summary>
		public TAggregation Aggregations(Func<Aggregations<T>, Aggregations<T>> aggregations)
		{
			var jsonBuilderInstance = new Aggregations<T>();
			var resultPart = aggregations.Invoke(jsonBuilderInstance) as IJsonConvertible;
			subAggregations = resultPart.ToJson();

			return (TAggregation)this;
		}


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected sealed override string ApplyJsonTemplate(string body)
        {
            var aggregationBodyJson = ApplyAggregationBodyJsonTemplate(body);

			if (!string.IsNullOrEmpty(subAggregations))
                aggregationBodyJson += ","  + subAggregations;
			
			return "{0}: {{ {1} }}".AltQuoteF(aggregationName, aggregationBodyJson);
        }

		protected abstract string ApplyAggregationBodyJsonTemplate(string body);

    }
}