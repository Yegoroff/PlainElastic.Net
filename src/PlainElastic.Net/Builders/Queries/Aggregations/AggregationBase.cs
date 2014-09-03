using System;
using System.Collections.Generic;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
	public abstract class AggregationBase<TAggregation, T> : QueryBase<TAggregation> where TAggregation : AggregationBase<TAggregation, T>
    {
		private string aggregationName;
		private readonly List<string> aggregationParts = new List<string>();
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

		/*
        /// <summary>
        /// Controls whether aggregation computed within the global scope. 
        /// In this case it will return values computed across all documents in the index.
        /// </summary>
		public TAggregation Global()
        {
			aggregationParts.Add("'global': {}");
			return (TAggregation)this;
        }


        /// <summary>
        /// Allows to run the aggregation on all the nested documents 
        /// matching the root objects that the main query will end up producing.
        /// </summary>
		public TAggregation Nested(string nestedDocumentPath)
        {
			aggregationParts.Add("'nested': {0}".AltQuoteF(nestedDocumentPath.Quotate()));
			return (TAggregation)this;
        }
		*/

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected sealed override string ApplyJsonTemplate(string body)
        {
            var aggregationBodyJson = ApplyAggregationBodyJsonTemplate(body);
			aggregationParts.Insert(0, aggregationBodyJson);

			var completeBody = aggregationParts.JoinWithComma();

			if (!string.IsNullOrEmpty(subAggregations)) 
			{
				completeBody = new string[] { completeBody, subAggregations }.JoinWithComma();
			}
			
			return "{0}: {{ {1} }}".AltQuoteF(aggregationName, completeBody);
        }

		protected abstract string ApplyAggregationBodyJsonTemplate(string body);

    }
}