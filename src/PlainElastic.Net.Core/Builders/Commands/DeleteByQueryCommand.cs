using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to delete documents from one or more indices and one or more types based on a query.
    /// http://www.elasticsearch.org/guide/reference/api/delete-by-query/
    /// </summary>
    public class DeleteByQueryCommand: CommandBuilder<DeleteByQueryCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }



        public DeleteByQueryCommand(string index, string type = null, string id = null)
        {
            Index = index;
            Type = type;
        }

        public DeleteByQueryCommand(string[] indexes, string[] types)
        {
            Index = indexes.JoinWithComma();
            Type = types.JoinWithComma();
        }



        #region Query Parameters

        /// <summary>
        /// The query string (maps to the query_string query).
        /// </summary>
        public DeleteByQueryCommand Q(string query)
        {
            WithParameter("q", query);
            return this;
        }

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public DeleteByQueryCommand Analyzer(string analyzer)
        {
            WithParameter("analyzer", analyzer);
            return this;
        }

        /// <summary>
        /// The analyzer name to be used when analyzing the query string.
        /// </summary>
        public DeleteByQueryCommand Analyzer(DefaultAnalyzers analyzer)
        {
            WithParameter("analyzer", analyzer.AsString());
            return this;
        }

        /// <summary>
        /// The default field to use when no field prefix is defined within the query.
        /// </summary>
        public DeleteByQueryCommand Df(string defaultField)
        {
            WithParameter("df", defaultField);
            return this;
        }

        /// <summary>
        /// The default operator to be used, can be AND or OR. Defaults to OR.
        /// </summary>
        public DeleteByQueryCommand DefaultOperator(Operator defaultOperator = Operator.OR)
        {
            WithParameter("default_operator", defaultOperator.AsString());
            return this;
        }


        /// <summary>
        ///  A timeout to wait if the index operation can't be performed immediately. Defaults to <tt>1m</tt>.
        /// </summary>
        public DeleteByQueryCommand Timeout(string timeout)
        {
            WithParameter("timeout", timeout);
            return this;
        }

        /// <summary>
        /// Allows to refresh the relevant shard after the delete operation has occurred and make it searchable. 
        /// Setting it to true should be done after careful thought and verification
        /// that this does not cause a heavy load on the system (and slows down indexing).
        /// </summary>
        public DeleteByQueryCommand Refresh(bool refresh = true)
        {
            WithParameter("refresh", refresh.AsString());
            return this;
        }

        /// <summary>
        /// Allows to define the sync or async replication of the operation 
        /// When async the operation will return once it has be executed on the primary shard.
        /// The replication parameter can be set to async (defaults to sync) in order to enable it.
        /// </summary>
        public DeleteByQueryCommand Replication(DocumentReplication replication)
        {
            WithParameter("replication", replication.AsString());
            return this;
        }


        /// <summary>
        /// Requires a minimum number of active shards in the partition.
        /// It defaults to the node level setting of action.write_consistency, which in turn defaults to quorum.
        /// </summary>
        public DeleteByQueryCommand Consistency(WriteConsistency consistency)
        {
            WithParameter("consistency", consistency.AsString());
            return this;
        }

        /// <summary>
        /// The routing value (a comma separated list of the routing values) 
        /// can be specified to control which shards the delete by query request will be executed on.        
        /// </summary>
        public DeleteByQueryCommand Routing(string routing)
        {
            WithParameter("routing", routing);
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, "_query");
        }
    }
}
