using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to delete custom Json document in Index or delete whole Index.
    /// http://www.elasticsearch.org/guide/reference/api/delete.html
    /// </summary>
    public class DeleteCommand: CommandBuilder<DeleteCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }

        public string Id { get; private set; }


        public DeleteCommand(string index, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        /// <summary>
        /// Requires a minimum number of active shards in the partition.
        /// It defaults to the node level setting of action.write_consistency, which in turn defaults to quorum.
        /// </summary>
        public DeleteCommand Consistency(WriteConsistency consistency)
        {
            Parameters.Add("consistency", consistency.AsString());
            return this;
        }

        /// <summary>
        /// The parent parameter can be set, which will basically be the same as setting the routing parameter.
        /// Note that deleting a parent document does not automatically delete its children.
        /// </summary>
        public DeleteCommand Parent(string parentId)
        {
            Parameters.Add("parent", parentId);
            return this;
        }

        /// <summary>
        /// Allows to refresh the relevant shard after the delete operation has occurred and make it searchable. 
        /// Setting it to true should be done after careful thought and verification
        /// that this does not cause a heavy load on the system (and slows down indexing).
        /// </summary>
        public DeleteCommand Refresh(bool refresh = true)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        /// <summary>
        /// Allows to define the sync or async replication of the operation 
        /// When async the operation will return once it has be executed on the primary shard.
        /// The replication parameter can be set to async (defaults to sync) in order to enable it.
        /// </summary>
        public DeleteCommand Replication(DocumentReplication replication)
        {
            Parameters.Add("replication", replication.AsString());
            return this;
        }

        /// <summary>
        /// Allows to explicitly control, how the value fed into the hash function
        /// used by the router can be directly specified on a per-operation basis.
        /// </summary>
        public DeleteCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        /// <summary>
        /// Allows to specify a version of document to make sure the relevant document 
        /// we are trying to delete is actually being deleted and it has not changed in the meantime.
        /// </summary>
        public DeleteCommand Version(long version)
        {
            Parameters.Add("version", version.AsString());
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, Id);
        }
    }
}
