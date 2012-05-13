using System;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents where a specific field has no value in them.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/missing-filter.html
    /// </summary>
    public class MissingFilter<T> : FieldQueryBase<T, MissingFilter<T>>
    {
        private bool hasRequiredParts;


        /// <summary>
        /// Controls whether filter will be applied.
        /// </summary>
        public MissingFilter<T> ShouldMiss(bool? value)
        {
            if (RegisteredField.IsNullOrEmpty())
                return this;

            hasRequiredParts = value.HasValue && value.Value;
            RegisterJsonPart("'field': {0}", RegisteredField);
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public MissingFilter<T> Name(string filterName)
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
            return "{{ 'missing': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}