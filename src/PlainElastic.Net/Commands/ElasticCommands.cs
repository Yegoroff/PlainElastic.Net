namespace PlainElastic.Net
{
    /// <summary>
    /// Provides shortcuts to Elastic Search command builders.
    /// </summary>
    public class ElasticCommands
    {

        public static GetCommandBuilder Get()
        {
            return new GetCommandBuilder();
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