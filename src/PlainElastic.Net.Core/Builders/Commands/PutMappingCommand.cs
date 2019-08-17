using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to register specific mapping definition for a specific type.
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-put-mapping.html
    /// </summary>
    public class PutMappingCommand: CommandBuilder<PutMappingCommand>
    {
        public string Indexes { get; private set; }

        public string Types { get; private set; }


        public PutMappingCommand(string index, string type = null)
        {
            Indexes = index;
            Types = type;
        }

        public PutMappingCommand(string[] indexes, string[] types = null)
        {
            Indexes = indexes.JoinWithComma();
            Types = types.JoinWithComma();
        }


        #region Query Parameters

        /// <summary>
        /// Used to control if conflicts should be ignored or not, by default, it is set to false which means conflicts are not ignored.
        /// </summary>
        public PutMappingCommand IgnoreConflicts(bool ignore)
        {
            WithParameter("ignore_conflicts", ignore.AsString());
            return this;
        }

        #endregion
 

        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Indexes, Types, "_mapping");
        }
    }
}
