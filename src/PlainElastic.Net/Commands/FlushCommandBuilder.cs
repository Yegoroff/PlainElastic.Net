namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to flush one or more indices through an API. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-flush.html
    /// </summary>
    public class FlushCommandBuilder: CommandBuilder<FlushCommandBuilder>
    {
        public string Indexes { get; private set; }

        public string Types { get; private set; }


        public FlushCommandBuilder(string index = null, string type = null)
        {
            Indexes = index;
            Types = type;
        }

        public FlushCommandBuilder(string[] indexes, string[] types = null)
        {
            Indexes = indexes.JoinWithComma();
            Types = types.JoinWithComma();
        }


        #region Query Parameters

        public FlushCommandBuilder Refresh(bool refresh)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Indexes, Types, "_flush");
        }
    }
}
