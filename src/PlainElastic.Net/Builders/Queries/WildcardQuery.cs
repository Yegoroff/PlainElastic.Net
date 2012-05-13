using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Matches documents that have fields matching a wildcard expression (not analyzed).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/wildcard-query.html
    /// </summary>
    public class WildcardQuery<T> : FieldQueryBase<T, WildcardQuery<T>>
    {
        private bool hasValue;

        public WildcardQuery<T> Value(string value)
        {
            if (!value.IsNullOrEmpty())
            {
                RegisterJsonPart("'value': {0}", value.Quotate());
                hasValue = true;
            }

            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public WildcardQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'wildcard': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'wildcard': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }

    }
}
