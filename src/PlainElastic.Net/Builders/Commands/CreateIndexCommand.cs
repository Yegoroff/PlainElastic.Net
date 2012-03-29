using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows  to instantiate an index. 
    /// ElasticSearch provides support for multiple indices, 
    /// including executing operations across several indices.
    /// Each index created can have specific settings associated with it.
    /// see http://www.elasticsearch.org/guide/reference/api/admin-indices-create-index.html
    /// </summary>
    public class CreateIndexCommand: CommandBuilder<CreateIndexCommand>
    {
        public string Index { get; private set; }


        public CreateIndexCommand(string index)
        {
            Index = index;
        }

        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index);
        }
    }
}
