namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to close an index. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-open-close.html
    /// </summary>
    public class CloseCommand: CommandBuilder<CloseCommand>
    {
        public string Index { get; private set; }


        public CloseCommand(string index = null)
        {
            Index = index;
        }



        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_close");
        }
    }
}
