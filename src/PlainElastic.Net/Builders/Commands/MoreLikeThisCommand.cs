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


        public MoreLikeThisCommand(string index = null, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        public MoreLikeThisCommand MltFields(string fields)
        {
            Parameters.Add("mlt_fields", fields);
            return this;
        }

        public MoreLikeThisCommand MltFields<T>(params Expression<Func<T, object>>[] properties)
        {
            string fields = properties.Select(prop => prop.GetPropertyPath()).JoinWithComma();
            Parameters.Add("mlt_fields", fields);
            return this;
        }


        public MoreLikeThisCommand PercentTermsToMatch(double value)
        {
            Parameters.Add("percent_terms_to_match", value.AsString());
            return this;
        }

        public MoreLikeThisCommand MinTermFreq(int value)
        {
            Parameters.Add("min_term_freq", value.AsString());
            return this;
        }

        public MoreLikeThisCommand MaxQueryTerms(int value)
        {
            Parameters.Add("max_query_terms", value.AsString());
            return this;
        }

        public MoreLikeThisCommand StopWords(params string[] terms)
        {
            Parameters.Add("stop_words", terms.JoinWithComma());
            return this;
        }

        public MoreLikeThisCommand MinDocFreq(int value)
        {
            Parameters.Add("min_doc_freq", value.AsString());
            return this;
        }

        public MoreLikeThisCommand MaxDocFreq(int value)
        {
            Parameters.Add("max_doc_freq", value.AsString());
            return this;
        }

        public MoreLikeThisCommand MinWordLen(int value)
        {
            Parameters.Add("min_word_len", value.AsString());
            return this;
        }

        public MoreLikeThisCommand MaxWordLen(int value)
        {
            Parameters.Add("max_word_len", value.AsString());
            return this;
        }

        public MoreLikeThisCommand BoostTerms(int value)
        {
            Parameters.Add("boost_terms", value.AsString());
            return this;
        }

        public MoreLikeThisCommand Boost(double value)
        {
            Parameters.Add("boost", value.AsString());
            return this;
        }


        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, Id, "_mlt");
        }

    }
}