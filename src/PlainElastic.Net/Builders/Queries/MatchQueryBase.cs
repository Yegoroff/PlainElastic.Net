using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A base class for Match and Text queries.
    /// </summary>
    public class MatchQueryBase<T, TQuery> : FieldQueryBase<T, TQuery> where TQuery : MatchQueryBase<T, TQuery>
    {
        private bool hasQuery;


        /// <summary>
        /// The text query to analyze.
        /// </summary>
        public TQuery Query(string query)
        {
            if (!query.IsNullOrEmpty())
            {
                RegisterJsonPart("'query': {0}", query.Quotate());
                hasQuery = true;
            }

            return (TQuery)this;
        }


        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public TQuery Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return (TQuery)this;
        }


        /// <summary>
        /// Sets the text query type. Defaults to "boolean".
        /// </summary>
        public TQuery Type(TextQueryType type = TextQueryType.boolean)
        {
            RegisterJsonPart("'type': {0}", type.AsString().Quotate());

            return (TQuery)this;
        }


        /// <summary>
        /// Controls how boolean text query parts are combined.
        /// </summary>
        public TQuery Operator(Operator @operator)
        {
            RegisterJsonPart("'operator': {0}", @operator.AsString().Quotate());

            return (TQuery)this;
        }


        /// <summary>
        /// The analyzer name used to analyze the text query. Defaults to the field explicit mapping definition, or the default search analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public TQuery Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());

            return (TQuery)this;
        }

        /// <summary>
        /// The analyzer name used to analyze the text query. Defaults to the field explicit mapping definition, or the default search analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public TQuery Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }


        /// <summary>
        /// Controls construction of fuzzy queries for each term analyzed. 
        /// Value determines the minimum similarity used when evaluated to a fuzzy query type. Defaults to "0.5".
        /// Value depends on the relevant type, for string types it should be a value between 0.0 and 1.0.
        /// </summary>
        public TQuery Fuzziness(double fuzziness)
        {
            RegisterJsonPart("'fuzziness': {0}", fuzziness.AsString());

            return (TQuery)this;
        }


        /// <summary>
        /// Length of required common prefix on variant terms.
        /// </summary>
        public TQuery PrefixLength(int prefixLength)
        {
            RegisterJsonPart("'prefix_length': {0}", prefixLength.AsString());

            return (TQuery)this;
        }


        /// <summary>
        /// Controls to how many prefixes the last term will be expanded.
        /// </summary>
        public TQuery MaxExpansions(int maxExpansions)
        {
            RegisterJsonPart("'max_expansions': {0}", maxExpansions.AsString());

            return (TQuery)this;
        }


        /// <summary>
        /// Sets the slop for phrase query. If zero, then exact phrase matches are required.
        /// Default value is 0.
        /// </summary>
        public TQuery Slop(int slop = 0)
        {
            RegisterJsonPart("'slop': {0}", slop.AsString());

            return (TQuery)this;
        }

        
        /// <summary>
        /// Allows to control how multi term queries will get rewritten.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/multi-term-rewrite.html
        /// </summary>
        public TQuery Rewrite(Rewrite rewrite, int n = 0)
        {
            var rewriteValue = rewrite.GetRewriteValue(n);
            RegisterJsonPart("'rewrite': {0}", rewriteValue.Quotate());
            return (TQuery)this;
        }


        /// <summary>
        /// Set a cutoff value in [0..1] (or absolute number >=1) representing 
        /// the maximum threshold of a terms document frequency to be considered a low frequency term.
        /// </summary>
        public TQuery CutoffFrequency(double cutoff)
        {
            RegisterJsonPart("'cutoff_frequency': {0}", cutoff.AsString());
            return (TQuery)this;
        }

        public TQuery MinimumShouldMatch(string minimumShouldMatch)
        {
            RegisterJsonPart("'minimum_should_match': {0}", minimumShouldMatch.Quotate());
            return (TQuery)this;
        }

        public TQuery FuzzyRewrite(Rewrite rewrite, int n = 0)
        {
            var rewriteValue = rewrite.GetRewriteValue(n);
            RegisterJsonPart("'fuzzy_rewrite': {0}", rewriteValue.Quotate());
            return (TQuery)this;
        }

        public TQuery FuzzyTranspositions(bool fuzzyTranspositions)
        {
            RegisterJsonPart("'fuzzy_transpositions': {0}", fuzzyTranspositions.AsString());
            return (TQuery)this;
        }


        /// <summary>
        /// Sets whether format based failures will be ignored.
        /// </summary>
        public TQuery Lenient(bool lenient)
        {
            RegisterJsonPart("'lenient': {0}", lenient.AsString());
            return (TQuery)this;
        }

        public TQuery ZeroTermsQuery(ZeroTermsQuery zeroTermsQuery )
        {
            RegisterJsonPart("'zero_terms_query': {0}", zeroTermsQuery.AsString().Quotate());
            return (TQuery)this;
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