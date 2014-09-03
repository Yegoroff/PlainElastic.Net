using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
	/// A multi-bucket value source based aggregation that enables the user to define a set of ranges - each representing a bucket. During the aggregation process, the values extracted from each document will be checked against each bucket range and "bucket" the relevant/matching document. Note that this aggregration includes the from value and excludes the to value for each range.
	/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations-bucket-range-aggregation.html
    /// </summary>
	public class RangeAggregation<T> : AggregationBase<RangeAggregation<T>, T>
    {
        private bool hasValue;

        /// <summary>
        /// The field to execute range aggregation against.
        /// </summary>
		public RangeAggregation<T> Field(string fieldName)
        {
            RegisterJsonPart("'field': {0}", fieldName.Quotate());            
            return this;
        }

        /// <summary>
		/// The field to execute range aggregation against.
        /// </summary>
		public RangeAggregation<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
		/// The field to execute range aggregation against.
        /// </summary>
		public RangeAggregation<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
		/// Setting the key flag to true will associate a unique string key with each bucket and return the ranges as a hash rather than an array
        /// </summary>
		public RangeAggregation<T> KeyedResponse(bool keyed)
        {
			RegisterJsonPart("'keyed': {0}", keyed.AsString());
            return this;
        }


        /// <summary>
        /// The script to get value to check if it falls within a range.
        /// </summary>
		public RangeAggregation<T> Script(string keyScript)
        {
            RegisterJsonPart("'script': {0}", keyScript.Quotate());
            return this;
        }

		/// <summary>
		/// Sets a scripting language used for scripts.
		/// By default used mvel language.
		/// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
		/// </summary>
		public RangeAggregation<T> Lang(string lang)
		{
			RegisterJsonPart("'lang': {0}", lang.Quotate());
			return this;
		}

		/// <summary>
		/// Sets a scripting language used for scripts.
		/// By default used mvel language.
		/// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
		/// </summary>
		public RangeAggregation<T> Lang(ScriptLangs lang)
		{
			return Lang(lang.AsString());
		}

		/// <summary>
		/// Sets parameters used for scripts.
		/// </summary>
		public RangeAggregation<T> Params(string paramsBody)
		{
			RegisterJsonPart("'params': {0}", paramsBody);
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