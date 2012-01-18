using System;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to execute a search query and get back search hits that match the query.
    /// </summary>
    public class SearchCommandBuilder : CommandBuilder<SearchCommandBuilder>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }


        public SearchCommandBuilder(string index = null, string type = null)
        {
            Index = index;
            Type = type;
        }

        public SearchCommandBuilder(string[] indexes, string[] types)
        {
            Index = indexes.JoinWithComma();
            Type = types.JoinWithComma();
        }


        #region Query Parameters

        public SearchCommandBuilder Analyzer(string analyzer)
        {
            Parameters.Add("analyzer", analyzer);
            return this;
        }

        public SearchCommandBuilder AnalyzeWildcard(bool analyzeWildcard = false)
        {
            Parameters.Add("analyze_wildcard", analyzeWildcard.AsString());
            return this;
        }

        public SearchCommandBuilder Df(string defaultField)
        {
            Parameters.Add("df", defaultField);
            return this;
        }

        public SearchCommandBuilder DefaultOperator(DefaultQueryOperator defaultOperator)
        {
            Parameters.Add("default_operator", defaultOperator.ToString());
            return this;
        }

        public SearchCommandBuilder Explain()
        {
            Parameters.Add("explain", "true");
            return this;
        }

        /// <summary>
        /// The selective fields of the document to return for each hit.
        /// </summary>
        public SearchCommandBuilder Fields(string fields)
        {
            Parameters.Add("fields", fields);
            return this;
        }

        /// <summary>
        /// The selective fields of the document to return for each hit.
        /// </summary>
        public SearchCommandBuilder Fields<T>(params Expression<Func<T, object>>[] properties)
        {
            string fields = properties.Select(prop => prop.GePropertyName()).JoinWithComma();
            Parameters.Add("fields", fields);
            return this;
        }

        /// <summary>
        /// The starting from index of the hits to return. Defaults to 0.
        /// </summary>
        public SearchCommandBuilder From(int fromIndex = 0)
        {
            Parameters.Add("from", fromIndex.ToString());
            return this;
        }

        public SearchCommandBuilder LowercaseExpandedTerms(bool lowercaseExpandedTerms = true)
        {
            Parameters.Add("lowercase_expanded_terms", lowercaseExpandedTerms.AsString());
            return this;

        }

        public SearchCommandBuilder Q(string query)
        {
            Parameters.Add("q", query);
            return this;
        }

        public SearchCommandBuilder Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        public SearchCommandBuilder Scroll(string scrollActiveTime)
        {
            Parameters.Add("scroll", scrollActiveTime);
            return this;
        }

        public SearchCommandBuilder SearchType(SearchType searchType)
        {
            Parameters.Add("search_type", searchType.ToString());
            return this;
        }

        /// <summary>
        /// The number of hits to return. Defaults to 10.
        /// </summary>
        public SearchCommandBuilder Size(int size = 10)
        {
            Parameters.Add("size", size.ToString());
            return this;
        }

        /// <summary>
        /// Sorting to perform. There can be several Sort parameters (order is important).
        /// Use "_score" to sort by query score.
        /// </summary>
        public SearchCommandBuilder Sort(string fieldname, SortDirection direction)
        {
            Parameters.Add("sort", fieldname + ":" + direction.ToString());
            return this;            
        }

        /// <summary>
        /// Sorting to perform. There can be several Sort parameters (order is important).
        /// </summary>
        public SearchCommandBuilder Sort<T>(Expression<Func<T, object>> property, SortDirection direction)
        {
            string fieldname = property.GePropertyName();
            Parameters.Add("sort", fieldname + ":" + direction.ToString());
            return this;            
        }


        public SearchCommandBuilder Timeout(string timeout)
        {
            Parameters.Add("timeout", timeout);
            return this;
        }

        public SearchCommandBuilder TrackScores(bool trackScores)
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