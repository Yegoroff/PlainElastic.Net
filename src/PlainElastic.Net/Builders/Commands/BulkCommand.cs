using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to perform many index/delete operations in a single API call.
    /// This can greatly increase the indexing speed. 
    /// http://www.elasticsearch.org/guide/reference/api/bulk.html
    /// </summary>
    public class BulkCommand: CommandBuilder<BulkCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }


        public BulkCommand(string index, string type = null)
        {
            Index = index;
            Type = type;
        }


        #region Query Parameters

        /// <summary>
        /// Requires a minimum number of active shards in the partition.
        /// It defaults to the node level setting of action.write_consistency, which in turn defaults to quorum.
        /// </summary>
        public BulkCommand Consistency(WriteConsistency consistency)
        {
            Parameters.Add("consistency", consistency.ToString());
            return this;
        }

        /// <summary>
        /// Allows to control Index operation replication.
        /// By default, the index operation only returns after all shards within the replication group have indexed the document (sync replication).
        /// To enable asynchronous replication, causing the replication process to take place in the background, 
        /// set the replication parameter to async. 
        /// When asynchronous replication is used, the index operation will return as soon as the operation succeeds on the primary shard.
        /// </summary>
        public BulkCommand Replication(DocumentReplication replication)
        {
            Parameters.Add("replication", replication.ToString());
            return this;
        }


        /// <summary>
        /// Allows to refresh the relevant shards immediately after the bulk operation has occurred and make it searchable,
        /// instead of waiting for the normal refresh interval to expire.
        /// Setting it to true can trigger additional load, and may slow down indexing.
        /// </summary>
        public BulkCommand Refresh(bool refresh = true)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, "_bulk");
        }
    }
}
