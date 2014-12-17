using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The more_like_this_field query is the same as the more_like_this query, 
    /// except it runs against a single field. It provides nicer query DSL over the generic more_like_this query,
    /// and support typed fields query (automatically wraps typed fields with type filter to match only on the specific type).
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/mlt-field-query.html
    /// </summary>
    [Obsolete("Use MoreLikeThisQuery set to a specific field")]
    public class MoreLikeThisFieldQuery<T> : FieldQueryBase<T,MoreLikeThisFieldQuery<T>>
    {

        private bool hasValue;


        /// <summary>
        /// The text to use in order to find documents that are "like" this.
        /// </summary>
        public MoreLikeThisFieldQuery<T> LikeText(string likeText)
        {
            if (likeText.IsNullOrEmpty())
                return this;

            RegisterJsonPart("'like_text': {0}", likeText.Quotate());
            hasValue = true;
            return this;
        }

        /// <summary>
        /// The percentage of terms to match on (float value). Defaults to 0.3 (30 percent).
        /// </summary>
        public MoreLikeThisFieldQuery<T> PercentTermsToMatch(double percentTermsToMatch = 0.3)
        {
            RegisterJsonPart("'percent_terms_to_match': {0}", percentTermsToMatch.AsString());
            return this;
        }

        /// <summary>
        /// The frequency below which terms will be ignored in the source doc. The default frequency is 2.
        /// </summary>
        public MoreLikeThisFieldQuery<T> MinTermFreq(int minTermFreq = 2)
        {
            RegisterJsonPart("'min_term_freq': {0}", minTermFreq.AsString());
            return this;
        }

        /// <summary>
        /// The maximum number of query terms that will be included in any generated query.
        /// Defaults to 25.
        /// </summary>
        public MoreLikeThisFieldQuery<T> MaxQueryTerms(int maxQueryTerms = 25)
        {
            RegisterJsonPart("'max_query_terms': {0}", maxQueryTerms.AsString());
            return this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public MoreLikeThisFieldQuery<T> StopWords(IEnumerable<string> stopwords)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("stop_words", stopwords);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public MoreLikeThisFieldQuery<T> StopWords(params string[] stopwords)
        {
            return StopWords((IEnumerable<string>)stopwords);
        }

        /// <summary>
        /// The frequency at which words will be ignored which do not occur in at least this many docs.
        /// Defaults to 5.
        /// </summary>
        public MoreLikeThisFieldQuery<T> MinDocFreq(int minDocFreq = 5)
        {
            RegisterJsonPart("'min_doc_freq': {0}", minDocFreq.AsString());
            return this;
        }

        /// <summary>
        /// The maximum frequency in which words may still appear. Words that appear in more than this many docs will be ignored.
        /// Defaults to unbounded.
        /// </summary>
        public MoreLikeThisFieldQuery<T> MaxDocFreq(int maxDocFreq)
        {
            RegisterJsonPart("'max_doc_freq': {0}", maxDocFreq.AsString());
            return this;
        }

        /// <summary>
        /// The minimum word length below which words will be ignored. Defaults to 0.
        /// </summary>
        public MoreLikeThisFieldQuery<T> MinWordLen(int minWordLen = 0)
        {
            RegisterJsonPart("'min_word_len': {0}", minWordLen.AsString());
            return this;
        }

        /// <summary>
        /// The maximum word length above which words will be ignored.
        /// Defaults to unbounded (0).
        /// </summary>
        public MoreLikeThisFieldQuery<T> MaxWordLen(int maxWordLen = 0)
        {
            RegisterJsonPart("'max_word_len': {0}", maxWordLen.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost factor to use when boosting terms. Defaults to 1.
        /// </summary>
        public MoreLikeThisFieldQuery<T> BoostTerms(double boostTerms = 1)
        {
            RegisterJsonPart("'boost_terms': {0}", boostTerms.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public MoreLikeThisFieldQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public MoreLikeThisFieldQuery<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public MoreLikeThisFieldQuery<T> Analyzer(DefaultAnalyzers analyzer)
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
                return "{{ 'more_like_this_field': {{ {0} }} }}".AltQuoteF(body);

            return "{{ 'more_like_this_field': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }

    }
}