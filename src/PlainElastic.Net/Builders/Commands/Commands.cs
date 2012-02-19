namespace PlainElastic.Net
{
    /// <summary>
    /// Provides shortcuts to Elastic Search command builders.
    /// </summary>
    public class Commands
    {

        /// <summary>
        /// Builds a command that allows to get a typed JSON document from the index based on its id.
        /// http://www.elasticsearch.org/guide/reference/api/get.html
        /// </summary>
        public static GetCommand Get(string index = null, string type = null, string id = null)
        {
            return new GetCommand(index, type, id);
        }

        /// <summary>
        /// Builds a command that allows to create Index and add or update custom Json document in that Index.
        /// http://www.elasticsearch.org/guide/reference/api/index_.html
        /// </summary>
        public static IndexCommand Index(string index, string type = null, string id = null)
        {
            return new IndexCommand(index, type, id);
        }

        /// <summary>
        /// Builds a command that allows to delete custom Json document in Index or delete whole Index.
        /// http://www.elasticsearch.org/guide/reference/api/delete.html
        /// </summary>
        public static DeleteCommand Delete(string index, string type = null, string id = null)
        {
            return new DeleteCommand(index, type, id);
        }

        /// <summary>
        /// Builds a command that allows to execute a search query and get back search hits that match the query.
        /// http://www.elasticsearch.org/guide/reference/api/search/uri-request.html
        /// </summary>
        public static SearchCommand Search(string index = null, string type = null)
        {
            return new SearchCommand(index, type);
        }

        /// <summary>
        /// Builds a command that allows to execute a search query and get back search hits that match the query.
        /// http://www.elasticsearch.org/guide/reference/api/search/uri-request.html
        /// </summary>
        public static SearchCommand Search(string[] indexes, string[] types)
        {
            return new SearchCommand(indexes, types);
        }


        /// <summary>
        /// Builds a command that allows to delete a mapping (type) along with its data.
        /// Note, most times, it make more sense to reindex the data into a fresh index compared to delete large chunks of it.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-delete-mapping.html
        /// </summary>
        public static DeleteMappingCommand DeleteMapping(string index, string type = null)
        {
            return new DeleteMappingCommand(index, type);
        }


        /// <summary>
        /// Builds a command that allows to register specific mapping definition for a specific type.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-put-mapping.html
        /// </summary>
        public static PutMappingCommand PutMapping(string index = null, string type = null)
        {
            return new PutMappingCommand(index, type);
        }

        /// <summary>
        /// Builds a command that allows to register specific mapping definition for a specific type.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-put-mapping.html
        /// </summary>
        public static PutMappingCommand PutMapping(string[] indexes, string[] types)
        {
            return new PutMappingCommand(indexes, types);
        }


        /// <summary>
        /// Builds a command that allows to retrieve mapping definition of index or index/type.
        /// To get mappings for all indices you can use _all for "index"
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-get-mapping.html
        /// </summary>
        public static GetMappingCommand GetMapping(string index, string type = null)
        {
            return new GetMappingCommand(index, type);
        }

        /// <summary>
        /// Builds a command that allows to retrieve mapping definition of index or index/type.
        /// To get mappings for all indices you can use _all for "index"
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-get-mapping.html
        /// </summary>
        public static GetMappingCommand GetMapping(string[] indexes, string[] types)
        {
            return new GetMappingCommand(indexes, types);
        }


        /// <summary>
        /// Builds a command that allows to flush one or more indices through an API. 
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-flush.html
        /// </summary>
        public static FlushCommand Flush(string index = null, string type = null)
        {
            return new FlushCommand(index, type);
        }

        /// <summary>
        /// Builds a command that allows to flush one or more indices through an API. 
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-flush.html
        /// </summary>
        public static FlushCommand Flush(string[] indexes, string[] types)
        {
            return new FlushCommand(indexes, types);
        }


        /// <summary>
        /// Builds a command that allows check if the index (indices) exists or not. 
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-indices-exists.html
        /// </summary>
        public static IndexExistsCommand IndexExists(string index)
        {
            return new IndexExistsCommand(index);
        }

        /// <summary>
        /// Builds a command that allows to close an index. 
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-open-close.html
        /// </summary>
        public static CloseCommand Close(string index = null)
        {
            return new CloseCommand(index);
        }

        /// <summary>
        /// Builds a command that allows to open an index. 
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-open-close.html
        /// </summary>
        public static OpenCommand Open(string index = null)
        {
            return new OpenCommand(index);
        }

        /// <summary>
        /// Builds a command that allows to change specific index level settings in real time.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-update-settings.html
        /// </summary>
        public static UpdateSettingsCommand UpdateSettings(string index = null)
        {
            return new UpdateSettingsCommand(index);
        }
    
    }
}