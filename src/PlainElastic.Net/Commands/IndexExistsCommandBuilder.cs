namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows check if the index (indices) exists or not. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-indices-exists.html
    /// </summary>
    public class IndexExistsCommandBuilder : CommandBuilder<IndexExistsCommandBuilder>
    { 
        public string Index { get; private set; }


        public IndexExistsCommandBuilder(string index)
        {
            Index = index;
        }

        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index);
        }
    }
}
