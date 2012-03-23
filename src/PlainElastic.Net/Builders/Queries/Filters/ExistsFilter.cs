using System;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents where a specific field has a value in them.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/exists-filter.html
    /// </summary>
    public class ExistsFilter<T> : FieldQueryBase<T, ExistsFilter<T>>
    {
        private bool hasRequiredParts;


        public ExistsFilter<T> ShouldExists(bool? value)
        {
            if (RegisteredField.IsNullOrEmpty())
                return this;

            hasRequiredParts = value.HasValue && value.Value;
            RegisterJsonPart("'field': {0}", RegisteredField);
            return this;
        }

        public ExistsFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'exists': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}