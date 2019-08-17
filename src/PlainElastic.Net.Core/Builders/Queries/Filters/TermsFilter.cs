using System.Collections.Generic;
using System.Linq;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents that have fields that match any of the provided terms (not analyzed).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/terms-filter.html
    /// </summary>
    public class TermsFilter<T>: FieldQueryBase<T, TermsFilter<T>>
    {
        private bool hasValues;

        public TermsFilter<T> Values(IEnumerable<string> values)
        {
            if (values != null)
            {
                var termsValues = values.Where(v => !v.IsNullOrEmpty()).Quotate().JoinWithComma();
                if (!termsValues.IsNullOrEmpty())
                {
                    RegisterJsonPart("{0}: [ {1} ]", RegisteredField, termsValues);
                    hasValues = true;
                }
            }
            return this;
        }
         
        /// <summary>
        /// Controls the way terms filter executes.
        /// </summary>
        public TermsFilter<T> Execution(TermsFilterExecution execution)
        {
            RegisterJsonPart("'execution': {0}", execution.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public TermsFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public TermsFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }
        

        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            
            return "{{ 'terms': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}