using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A query that uses a query parser in order to parse its content
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/query-string-query.html
    /// </summary>    
    public class QueryString<T> : QueryBase<QueryString<T>>
    {

        private readonly List<string> queryFields = new List<string>();

        private bool hasValue;


        /// <summary>
        /// The default field for query terms if no prefix field is specified. 
        /// Defaults to the index.query.default_field index settings, which in turn defaults to _all
        /// </summary>
        public QueryString<T> DefaultField(string fieldName)
        {
            RegisterJsonPart("'default_field': {0}", fieldName.Quotate());
            return this;
        }

        /// <summary>
        /// The default field for query terms if no prefix field is specified. 
        /// Defaults to the index.query.default_field index settings, which in turn defaults to _all
        /// </summary>
        public QueryString<T> DefaultField(Expression<Func<T, object>> field)
        {
            var fieldName = field.GetPropertyPath();
            return DefaultField(fieldName);
        }

        /// <summary>
        /// The default field for query terms if no prefix field is specified. 
        /// Defaults to the index.query.default_field index settings, which in turn defaults to _all
        /// </summary>
        public QueryString<T> DefaultFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return DefaultField(fieldName);
        }


        /// <summary>
        /// Allows to running the query_string query against multiple fields by internally creating several queries for the same query string,
        /// each with default_field that match the fields provided.
        /// Since several queries are generated, combining them can be automatically done either using a dis_max query or a simple bool query.
        /// </summary>
        public QueryString<T> Fields(params string[] fields)
        {
            queryFields.AddRange(fields);
            return this;
        }

        /// <summary>
        /// Allows to running the query_string query against multiple fields by internally creating several queries for the same query string,
        /// each with default_field that match the fields provided.
        /// Since several queries are generated, combining them can be automatically done either using a dis_max query or a simple bool query.
        /// </summary>
        public QueryString<T> Fields(params Expression<Func<T, object>> [] fields)
        {
            foreach (var field in fields)
                queryFields.Add(field.GetPropertyPath());

            return this;
        }

        /// <summary>
        /// Allows to running the query_string query against multiple fields by internally creating several queries for the same query string,
        /// each with default_field that match the fields provided.
        /// Since several queries are generated, combining them can be automatically done either using a dis_max query or a simple bool query.
        /// </summary>
        public QueryString<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyPath();

            foreach (var field in fields)
            {
                var fieldName = collectionProperty + "." + field.GetPropertyPath();
                queryFields.Add(fieldName);
            }
            return this;
        }


        /// <summary>
        /// The actual query to be parsed.
        /// </summary>
        public QueryString<T> Query(string value)
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
        public QueryString<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// Allows to control how  multi term queries will get rewritten.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/multi-term-rewrite.html
        /// </summary>
        public QueryString<T> Rewrite(Rewrite rewrite, int n = 0)
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
        public QueryString<T> DefaultOperator(Operator defaultOperator)
        {            
            RegisterJsonPart("'default_operator': {0}", defaultOperator.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// The analyzer name used to analyze the query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public QueryString<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer name used to analyze the query string. Defaults to the globally configured analyzer.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public QueryString<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }

        /// <summary>
        /// When set, * or ? are allowed as the first character. Defaults to true.
        /// </summary>
        public QueryString<T> AllowLeadingWildcard(bool allowLeadingWildcard = true)
        {
            RegisterJsonPart("'allow_leading_wildcard': {0}", allowLeadingWildcard.AsString());
            return this;
        }

        /// <summary>
        /// Whether terms of wildcard, prefix, fuzzy, and range queries are to be automatically lower-cased or not (since they are not analyzed). 
        /// Default it true.
        /// </summary>
        public QueryString<T> LowercaseExpandedTerms(bool lowercaseExpandedTerms = true)
        {
            RegisterJsonPart("'lowercase_expanded_terms': {0}", lowercaseExpandedTerms.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to enable position increments in result queries. Defaults to true.
        /// </summary>
        public QueryString<T> EnablePositionIncrements(bool enablePositionIncrements = true)
        {
            RegisterJsonPart("'enable_position_increments': {0}", enablePositionIncrements.AsString());
            return this;
        }

        /// <summary>
        /// Set the prefix length for fuzzy queries. Default is 0.
        /// </summary>
        public QueryString<T> FuzzyPrefixLength(int fuzzyPrefixLength = 0)
        {
            RegisterJsonPart("'fuzzy_prefix_length': {0}", fuzzyPrefixLength.AsString());
            return this;
        }

        /// <summary>
        /// Set the minimum similarity for fuzzy queries. Defaults to 0.5
        /// </summary>
        public QueryString<T> FuzzyMinSim(double fuzzyMinSim = 0.5)
        {
            RegisterJsonPart("'fuzzy_min_sim': {0}", fuzzyMinSim.AsString());
            return this;
        }

        /// <summary>
        /// Sets the default slop for phrases. If zero, then exact phrase matches are required.
        ///  Default value is 0.
        /// </summary>
        public QueryString<T> PhraseSlop(int phraseSlop = 0)
        {
            RegisterJsonPart("'phrase_slop': {0}", phraseSlop.AsString());
            return this;
        }

        /// <summary>
        /// By default, wildcards terms in a query string are not analyzed. 
        /// By setting this value to true, a best effort will be made to analyze those as well.
        /// </summary>
        public QueryString<T> AnalyzeWildcard(bool analyzeWildcard = false)
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
        public QueryString<T> AutoGeneratePhraseQueries(bool autoGeneratePhraseQueries = false)
        {
            RegisterJsonPart("'auto_generate_phrase_queries': {0}", autoGeneratePhraseQueries.AsString());
            return this;
        }

        /// <summary>
        /// A percent value (for example 20%) controlling how many “should” clauses in the resulting boolean query should match.
        /// </summary>
        public QueryString<T> MinimumShouldMatch(string minimumShouldMatch)
        {
            RegisterJsonPart("'minimum_should_match': {0}", minimumShouldMatch.Quotate());
            return this;
        }

        /// <summary>
        /// Should the queries be combined using dis_max (set it to true), or a bool query (set it to false).
        /// Defaults to true.
        /// </summary>
        public QueryString<T> UseDisMax(bool useDisMax = true)
        {
            RegisterJsonPart("'use_dis_max': {0}", useDisMax.AsString());
            return this;
        }

        /// <summary>
        /// When using dis_max, the disjunction max tie breaker. 
        /// Defaults to 0.
        /// </summary>
        public QueryString<T> TieBreaker(double tieBreaker = 0)
        {
            RegisterJsonPart("'tie_breaker': {0}", tieBreaker.AsString());
            return this;
        }

        /// <summary>
        ///  Allows to control docs that have fields that exists within them (have a value).
        /// </summary>
        public QueryString<T> Exists(string fieldName)
        {
            RegisterJsonPart("'_exists_': {0}", fieldName.Quotate());
            return this;
        }

        /// <summary>
        ///  Allows to control docs that have fields that missing within them.
        /// </summary>
        public QueryString<T> Missing(string fieldName)
        {
            RegisterJsonPart("'_missing_': {0}", fieldName.Quotate());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            if (queryFields.Count > 0)
            {
                string fields = JsonHelper.BuildJsonStringsProperty("fields", queryFields);
                body = new[] { fields, body }.JoinWithComma();
            }

            return "{{ 'query_string': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}