using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to specify field aggregations that return the N most frequent terms
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-terms-aggregation.html
    /// </summary>
	public class TermsAggregation<T> : AggregationBase<TermsAggregation<T>, T>
    {
        private readonly List<string> aggregationFields = new List<string>();

        /// <summary>
        /// The field to execute term aggregation against.
        /// </summary>
		public TermsAggregation<T> Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());            
            return this;
        }

        /// <summary>
        /// The field to execute term aggregation against.
        /// </summary>
		public TermsAggregation<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field to execute term aggregation against.
        /// </summary>
		public TermsAggregation<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }

        /// <summary>
        /// Allows to control the ordering of the terms aggregations, to be ordered by count, term, reverse_count or reverse_term. The default is count.
        /// </summary>
		public TermsAggregation<T> Order(TermsFacetOrder order = TermsFacetOrder.count)
        {
            RegisterJsonPart("'order': {0}", order.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// The number of the most frequent terms to return.
        /// </summary>
		public TermsAggregation<T> Size(int size)
        {
            RegisterJsonPart("'size': {0}", size.AsString());

            return this;
        }

		/// <summary>
		/// It is possible to only return buckets that have a document count that is greater than or equal to a configured limit through the min_doc_count option.
		/// </summary>
		public TermsAggregation<T> MinDocCount(long minDocCount)
		{
			RegisterJsonPart("'min_doc_count': {0}", minDocCount.AsString());
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

        /// <summary>
        /// Allow to define a script for terms aggregation to process the actual term
        /// that will be used in the term facet collection, and also optionally control its inclusion or not.
        /// </summary>
		public TermsAggregation<T> Script(string script)
        {
            RegisterJsonPart("'script': {0}", script.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
		public TermsAggregation<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
		public TermsAggregation<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
		public TermsAggregation<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }

		protected override string ApplyAggregationBodyJsonTemplate(string body)
		{
			return "'terms': {{ {0} }}".AltQuoteF(body);
		}
    }
}