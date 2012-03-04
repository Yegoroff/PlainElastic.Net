using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents that have fields that match any of the provided terms (not analyzed).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/terms-filter.html
    /// </summary>
    public class TermsFilter<T> : IJsonConvertible
    {
        private string termsField;
        private string termsValues;
        private string executionMode;
        private string cacheMode;


        public TermsFilter<T> Field(string field)
        {
            termsField = field.Quotate();

            return this;
        }

        public TermsFilter<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        public TermsFilter<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }


        public TermsFilter<T> Values(IEnumerable<string> values)
        {
            if (values != null)
                termsValues = values.Where(v => !v.IsNullOrEmpty()).LowerAndQuotate().JoinWithComma();

            return this;
        }

        /// <summary>
        /// Controls the way terms filter executes.
        /// </summary>
        public TermsFilter<T> Execution(TermsFilterExecution execution)
        {
            executionMode = "'execution': {0}".AltQuoteF(execution.ToString().Quotate());

            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public TermsFilter<T> Cache(bool cache)
        {
            cacheMode = "'_cache': {0}".AltQuoteF(cache.AsString());

            return this;
        }


        // http://www.elasticsearch.org/guide/reference/api/search/named-filters.html
        //TODO: _name


        string IJsonConvertible.ToJson()
        {
            if (termsValues.IsNullOrEmpty())
                return "";

            var options = new[] {executionMode, cacheMode}.Where(m => !m.IsNullOrEmpty()).JoinWithComma();

            if (options.IsNullOrEmpty())
                return "{{ 'terms': {{ {0} : [ {1} ] }} }}".AltQuoteF(termsField, termsValues);

            return "{{ 'terms': {{ {0} : [ {1} ] {2} }} }}".AltQuoteF(termsField, termsValues, options);
        }
    }
}