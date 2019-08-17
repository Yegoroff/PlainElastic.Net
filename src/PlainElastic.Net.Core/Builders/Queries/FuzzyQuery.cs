using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A fuzzy based query that uses similarity based on Levenshtein (edit distance) algorithm.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/fuzzy-query.html
    /// </summary>
    public class FuzzyQuery<T> : FieldQueryBase<T, FuzzyQuery<T>>
    {
        private bool hasValue;

        /// <summary>
        /// The query value to compare to.
        /// </summary>
        public FuzzyQuery<T> Value(string value)
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
        public FuzzyQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }


        /// <summary>
        /// The minimum similarity of the term variants.
        /// </summary>
        public FuzzyQuery<T> MinSimilarity(double minSimilarity)
        {
            RegisterJsonPart("'min_similarity': {0}", minSimilarity.AsString());

            return this;
        }


        /// <summary>
        /// Controls to how many prefixes the last term will be expanded
        /// </summary>
        public FuzzyQuery<T> MaxExpansions(int maxExpansions)
        {
            RegisterJsonPart("'max_expansions': {0}", maxExpansions.AsString());

            return this;
        }

         
        /// <summary>
        /// Length of required common prefix on variant terms.
        /// </summary>
        public FuzzyQuery<T> PrefixLength(int prefixLength)
        {
            RegisterJsonPart("'prefix_length': {0}", prefixLength.AsString());

            return this;
        }
        


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'fuzzy': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'fuzzy': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}