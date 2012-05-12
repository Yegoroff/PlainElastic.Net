using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to easily execute a query and get the number of matches for that query. 
    /// It can be executed across one or more indices and across one or more types. 
    /// The query can either be provided using a simple query string as a parameter, 
    /// or using the Query DSL defined within the request body
    /// http://www.elasticsearch.org/guide/reference/api/count.html
    /// </summary>
    public class CountCommand : CommandBuilder<CountCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }


        public CountCommand(string index = null, string type = null)
        {
            Index = index;
            Type = type;
        }

        public CountCommand(string[] indexes, string[] types)
        {
            Index = indexes.JoinWithComma();
            Type = types.JoinWithComma();
        }


        #region Query Parameters

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public CountCommand Analyzer(string analyzer)
        {
            Parameters.Add("analyzer", analyzer);
            return this;
        }

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public CountCommand Analyzer(DefaultAnalyzers analyzer)
        {
            Parameters.Add("analyzer", analyzer.ToString());
            return this;
        }

        /// <summary>
        /// The default field to use when no field prefix is defined within the query.
        /// </summary>
        public CountCommand Df(string defaultField)
        {
            Parameters.Add("df", defaultField);
            return this;
        }

        /// <summary>
        /// The default operator to be used, can be AND or OR. Defaults to OR
        /// </summary>
        public CountCommand DefaultOperator(Operator defaultOperator)
        {
            Parameters.Add("default_operator", defaultOperator.ToString());
            return this;
        }

        /// <summary>
        /// The query string (maps to the query_string query).
        /// </summary>
        public CountCommand Q(string query)
        {
            Parameters.Add("q", query);
            return this;
        }

        /// <summary>
        /// A comma separated list of the routing values to control which shards the count request will be executed on.
        /// </summary>
        public CountCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        /// <summary>
        /// The type of the search operation to perform.
        /// Defaults to query_then_fetch.
        /// see http://www.elasticsearch.org/guide/reference/api/search/search-type.html
        /// </summary>
        public CountCommand SearchType(SearchType searchType)
        {
            Parameters.Add("search_type", searchType.ToString());
            return this;
        }


        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, "_count");
        }
    }
}