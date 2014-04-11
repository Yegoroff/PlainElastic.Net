using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Builders.Commands
{
    /// <summary>
    /// Supports post 0.90.1 index alias api for single alias management
    /// http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/indices-aliases.html
    /// </summary>
    public class IndexAliasCommand : CommandBuilder<IndexAliasCommand>
    {
        public enum IgnoreIndicesOption
        {
            None,
            Missing
        }

        public string Index { get; set; }
        public string Alias { get; set; }

        public IndexAliasCommand IgnoreIndices(IgnoreIndicesOption? value = null)
        {
            WithParameter("ignore_indices", value.ToString().ToLowerInvariant());
            return this;
        }

        public IndexAliasCommand(string index = null, string alias = null)
        {
            Index = index;
            Alias = alias;
        }

        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_alias", Alias);
        }
    }
}
