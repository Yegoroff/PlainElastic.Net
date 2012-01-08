namespace PlainElastic.Net
{
    public class ElasticCommands
    {

        public static GetCommand Get(string index, string type, string id)
        {
            return new GetCommand();
        }

        public static GetCommand Get()
        {
            return new GetCommand();
        }


        public static IndexCommand Index(string index, string type = null, string id = null)
        {
            return new IndexCommand();
        }



        public static SearchCommand Search()
        {
            return new SearchCommand();
        }

        public static SearchCommand Search(string index, string type)
        {
            throw new System.NotImplementedException();
        }
    }
}