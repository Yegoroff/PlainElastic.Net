using System;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// The more like this (mlt) API allows to get documents that are “like” a specified document.
    /// http://www.elasticsearch.org/guide/reference/api/more-like-this.html
    /// </summary>
    public class MoreLikeThisCommand : CommandBuilder<MoreLikeThisCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }

        public string Id { get; private set; }


        public MoreLikeThisCommand(string index, string type, string id)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        /// <summary>
        /// A list of the fields to run the more like this query against. Defaults to the _all field
        /// </summary>
        public MoreLikeThisCommand MltFields(string fields)
        {
            Parameters.Add("mlt_fields", fields);
            return this;
        }

        /// <summary>
        /// A list of the fields to run the more like this query against. Defaults to the _all field
        /// </summary>
        public MoreLikeThisCommand MltFields<T>(params Expression<Func<T, object>>[] properties)
        {
            string fields = properties.Select(prop => prop.GetPropertyPath()).JoinWithComma();
            Parameters.Add("mlt_fields", fields);
            return this;
        }

        /// <summary>
        /// The percentage of terms to match on (float value). Defaults to 0.3 (30 percent).
        /// </summary>
        public MoreLikeThisCommand PercentTermsToMatch(double value)
        {
            Parameters.Add("percent_terms_to_match", value.AsString());
            return this;
        }

        /// <summary>
        /// The frequency below which terms will be ignored in the source doc. The default frequency is 2.
        /// </summary>
        public MoreLikeThisCommand MinTermFreq(int value)
        {
            Parameters.Add("min_term_freq", value.AsString());
            return this;
        }

        /// <summary>
        /// The maximum number of query terms that will be included in any generated query.
        /// Defaults to 25.
        /// </summary>
        public MoreLikeThisCommand MaxQueryTerms(int value)
        {
            Parameters.Add("max_query_terms", value.AsString());
            return this;
        }

        /// <summary>
        /// Sets a list of stopwords to initialize the stop filter with.
        /// Defaults to the language stop words.
        /// </summary>
        public MoreLikeThisCommand StopWords(params string[] terms)
        {
            Parameters.Add("stop_words", terms.JoinWithComma());
            return this;
        }

        /// <summary>
        /// The frequency at which words will be ignored which do not occur in at least this many docs.
        /// Defaults to 5.
        /// </summary>
        public MoreLikeThisCommand MinDocFreq(int value)
        {
            Parameters.Add("min_doc_freq", value.AsString());
            return this;
        }

        /// <summary>
        /// The maximum frequency in which words may still appear. Words that appear in more than this many docs will be ignored.
        /// Defaults to unbounded.
        /// </summary>
        public MoreLikeThisCommand MaxDocFreq(int value)
        {
            Parameters.Add("max_doc_freq", value.AsString());
            return this;
        }

        /// <summary>
        /// The minimum word length below which words will be ignored. Defaults to 0.
        /// </summary>
        public MoreLikeThisCommand MinWordLen(int value)
        {
            Parameters.Add("min_word_len", value.AsString());
            return this;
        }

        /// <summary>
        /// The maximum word length above which words will be ignored.
        /// Defaults to unbounded (0).
        /// </summary>
        public MoreLikeThisCommand MaxWordLen(int value)
        {
            Parameters.Add("max_word_len", value.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost factor to use when boosting terms. Defaults to 1.
        /// </summary>
        public MoreLikeThisCommand BoostTerms(int value)
        {
            Parameters.Add("boost_terms", value.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public MoreLikeThisCommand Boost(double value)
        {
            Parameters.Add("boost", value.AsString());
            return this;
        }

        /// <summary>
        /// The type of the search operation to perform.
        /// Defaults to query_then_fetch.
        /// see http://www.elasticsearch.org/guide/reference/api/search/search-type.html
        /// </summary>
        public MoreLikeThisCommand SearchType(SearchType searchType)
        {
            Parameters.Add("search_type", searchType.AsString());
            return this;
        }

        /// <summary>
        /// Indices to search within.
        /// </summary>
        public MoreLikeThisCommand SearchIndices(string [] indices)
        {
            Parameters.Add("search_indices", indices.JoinWithComma());
            return this;
        }

        /// <summary>
        /// Types to search within.
        /// </summary>
        public MoreLikeThisCommand SearchTypes(string [] types)
        {
            Parameters.Add("search_types", types.JoinWithComma());
            return this;
        }
        
        public MoreLikeThisCommand SearchQueryHint(string searchQueryHint)
        {
            Parameters.Add("search_query_hint", searchQueryHint);
            return this;
        }

        /// <summary>
        /// The starting from index of the hits to return. Defaults to 0.
        /// </summary>
        public MoreLikeThisCommand SearchFrom(int fromIndex = 0)
        {
            Parameters.Add("search_from", fromIndex.AsString());
            return this;
        }

        /// <summary>
        /// The number of hits to return. Defaults to 10.
        /// </summary>
        public MoreLikeThisCommand SearchSize(int search_size = 10)
        {
            Parameters.Add("search_size", search_size.AsString());
            return this;
        }
        

        /// <summary>
        /// The scroll parameter is a time value parameter (for example: scroll=5m), 
        /// indicating for how long the nodes that participate in the search will maintain relevant resources in order to continue and support it.
        /// see http://www.elasticsearch.org/guide/reference/api/search/scroll.html
        /// </summary>
        public MoreLikeThisCommand SearchScroll(string scrollActiveTime)
        {
            Parameters.Add("search_scroll", scrollActiveTime);
            return this;
        }

        public MoreLikeThisCommand SearchSource(string searchSource)
        {
            Parameters.Add("search_source", searchSource);
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, Id, "_mlt");
        }

    }
}