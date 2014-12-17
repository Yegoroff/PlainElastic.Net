using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that executes a query string against a specific field.
    /// It is a simplified version of query_string query 
    /// (by setting the default_field to the field this query executed against). 
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/field-query.html
    /// </summary>
    [Obsolete("Use QueryString instead")]
    public class FieldQuery<T> : FieldQueryBase<T, FieldQuery<T>>
    {
        private bool hasValue;


        /// <summary>
        /// The actual query to be parsed.
        /// </summary>
        public FieldQuery<T> Query(string value)
        {
            if (value.IsNullOrEmpty())
                return this;

            RegisterJsonPart("'query': {0}", value.Quotate());
            hasValue = true;
            return this;
        }


        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public FieldQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// Allows to control how  multi term queries will get rewritten.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/multi-term-rewrite.html
        /// </summary>
        public FieldQuery<T> Rewrite(Rewrite rewrite, int n = 0)
        {
            var rewriteValue = rewrite.GetRewriteValue(n);
            RegisterJsonPart("'rewrite': {0}", rewriteValue.Quotate());
            return this;
        }

        /// <summary>
        /// The default operator used if no explicit operator is specified. 
        /// For example, with a default operator of OR, the query capital of Hungary is translated to capital OR of OR Hungary,
        /// and with default operator of AND, the same query is translated to capital AND of AND Hungary.
        /// The default value is OR.
        /// </summary>
        public FieldQuery<T> DefaultOperator(Operator defaultOperator)
        {
            RegisterJsonPart("'default_operator': {0}", defaultOperator.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// The analyzer name used to analyze the query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public FieldQuery<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer name used to analyze the query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public FieldQuery<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }

        /// <summary>
        /// When set, * or ? are allowed as the first character. Defaults to true.
        /// </summary>
        public FieldQuery<T> AllowLeadingWildcard(bool allowLeadingWildcard = true)
        {
            RegisterJsonPart("'allow_leading_wildcard': {0}", allowLeadingWildcard.AsString());
            return this;
        }

        /// <summary>
        /// Whether terms of wildcard, prefix, fuzzy, and range queries are to be automatically lower-cased or not (since they are not analyzed). 
        /// Default it true.
        /// </summary>
        public FieldQuery<T> LowercaseExpandedTerms(bool lowercaseExpandedTerms = true)
        {
            RegisterJsonPart("'lowercase_expanded_terms': {0}", lowercaseExpandedTerms.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to enable position increments in result queries. Defaults to true.
        /// </summary>
        public FieldQuery<T> EnablePositionIncrements(bool enablePositionIncrements = true)
        {
            RegisterJsonPart("'enable_position_increments': {0}", enablePositionIncrements.AsString());
            return this;
        }

        /// <summary>
        /// Set the prefix length for fuzzy queries. Default is 0.
        /// </summary>
        public FieldQuery<T> FuzzyPrefixLength(int fuzzyPrefixLength = 0)
        {
            RegisterJsonPart("'fuzzy_prefix_length': {0}", fuzzyPrefixLength.AsString());
            return this;
        }

        /// <summary>
        /// Set the minimum similarity for fuzzy queries. Defaults to 0.5
        /// </summary>
        public FieldQuery<T> FuzzyMinSim(double fuzzyMinSim = 0.5)
        {
            RegisterJsonPart("'fuzzy_min_sim': {0}", fuzzyMinSim.AsString());
            return this;
        }

        /// <summary>
        /// Sets the default slop for phrases. If zero, then exact phrase matches are required.
        /// Default value is 0.
        /// </summary>
        public FieldQuery<T> PhraseSlop(int phraseSlop = 0)
        {
            RegisterJsonPart("'phrase_slop': {0}", phraseSlop.AsString());
            return this;
        }

        /// <summary>
        /// By default, wildcards terms in a query string are not analyzed. 
        /// By setting this value to true, a best effort will be made to analyze those as well.
        /// </summary>
        public FieldQuery<T> AnalyzeWildcard(bool analyzeWildcard = false)
        {
            RegisterJsonPart("'analyze_wildcard': {0}", analyzeWildcard.AsString());
            return this;
        }

        /// <summary>
        ///  Set to true if phrase queries will be automatically generated
        ///  when the analyzer returns more than one term from whitespace
        ///  delimited text.
        ///  NOTE: this behavior may not be suitable for all languages.
        ///  Set to false if phrase queries should only be generated when
        ///  surrounded by double quotes.
        /// </summary>
        public FieldQuery<T> AutoGeneratePhraseQueries(bool autoGeneratePhraseQueries = false)
        {
            RegisterJsonPart("'auto_generate_phrase_queries': {0}", autoGeneratePhraseQueries.AsString());
            return this;
        }

        /// <summary>
        /// A percent value (for example 20%) controlling how many “should” clauses in the resulting boolean query should match.
        /// </summary>
        public FieldQuery<T> MinimumShouldMatch(string minimumShouldMatch)
        {
            RegisterJsonPart("'minimum_should_match': {0}", minimumShouldMatch.Quotate());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'field': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'field': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }

    }
}