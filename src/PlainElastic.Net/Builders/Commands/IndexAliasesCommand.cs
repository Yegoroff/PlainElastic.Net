using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Builders.Commands
{
    /// <summary>
    /// Supports post 0.90.1 index alias api for alias retrieval
    /// http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/indices-aliases.html
    /// </summary>
    public class IndexAliasesCommand : CommandBuilder<IndexAliasesCommand>
    {
        public string Index { get; set; }
        public string Alias { get; set; }

        public IndexAliasesCommand(string index = null, string alias = null)
        {
            Index = index;
            Alias = alias;
        }

        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_aliases", Alias);
        }
    }
}