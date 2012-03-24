using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents that have fields that contain a term (not analyzed).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-filter.html
    /// </summary>    
    public class TermFilter<T>: FieldQueryBase<T, TermFilter<T>>
    {
        private bool hasValue;


        public TermFilter<T> Value(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                RegisterJsonPart("{0}: {1}", RegisteredField, value.Quotate());
                hasValue = true;
            }

            return this;
        }

        public TermFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());
            return this;
        }

        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public TermFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }



        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'term': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}