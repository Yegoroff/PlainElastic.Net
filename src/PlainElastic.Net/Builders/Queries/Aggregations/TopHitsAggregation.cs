
namespace PlainElastic.Net.Queries
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using PlainElastic.Net.Builders.Queries;
    using PlainElastic.Net.Utils;

    /// <summary>
    /// Allows to specify top hits aggregations that return the N top listed documents of an aggregation.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-terms-aggregation.html
    /// </summary>
    public class TopHitsAggregation<T> : AggregationBase<TopHitsAggregation<T>, T>
    {
        protected override bool ForceJsonBuild()
        {
            return true;
        }

        /// <summary>
        /// Allows to control which fields are used in the aggregations.
        /// </summary>
        public TopHitsAggregation<T> Source(Func<SourceQuery<T>, SourceQuery<T>> source)
        {
            RegisterJsonPartExpression(source);
            return this;
        }

        /// <summary>
        /// Allows to control the sorting of the aggregations.
        /// </summary>
        public TopHitsAggregation<T> Sort(
            Expression<Func<T, object>> field,
            SortDirection order = SortDirection.@default,
            string missing = null,
            bool ignoreUnmapped = false)
        {
           var sort = new Sort<T>();
            sort.Field(field, order, missing, ignoreUnmapped);
            RegisterJsonPart(sort.ToString());
            return this;
        }

        /// <summary>
        /// Allows to control the sorting of the aggregations
        /// </summary>
        public TopHitsAggregation<T> Sort(string field, SortDirection order = SortDirection.@default)
        {
            RegisterJsonPart("'sort': {{ {0} : {1} }}", field, order.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Allows to control the ordering of the aggregations
        /// </summary>
        public TopHitsAggregation<T> Sort(string[] fields, SortDirection order = SortDirection.@default)
        {
            var sortFields = string.Join(", ", fields.Select(f => string.Format("{{ {0} : {1} }}", f, order.AsString().Quotate())));
            RegisterJsonPart("'sort': [ {0} ]", sortFields, order.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// Sets the size - indicating how many documents should be returned in the aggregations.
        /// </summary>
        public TopHitsAggregation<T> Size(int size)
        {
            RegisterJsonPart("'size': {0}", size.AsString());
            return this;
        }

		protected override string ApplyAggregationBodyJsonTemplate(string body)
		{
			return "'top_hits': {{ {0} }}".AltQuoteF(body);
		}
    }
}