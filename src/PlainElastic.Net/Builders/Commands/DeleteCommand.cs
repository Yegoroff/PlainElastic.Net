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

        public DeleteCommand Consistency(WriteConsistency consistency)
        {
            Parameters.Add("consistency", consistency.ToString());
            return this;
        }

        public DeleteCommand Parent(string parentId)
        {
            Parameters.Add("parent", parentId);
            return this;
        }

        public DeleteCommand Refresh(bool refresh = true)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        public DeleteCommand Replication(DocumentReplication replication)
        {
            Parameters.Add("replication", replication.ToString());
            return this;
        }

        public DeleteCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

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
