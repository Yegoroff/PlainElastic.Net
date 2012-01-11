namespace PlainElastic.Net
{
    /// <summary>
    /// Provides shortcuts to Elastic Search command builders.
    /// </summary>
    public class ElasticCommands
    {

        public static GetCommandBuilder Get(string index = null, string type = null, string id = null)
        {
            return new GetCommandBuilder(index, type, id);
        }

        public static IndexCommandBuilder Index()
        {
            return new IndexCommandBuilder();
        }

        public static SearchCommand Search()
        {
            return new SearchCommand();
        }
    }
}