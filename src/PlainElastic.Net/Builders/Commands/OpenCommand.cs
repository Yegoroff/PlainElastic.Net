using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to open an index. 
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-open-close.html
    /// </summary>
    public class OpenCommand: CommandBuilder<OpenCommand>
    {
        public string Index { get; private set; }


        public OpenCommand(string index = null)
        {
            Index = index;
        }



        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_open");
        }
    }
}
