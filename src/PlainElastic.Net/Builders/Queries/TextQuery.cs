using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A family of text queries that accept text, analyzes it, and constructs a query out of it.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
    /// </summary>
    public class TextQuery<T> : FieldQueryBase<T, TextQuery<T>>
    {
        private bool hasQuery;

        /// <summary>
        /// The text query to analyze.
        /// </summary>
        public TextQuery<T> Query(string query)
        {
            if (!query.IsNullOrEmpty())
            {
                RegisterJsonPart("'query': {0}", query.Quotate());
                hasQuery = true;
            }

            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public TextQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }


        /// <summary>
        /// Sets the text query type. Defaults to "boolean".
        /// </summary>
        public TextQuery<T> Type(TextQueryType type = TextQueryType.boolean)
        {
            RegisterJsonPart("'type': {0}", type.ToString().Quotate());

            return this;
        }


        /// <summary>
        /// Controls how boolean text query parts are combined.
        /// </summary>
        public TextQuery<T> Operator(Operator @operator)
        {
            RegisterJsonPart("'operator': {0}", @operator.ToString().Quotate());

            return this;
        }


        /// <summary>
        /// The analyzer name used to analyze the text query. Defaults to the field explicit mapping definition, or the default search analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public TextQuery<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());

            return this;
        }

        /// <summary>
        /// The analyzer name used to analyze the text query. Defaults to the field explicit mapping definition, or the default search analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public TextQuery<T> Analyzer(DefaultAnalizers analyzer)
        {
            return Analyzer(analyzer.ToString());
        }


        /// <summary>
        /// Controls construction of fuzzy queries for each term analyzed.
        /// Value depends on the relevant type, for string types it should be a value between 0.0 and 1.0.
        /// </summary>
        public TextQuery<T> Fuzziness(double fuzziness)
        {
            RegisterJsonPart("'fuzziness': {0}", fuzziness.AsString());

            return this;
        }


        /// <summary>
        /// Length of required common prefix on variant terms.
        /// </summary>
        public TextQuery<T> PrefixLength(int prefixLength)
        {
            RegisterJsonPart("'prefix_length': {0}", prefixLength.AsString());

            return this;
        }


        /// <summary>
        /// Controls to how many prefixes the last term will be expanded.
        /// </summary>
        public TextQuery<T> MaxExpansions(int maxExpansions)
        {
            RegisterJsonPart("'max_expansions': {0}", maxExpansions.AsString());

            return this;
        }


        /// <summary>
        /// Sets the slop for text phrase query. If zero, then exact phrase matches are required.
        /// Default value is 0.
        /// </summary>
        public TextQuery<T> Slop(int slop = 0)
        {
            RegisterJsonPart("'slop': {0}", slop.AsString());

            return this;
        }
        


        protected override bool HasRequiredParts()
        {
            return hasQuery;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'text': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'text': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
        
    }
}