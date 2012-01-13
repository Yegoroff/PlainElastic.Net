using System;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to create Index and add or update custom Json document in that Index.
    /// </summary>
    public class IndexCommandBuilder: CommandBuilder<IndexCommandBuilder>
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
        public IndexCommandBuilder(string index, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        public IndexCommandBuilder Consistency(WriteConsistency consistency)
        {
            Parameters.Add("consistency", consistency.ToString());
            return this;
        }

        public IndexCommandBuilder OperationType(IndexOperation operation)
        {
            Parameters.Add("op_type", operation.ToString());
            return this;            
        }

        public IndexCommandBuilder Parent(string parentId)
        {
            Parameters.Add("parent", parentId);
            return this;
        }

        public IndexCommandBuilder Percolate(PercolateMode percolateMode, string color = null)
        {
            if (percolateMode == PercolateMode.All)
                Parameters.Add("percolate", "*");
            else
                Parameters.Add("percolate", "color:" + color);

            return this;
        }

        public IndexCommandBuilder Refresh(bool refresh)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }
        
        public IndexCommandBuilder Replication(DocumentReplication replication)
        {
            Parameters.Add("replication", replication.ToString());
            return this;
        }

        public IndexCommandBuilder Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        public IndexCommandBuilder Timeout(string timeout)
        {
            Parameters.Add("timeout", timeout);
            return this;
        }

        public IndexCommandBuilder Timestamp(DateTime timestamp)
        {
            Parameters.Add("timestamp", timestamp.ToString("s"));
            return this;
        }

        public IndexCommandBuilder TTL(string timeToLive)
        {
            Parameters.Add("ttl", timeToLive);
            return this;
        }

        public IndexCommandBuilder Version(long version)
        {
            Parameters.Add("version", version.ToString());
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, Id);
        }
    }
}
