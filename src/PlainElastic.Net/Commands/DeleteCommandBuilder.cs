namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to delete custom Json document in Index or delete whole Index.
    /// http://www.elasticsearch.org/guide/reference/api/delete.html
    /// </summary>
    public class DeleteCommandBuilder: CommandBuilder<DeleteCommandBuilder>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }

        public string Id { get; private set; }


        public DeleteCommandBuilder(string index, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        public DeleteCommandBuilder Consistency(WriteConsistency consistency)
        {
            Parameters.Add("consistency", consistency.ToString());
            return this;
        }

        public DeleteCommandBuilder Parent(string parentId)
        {
            Parameters.Add("parent", parentId);
            return this;
        }

        public DeleteCommandBuilder Refresh(bool refresh)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        public DeleteCommandBuilder Replication(DocumentReplication replication)
        {
            Parameters.Add("replication", replication.ToString());
            return this;
        }

        public DeleteCommandBuilder Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        public DeleteCommandBuilder Version(long version)
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
