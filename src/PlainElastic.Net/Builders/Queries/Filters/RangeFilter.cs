using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents with fields that have terms within a certain range.
    /// Similar to range query, except that it acts as a filter
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-filter.html
    /// </summary>
    public class RangeFilter<T>: IJsonConvertible
    {
        private string rangeField;
        private readonly List<string> parts = new List<string>();
        private string cacheMode;


        //TODO: filter_name
        //TODO:  cache_key

        /// <summary>
        /// The field to apply filtering to.
        /// </summary>
        public RangeFilter<T> Field(string field)
        {
            rangeField = field.Quotate();

            return this;
        }

        /// <summary>
        /// The field to apply filtering to.
        /// </summary>
        public RangeFilter<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field of object from collection to apply filtering to.
        /// </summary>
        public RangeFilter<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        /// <summary>
        /// The lower bound. Defaults to start from the first.
        /// </summary>
        public RangeFilter<T> From(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'from': {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// The upper bound. Defaults to unbounded.
        /// </summary>
        public RangeFilter<T> To(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'to': {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Should the first from (if set) be inclusive or not. Defaults to true
        /// </summary>
        public RangeFilter<T> IncludeLower(bool includeLower = true)
        {
            parts.Add("'include_lower': {0}".SmartQuoteF(includeLower.AsString()));
            return this;
        }

        /// <summary>
        /// Should the last to (if set) be inclusive or not. Defaults to true.
        /// </summary>
        public RangeFilter<T> IncludeUpper(bool includeUpper = true)
        {
            parts.Add("'include_upper': {0}".SmartQuoteF(includeUpper.AsString()));
            return this;
        }

        /// <summary>
        /// Same as setting from to the value, and include_lower to false.
        /// </summary>
        public RangeFilter<T> Gt(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'gt': {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Same as setting from to the value, and include_lower to true.
        /// </summary>
        public RangeFilter<T> Gte(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'gte': {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Same as setting to to the value, and include_upper to false.
        /// </summary>
        public RangeFilter<T> Lt(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'lt': {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }

        /// <summary>
        /// Same as setting to to the value, and include_upper to true.
        /// </summary>
        public RangeFilter<T> Lte(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                parts.Add("'lte': {0}".SmartQuoteF(value.Quotate()));
            }
            return this;
        }


        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public RangeFilter<T> Cache(bool cache)
        {
            cacheMode = ",'_cache': {0}".SmartQuoteF(cache.AsString());

            return this;
        }

        public RangeFilter<T> Custom(string queryFormat, params string[] args)
        {
            var query = queryFormat.SmartQuoteF(args);
            parts.Add(query);

            return this;
        }



        string IJsonConvertible.ToJson()
        {
            var body = parts.JoinWithComma();
            if (body.IsNullOrEmpty())
                return "";

            if (cacheMode.IsNullOrEmpty())
                return "{{ 'range': {{ {0}: {{ {1} }} }} }}".SmartQuoteF(rangeField, body);

            return "{{ 'range': {{ {0}: {{ {1} }}{2} }} }}".SmartQuoteF(rangeField, body, cacheMode);
        }


        public override string ToString()
        {
            return ((IJsonConvertible)this).ToJson();
        }    
    }
}