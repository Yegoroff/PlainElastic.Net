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
            WithParameter("analyzer", analyzer);
            return this;
        }

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public CountCommand Analyzer(DefaultAnalyzers analyzer)
        {
            WithParameter("analyzer", analyzer.AsString());
            return this;
        }

        /// <summary>
        /// The default field to use when no field prefix is defined within the query.
        /// </summary>
        public CountCommand Df(string defaultField)
        {
            WithParameter("df", defaultField);
            return this;
        }

        /// <summary>
        /// The default operator to be used, can be AND or OR. Defaults to OR
        /// </summary>
        public CountCommand DefaultOperator(Operator defaultOperator)
        {
            WithParameter("default_operator", defaultOperator.AsString());
            return this;
        }

        /// <summary>
        /// The query string (maps to the query_string query).
        /// </summary>
        public CountCommand Q(string query)
        {
            WithParameter("q", query);
            return this;
        }

        /// <summary>
        /// A comma separated list of the routing values to control which shards the count request will be executed on.
        /// </summary>
        public CountCommand Routing(string routing)
        {
            WithParameter("routing", routing);
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, "_count");
        }
    }
}