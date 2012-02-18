using System;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to execute a search query and get back search hits that match the query.
    /// http://www.elasticsearch.org/guide/reference/api/search/uri-request.html
    /// </summary>
    public class SearchCommand : CommandBuilder<SearchCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }


        public SearchCommand(string index = null, string type = null)
        {
            Index = index;
            Type = type;
        }

        public SearchCommand(string[] indexes, string[] types)
        {
            Index = indexes.JoinWithComma();
            Type = types.JoinWithComma();
        }


        #region Query Parameters

        public SearchCommand Analyzer(string analyzer)
        {
            Parameters.Add("analyzer", analyzer);
            return this;
        }

        public SearchCommand AnalyzeWildcard(bool analyzeWildcard = false)
        {
            Parameters.Add("analyze_wildcard", analyzeWildcard.AsString());
            return this;
        }

        public SearchCommand Df(string defaultField)
        {
            Parameters.Add("df", defaultField);
            return this;
        }

        public SearchCommand DefaultOperator(DefaultQueryOperator defaultOperator)
        {
            Parameters.Add("default_operator", defaultOperator.ToString());
            return this;
        }

        public SearchCommand Explain()
        {
            Parameters.Add("explain", "true");
            return this;
        }

        /// <summary>
        /// The selective fields of the document to return for each hit.
        /// </summary>
        public SearchCommand Fields(string fields)
        {
            Parameters.Add("fields", fields);
            return this;
        }

        /// <summary>
        /// The selective fields of the document to return for each hit.
        /// </summary>
        public SearchCommand Fields<T>(params Expression<Func<T, object>>[] properties)
        {
            string fields = properties.Select(prop => prop.GetPropertyName()).JoinWithComma();
            Parameters.Add("fields", fields);
            return this;
        }

        /// <summary>
        /// The starting from index of the hits to return. Defaults to 0.
        /// </summary>
        public SearchCommand From(int fromIndex = 0)
        {
            Parameters.Add("from", fromIndex.AsString());
            return this;
        }

        public SearchCommand LowercaseExpandedTerms(bool lowercaseExpandedTerms = true)
        {
            Parameters.Add("lowercase_expanded_terms", lowercaseExpandedTerms.AsString());
            return this;

        }

        public SearchCommand Q(string query)
        {
            Parameters.Add("q", query);
            return this;
        }

        public SearchCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        public SearchCommand Scroll(string scrollActiveTime)
        {
            Parameters.Add("scroll", scrollActiveTime);
            return this;
        }

        public SearchCommand SearchType(SearchType searchType)
        {
            Parameters.Add("search_type", searchType.ToString());
            return this;
        }

        /// <summary>
        /// The number of hits to return. Defaults to 10.
        /// </summary>
        public SearchCommand Size(int size = 10)
        {
            Parameters.Add("size", size.AsString());
            return this;
        }

        /// <summary>
        /// Sorting to perform. There can be several Sort parameters (order is important).
        /// Use "_score" to sort by query score.
        /// </summary>
        public SearchCommand Sort(string fieldname, SortDirection direction)
        {
            Parameters.Add("sort", fieldname + ":" + direction.ToString());
            return this;            
        }

        /// <summary>
        /// Sorting to perform. There can be several Sort parameters (order is important).
        /// </summary>
        public SearchCommand Sort<T>(Expression<Func<T, object>> property, SortDirection direction)
        {
            string fieldname = property.GetPropertyName();
            Parameters.Add("sort", fieldname + ":" + direction.ToString());
            return this;            
        }


        public SearchCommand Timeout(string timeout)
        {
            Parameters.Add("timeout", timeout);
            return this;
        }

        public SearchCommand TrackScores(bool trackScores)
        {
            Parameters.Add("track_scores", trackScores.AsString());
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, "_search");
        }
    }
}