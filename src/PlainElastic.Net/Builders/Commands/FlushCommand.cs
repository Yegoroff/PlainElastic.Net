using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to flush one or more indices through an API. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-flush.html
    /// </summary>
    public class FlushCommand: CommandBuilder<FlushCommand>
    {
        public string Indexes { get; private set; }

        public string Types { get; private set; }


        public FlushCommand(string index = null, string type = null)
        {
            Indexes = index;
            Types = type;
        }

        public FlushCommand(string[] indexes, string[] types = null)
        {
            Indexes = indexes.JoinWithComma();
            Types = types.JoinWithComma();
        }


        #region Query Parameters

        public FlushCommand Refresh(bool refresh = true)
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
