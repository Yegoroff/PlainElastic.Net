using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The fuzzy_like_this_field query is the same as the fuzzy_like_this query, 
    /// except that it runs against a single field. 
    /// It provides nicer query DSL over the generic fuzzy_like_this query, 
    /// and support typed fields query (automatically wraps typed fields with type filter to match only on the specific type).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/flt-field-query.html
    /// </summary>
    public class FuzzyLikeThisFieldQuery<T> :FieldQueryBase<T, FuzzyLikeThisFieldQuery<T>>
    {
        private bool hasValue;

        /// <summary>
        /// The text to use in order to find documents that are "like" this.
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> LikeText(string likeText)
        {
            if (likeText.IsNullOrEmpty())
                return this;

            RegisterJsonPart("'like_text': {0}", likeText.Quotate());
            hasValue = true;
            return this;
        }

        /// <summary>
        /// Should term frequency be ignored. Defaults to false.
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> IgnoreTf(bool ignoreTf = false)
        {
            RegisterJsonPart("'ignore_tf': {0}", ignoreTf.AsString());
            return this;
        }

        /// <summary>
        /// The maximum number of query terms that will be included in any generated query.
        /// Defaults to 25.
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> MaxQueryTerms(int maxQueryTerms = 25)
        {
            RegisterJsonPart("'max_query_terms': {0}", maxQueryTerms.AsString());
            return this;
        }

        /// <summary>
        /// The minimum similarity of the term variants. Defaults to 0.5.
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> MinSimilarity(double minSimilarity = 0.5)
        {
            RegisterJsonPart("'min_similarity': {0}", minSimilarity.AsString());
            return this;
        }

        /// <summary>
        /// Length of required common prefix on variant terms. Defaults to 0.
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> PrefixLength(int prefixLength = 0)
        {
            RegisterJsonPart("'prefix_length': {0}", prefixLength.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public FuzzyLikeThisFieldQuery<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            if (RegisteredField.IsNullOrEmpty())
                return "{{ 'fuzzy_like_this_field': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'fuzzy_like_this_field': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }

    }
}