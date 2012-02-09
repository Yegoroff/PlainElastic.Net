namespace PlainElastic.Net
{
    /// <summary>
    /// Provides shortcuts to Elastic Search command builders.
    /// </summary>
    public class Commands
    {

        public static GetCommand Get(string index = null, string type = null, string id = null)
        {
            return new GetCommand(index, type, id);
        }

        public static IndexCommand Index(string index, string type = null, string id = null)
        {
            return new IndexCommand(index, type, id);
        }

        public static DeleteCommand Delete(string index, string type = null, string id = null)
        {
            return new DeleteCommand(index, type, id);
        }


        public static SearchCommand Search(string index = null, string type = null)
        {
            return new SearchCommand(index, type);
        }

        public static SearchCommand Search(string[] indexes, string[] types)
        {
            return new SearchCommand(indexes, types);
        }


        public static DeleteMappingCommand DeleteMapping(string index, string type = null)
        {
            return new DeleteMappingCommand(index, type);
        }


        public static PutMappingCommand PutMapping(string index = null, string type = null)
        {
            return new PutMappingCommand(index, type);
        }

        public static PutMappingCommand PutMapping(string[] indexes, string[] types)
        {
            return new PutMappingCommand(indexes, types);
        }


        public static GetMappingCommand GetMapping(string index, string type = null)
        {
            return new GetMappingCommand(index, type);
        }

        public static GetMappingCommand GetMapping(string[] indexes, string[] types)
        {
            return new GetMappingCommand(indexes, types);
        }


        public static FlushCommand Flush(string index = null, string type = null)
        {
            return new FlushCommand(index, type);
        }

        public static FlushCommand Flush(string[] indexes, string[] types)
        {
            return new FlushCommand(indexes, types);
        }


        public static IndexExistsCommand IndexExists(string index)
        {
            return new IndexExistsCommand(index);
        }

        public static CloseCommand Close(string index = null)
        {
            return new CloseCommand(index);
        }

        public static OpenCommand Open(string index = null)
        {
            return new OpenCommand(index);
        }

        public static UpdateSettingsCommand UpdateSettings(string index = null)
        {
            return new UpdateSettingsCommand(index);
        }
    
    }
}