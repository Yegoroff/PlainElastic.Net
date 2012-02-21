using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents with fields that have terms within a certain range. 
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-query.html
    /// </summary>
    public class RangeQuery<T> : IJsonConvertible
    {
//TODO: Combine with RangeFilter.

        private string rangeField;
        private readonly List<string> parts = new List<string>();


        /// <summary>
        /// The field to apply filtering to.
        /// </summary>
        public RangeQuery<T> Field(string field)
        {
            rangeField = field.Quotate();

            return this;
        }

        /// <summary>
        /// The field to apply filtering to.
        /// </summary>
        public RangeQuery<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field of object from collection to apply filtering to.
        /// </summary>
        public RangeQuery<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The lower bound. Defaults to start from the first.
        /// </summary>
        public RangeQuery<T> From(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'from' : {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// The upper bound. Defaults to unbounded.
        /// </summary>
        public RangeQuery<T> To(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'to' : {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Should the first from (if set) be inclusive or not. Defaults to true
        /// </summary>
        public RangeQuery<T> IncludeLower(bool includeLower = true)
        {
            parts.Add("'include_lower' : {0}".SmartQuoteF(includeLower.AsString()));
            return this;
        }

        /// <summary>
        /// Should the last to (if set) be inclusive or not. Defaults to true.
        /// </summary>
        public RangeQuery<T> IncludeUpper(bool includeUpper = true)
        {
            parts.Add("'include_upper' : {0}".SmartQuoteF(includeUpper.AsString()));
            return this;
        }

        /// <summary>
        /// Same as setting from to the value, and include_lower to false.
        /// </summary>
        public RangeQuery<T> Gt(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'gt' : {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Same as setting from to the value, and include_lower to true.
        /// </summary>
        public RangeQuery<T> Gte(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'gte' : {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Same as setting to to the value, and include_upper to false.
        /// </summary>
        public RangeQuery<T> Lt(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'lt' : {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Same as setting to to the value, and include_upper to true.
        /// </summary>
        public RangeQuery<T> Lte(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'lte' : {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }


        public RangeQuery<T> Boost(double boost)
        {
            parts.Add("'boost' : {0}".SmartQuoteF(boost.AsString()));
            return this;
        }


        string IJsonConvertible.ToJson()
        {
            var body = parts.JoinWithComma();
            if (body.IsNullOrEmpty())
                return "";

            return "{{ 'range': {{ {0} : {{ {1} }} }} }}".SmartQuoteF(rangeField, body);
        }


        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }    
    }
}