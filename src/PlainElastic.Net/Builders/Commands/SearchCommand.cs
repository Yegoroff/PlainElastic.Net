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

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public SearchCommand Analyzer(string analyzer)
        {
            Parameters.Add("analyzer", analyzer);
            return this;
        }

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public SearchCommand Analyzer(DefaultAnalizers analyzer)
        {
            Parameters.Add("analyzer", analyzer.ToString());
            return this;
        }



        /// <summary>
        /// Should wildcard and prefix queries be analyzed or not. Defaults to false.
        /// </summary>
        public SearchCommand AnalyzeWildcard(bool analyzeWildcard = false)
        {
            Parameters.Add("analyze_wildcard", analyzeWildcard.AsString());
            return this;
        }

        /// <summary>
        /// The default field to use when no field prefix is defined within the query.
        /// </summary>
        public SearchCommand Df(string defaultField)
        {
            Parameters.Add("df", defaultField);
            return this;
        }

        /// <summary>
        /// The default operator to be used, can be AND or OR. Defaults to OR.
        /// </summary>
        public SearchCommand DefaultOperator(Operator defaultOperator = Operator.OR)
        {
            Parameters.Add("default_operator", defaultOperator.ToString());
            return this;
        }

        /// <summary>
        /// Includes explanation of how scoring of the hits was computed for each hit.
        /// </summary>
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
            string fields = properties.Select(prop => prop.GetPropertyPath()).JoinWithComma();
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

        /// <summary>
        /// Determines whether terms should be automatically lowercased or not. Defaults to true.
        /// </summary>
        public SearchCommand LowercaseExpandedTerms(bool lowercaseExpandedTerms = true)
        {
            Parameters.Add("lowercase_expanded_terms", lowercaseExpandedTerms.AsString());
            return this;

        }


        /// <summary>
        /// The query string (maps to the query_string query).
        /// </summary>
        public SearchCommand Q(string query)
        {
            Parameters.Add("q", query);
            return this;
        }

        /// <summary>
        /// A comma separated list of the routing values to control which shards the count request will be executed on.
        /// </summary>
        public SearchCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        /// <summary>
        /// The scroll parameter is a time value parameter (for example: scroll=5m), 
        /// indicating for how long the nodes that participate in the search will maintain relevant resources in order to continue and support it.
        /// see http://www.elasticsearch.org/guide/reference/api/search/scroll.html
        /// </summary>
        public SearchCommand Scroll(string scrollActiveTime)
        {
            Parameters.Add("scroll", scrollActiveTime);
            return this;
        }

        /// <summary>
        /// The type of the search operation to perform.
        /// Defaults to query_then_fetch.
        /// see http://www.elasticsearch.org/guide/reference/api/search/search-type.html
        /// </summary>
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
        public SearchCommand Sort(string fieldname, SortDirection direction = SortDirection.@default)
        {
            string value = fieldname;
            if (direction != SortDirection.@default)
                value += ":" + direction.ToString();

            Parameters.Add("sort", value);
            return this;
        }

        /// <summary>
        /// Sorting to perform. There can be several Sort parameters (order is important).
        /// </summary>
        public SearchCommand Sort<T>(Expression<Func<T, object>> property, SortDirection direction = SortDirection.@default)
        {
            string fieldname = property.GetPropertyPath();
            return Sort(fieldname, direction);
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