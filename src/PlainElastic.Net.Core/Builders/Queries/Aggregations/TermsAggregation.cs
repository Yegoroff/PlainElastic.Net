using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to specify field aggregations that return the N most frequent terms
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-terms-aggregation.html
    /// </summary>
	public class TermsAggregation<T> : ValueAggregationBase<TermsAggregation<T>, T>
    {

        /// <summary>
        /// Allows to control the ordering of the terms aggregations
        /// </summary>
        public TermsAggregation<T> Order(string field, OrderDirection order)
        {
            RegisterJsonPart("'order': {{ {0} : {1} }}", field, order.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// Sets the size - indicating how many term buckets should be returned (defaults to 10)
        /// </summary>
		public TermsAggregation<T> Size(int size)
        {
            RegisterJsonPart("'size': {0}", size.AsString());
            return this;
        }

        /// <summary>
        /// Sets the shard_size - indicating the number of term buckets each shard will return to the coordinating node (the
        /// node that coordinates the search execution). The higher the shard size is, the more accurate the results are.
        /// </summary>
        public TermsAggregation<T> ShardSize(int shardSize)
        {
            RegisterJsonPart("'shard_size': {0}", shardSize.AsString());
            return this;
            
        }        

		/// <summary>
        /// Set the minimum document count terms should have in order to appear in the response.
		/// </summary>
		public TermsAggregation<T> MinDocCount(long minDocCount)
		{
			RegisterJsonPart("'min_doc_count': {0}", minDocCount.AsString());
			return this;
		}

        /// <summary>
        /// Set the minimum document count terms should have on the shard in order to appear in the response.
        /// </summary>
        public TermsAggregation<T> ShardMinDocCount(long shardMinDocCount)
        {
			RegisterJsonPart("'shard_min_doc_count': {0}", shardMinDocCount.AsString());
			return this;
        }


        /// <summary>
        /// Return document count errors per term in the response.
        /// </summary>
        public TermsAggregation<T> ShowTermDocCountError(bool showTermDocCountError)
        {
            RegisterJsonPart("'show_term_doc_count_error': {0}", showTermDocCountError.AsString());
			return this;
        }

        /// <summary>
        /// Defines collection mode
        /// </summary>
        public TermsAggregation<T> CollectMode(CollectMode mode)
        {
            RegisterJsonPart("'collect_mode': {0}", mode.AsString().Quotate());
			return this;
        }


        /// <summary>
        /// When using scripts, the value type indicates the types of the values the script is generating.
        /// </summary>
        public TermsAggregation<T> ValueType(TermsValueType valueType)
        {
            RegisterJsonPart("'value_type': {0}", valueType.AsString().Quotate());
			return this;
        }
       

        /// <summary>
		/// Allows to specify a term that should be included from the terms aggregation request result.
		/// </summary>
		public TermsAggregation<T> Include(string includeTerm)
		{
			RegisterJsonPart("'include': {0}", includeTerm.Quotate());

			return this;
		}

		/// <summary>
		/// Allows to specify a term that should be included from the terms aggregation request result.
		/// </summary>
		public TermsAggregation<T> Include(string includeTerm, RegexFlags regexFlags)
		{
			RegisterJsonPart("'include': {{ 'pattern': {0}, 'flags': {1} }}", includeTerm.Quotate(), regexFlags.AsString().Quotate());

			return this;
		}


        /// <summary>
        /// Allows to specify a term that should be excluded from the terms aggregation request result.
        /// </summary>
		public TermsAggregation<T> Exclude(string excludeTerm)
        {
            RegisterJsonPart("'exclude': {0}", excludeTerm.Quotate());

            return this;
        }

		/// <summary>
		/// Allows to specify a term that should be excluded from the terms aggregation request result.
		/// </summary>
		public TermsAggregation<T> Exclude(string excludeTerm, RegexFlags regexFlags)
		{
			RegisterJsonPart("'exclude': {{ 'pattern': {0}, 'flags': {1} }}", excludeTerm.Quotate(), regexFlags.AsString().Quotate());

			return this;
		}

		/// <summary>
		/// There are three mechanisms by which terms aggregations can be executed: either by using field values directly in order to aggregate data per-bucket (map), by using ordinals of the field values instead of the values themselves (ordinals) or by using global ordinals of the field (global_ordinals). The latter is faster, especially for fields with many unique values. However it can be slower if only a few documents match, when for example a terms aggregator is nested in another aggregator, this applies for both ordinals and global_ordinals execution modes. 
		/// </summary>
		public TermsAggregation<T> ExecutionHint(string hint)
		{
			RegisterJsonPart("'execution_hint': {0}", hint.Quotate());

			return this;
		}


		protected override string ApplyAggregationBodyJsonTemplate(string body)
		{
			return "'terms': {{ {0} }}".AltQuoteF(body);
		}
    }
}