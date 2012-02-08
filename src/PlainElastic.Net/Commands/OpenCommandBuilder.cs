namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to open an index. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-open-close.html
    /// </summary>
    public class OpenCommandBuilder: CommandBuilder<OpenCommandBuilder>
    {
        public string Index { get; private set; }


        public OpenCommandBuilder(string index = null)
        {
            Index = index;
        }



        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_open");
        }
    }
}
