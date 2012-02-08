namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to close an index. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-open-close.html
    /// </summary>
    public class CloseCommandBuilder: CommandBuilder<CloseCommandBuilder>
    {
        public string Index { get; private set; }


        public CloseCommandBuilder(string index = null)
        {
            Index = index;
        }



        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_close");
        }
    }
}
