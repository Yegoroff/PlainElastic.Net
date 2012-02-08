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

        public static IndexCommandBuilder Index(string index, string type = null, string id = null)
        {
            return new IndexCommandBuilder(index, type, id);
        }

        public static DeleteCommandBuilder Delete(string index, string type = null, string id = null)
        {
            return new DeleteCommandBuilder(index, type, id);
        }


        public static SearchCommandBuilder Search(string index = null, string type = null)
        {
            return new SearchCommandBuilder(index, type);
        }

        public static SearchCommandBuilder Search(string[] indexes, string[] types)
        {
            return new SearchCommandBuilder(indexes, types);
        }


        public static DeleteMappingCommandBuilder DeleteMapping(string index, string type = null)
        {
            return new DeleteMappingCommandBuilder(index, type);
        }


        public static PutMappingCommandBuilder PutMapping(string index = null, string type = null)
        {
            return new PutMappingCommandBuilder(index, type);
        }

        public static PutMappingCommandBuilder PutMapping(string[] indexes, string[] types)
        {
            return new PutMappingCommandBuilder(indexes, types);
        }


        public static GetMappingCommandBuilder GetMapping(string index, string type = null)
        {
            return new GetMappingCommandBuilder(index, type);
        }

        public static GetMappingCommandBuilder GetMapping(string[] indexes, string[] types)
        {
            return new GetMappingCommandBuilder(indexes, types);
        }


        public static FlushCommandBuilder Flush(string index = null, string type = null)
        {
            return new FlushCommandBuilder(index, type);
        }

        public static FlushCommandBuilder Flush(string[] indexes, string[] types)
        {
            return new FlushCommandBuilder(indexes, types);
        }


        public static IndexExistsCommandBuilder IndexExists(string index)
        {
            return new IndexExistsCommandBuilder(index);
        }

        public static CloseCommandBuilder Close(string index = null)
        {
            return new CloseCommandBuilder(index);
        }

        public static OpenCommandBuilder Open(string index = null)
        {
            return new OpenCommandBuilder(index);
        }

        public static UpdateSettingsCommandBuilder UpdateSettings(string index = null)
        {
            return new UpdateSettingsCommandBuilder(index);
        }
    
    }
}