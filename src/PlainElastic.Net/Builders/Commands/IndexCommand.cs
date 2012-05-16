using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to create Index and add or update custom Json document in that Index.
    /// http://www.elasticsearch.org/guide/reference/api/index_.html
    /// </summary>
    public class IndexCommand: CommandBuilder<IndexCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }

        public string Id { get; private set; }


        /// <summary>
        /// Creates Index and adds or updates custom Json document in index.
        /// </summary>
        /// <param name="index">The name of the index.</param>
        /// <param name="type">The document type name. This parameter could be optional.</param>
        /// <param name="id">The id. If this parameter missing ID will automatically assigned. 
        /// Note to use POST request in this case.</param>
        public IndexCommand(string index, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        public IndexCommand Consistency(WriteConsistency consistency)
        {
            Parameters.Add("consistency", consistency.AsString());
            return this;
        }

        public IndexCommand OperationType(IndexOperation operation)
        {
            Parameters.Add("op_type", operation.AsString());
            return this;            
        }

        public IndexCommand Parent(string parentId)
        {
            Parameters.Add("parent", parentId);
            return this;
        }

        public IndexCommand Percolate(PercolateMode percolateMode, string color = null)
        {
            if (percolateMode == PercolateMode.All)
                Parameters.Add("percolate", "*");
            else
                Parameters.Add("percolate", "color:" + color);

            return this;
        }

        public IndexCommand Refresh(bool refresh = true)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }
        
        public IndexCommand Replication(DocumentReplication replication)
        {
            Parameters.Add("replication", replication.AsString());
            return this;
        }

        public IndexCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        public IndexCommand Timeout(string timeout)
        {
            Parameters.Add("timeout", timeout);
            return this;
        }

        public IndexCommand Timestamp(DateTime timestamp)
        {
            Parameters.Add("timestamp", timestamp.ToString("s"));
            return this;
        }

        public IndexCommand TTL(string timeToLive)
        {
            Parameters.Add("ttl", timeToLive);
            return this;
        }

        /// <summary>
        /// Allows to enable external versioning.
        /// By default internal versioning used,
        /// to supplemented version number with an external value (for example, if maintained in a database),
        /// version_type should be set to external
        /// </summary>
        public IndexCommand VersionType(VersionType versionType)
        {
            Parameters.Add("version_type", versionType.AsString());
            return this;
        }

        /// <summary>
        /// Allows to specify document version that will be used to 
        /// provide optimistic concurrency control.
        /// </summary>
        public IndexCommand Version(long version)
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
