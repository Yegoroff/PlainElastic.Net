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

        /// <summary>
        /// Controls whether filter will be applied.
        /// </summary>
        public ExistsFilter<T> ShouldExists(bool? value)
        {
            hasRequiredParts = value.HasValue && value.Value;
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public ExistsFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }



        protected override bool ForceJsonBuild()
        {
            return hasRequiredParts;
        }

        protected override bool HasRequiredParts()
        {
            return hasRequiredParts;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (!RegisteredField.IsNullOrEmpty())
            {
                var field = "'field': {0}".AltQuoteF(RegisteredField);

                if (!body.IsNullOrEmpty())
                    body = new[] { field, body }.JoinWithComma();
                else
                    body = field;
            }
            else if (!HasCustomPatrs)
                return "";

            return "{{ 'exists': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}