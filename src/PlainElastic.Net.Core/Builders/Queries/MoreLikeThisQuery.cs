using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// More like this query find documents that are “like” provided text by running it against one or more fields.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/mlt-query.html
    /// </summary>
    public class MoreLikeThisQuery<T> : QueryBase<MoreLikeThisQuery<T>>
    {

        private readonly List<string> queryFields = new List<string>();

        private bool hasValue;


        /// <summary>
        /// A list of the fields to run the more like this query against.
        /// Defaults to the _all field.
        /// </summary>
        public MoreLikeThisQuery<T> Fields(params string[] fields)
        {
            queryFields.AddRange(fields);
            return this;
        }

        /// <summary>
        /// A list of the fields to run the more like this query against.
        /// Defaults to the _all field.
        /// </summary>
        public MoreLikeThisQuery<T> Fields(params Expression<Func<T, object>>[] fields)
        {
            foreach (var field in fields)
                queryFields.Add(field.GetPropertyPath());

            return this;
        }

        /// <summary>
        /// A list of the fields to run the more like this query against.
        /// Defaults to the _all field.
        /// </summary>
        public MoreLikeThisQuery<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
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
        /// The text to use in order to find documents that are "like" this.
        /// </summary>
        public MoreLikeThisQuery<T> LikeText(string likeText)
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
        public MoreLikeThisQuery<T> PercentTermsToMatch(double percentTermsToMatch = 0.3)
        {
            RegisterJsonPart("'percent_terms_to_match': {0}", percentTermsToMatch.AsString());
            return this;
        }

        /// <summary>
        /// The frequency below which terms will be ignored in the source doc. The default frequency is 2.
        /// </summary>
        public MoreLikeThisQuery<T> MinTermFreq(int minTermFreq = 2)
        {
            RegisterJsonPart("'min_term_freq': {0}", minTermFreq.AsString());
            return this;
        }

        /// <summary>
        /// The maximum number of query terms that will be included in any generated query.
        /// Defaults to 25.
        /// </summary>
        public MoreLikeThisQuery<T> MaxQueryTerms(int maxQueryTerms = 25)
        {
            RegisterJsonPart("'max_query_terms': {0}", maxQueryTerms.AsString());
            return this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public MoreLikeThisQuery<T> StopWords(IEnumerable<string> stopwords)
        {
            string propertyJson = JsonHelper.BuildJsonStringsProperty("stop_words", stopwords);
            RegisterJsonPart(propertyJson);
            return this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public MoreLikeThisQuery<T> StopWords(params string[] stopwords)
        {
            return StopWords((IEnumerable<string>)stopwords);
        }

        /// <summary>
        /// The frequency at which words will be ignored which do not occur in at least this many docs.
        /// Defaults to 5.
        /// </summary>
        public MoreLikeThisQuery<T> MinDocFreq(int minDocFreq = 5)
        {
            RegisterJsonPart("'min_doc_freq': {0}", minDocFreq.AsString());
            return this;
        }

        /// <summary>
        /// The maximum frequency in which words may still appear. Words that appear in more than this many docs will be ignored.
        /// Defaults to unbounded.
        /// </summary>
        public MoreLikeThisQuery<T> MaxDocFreq(int maxDocFreq)
        {
            RegisterJsonPart("'max_doc_freq': {0}", maxDocFreq.AsString());
            return this;
        }

        /// <summary>
        /// The minimum word length below which words will be ignored. Defaults to 0.
        /// </summary>
        public MoreLikeThisQuery<T> MinWordLen(int minWordLen = 0)
        {
            RegisterJsonPart("'min_word_len': {0}", minWordLen.AsString());
            return this;
        }

        /// <summary>
        /// The maximum word length above which words will be ignored.
        /// Defaults to unbounded (0).
        /// </summary>
        public MoreLikeThisQuery<T> MaxWordLen(int maxWordLen = 0)
        {
            RegisterJsonPart("'max_word_len': {0}", maxWordLen.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost factor to use when boosting terms. Defaults to 1.
        /// </summary>
        public MoreLikeThisQuery<T> BoostTerms(double boostTerms = 1)
        {
            RegisterJsonPart("'boost_terms': {0}", boostTerms.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public MoreLikeThisQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public MoreLikeThisQuery<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public MoreLikeThisQuery<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
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
                body = new[] {fields, body}.JoinWithComma();
            }

            return "{{ 'more_like_this': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}