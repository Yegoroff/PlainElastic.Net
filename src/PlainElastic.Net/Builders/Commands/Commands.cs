using PlainElastic.Net.Builders.Commands;

namespace PlainElastic.Net
{
    /// <summary>
    /// Provides shortcuts to Elastic Search command builders.
    /// </summary>
    public class Commands
    {

        /// <summary>
        /// Builds a command that allows to perform many index/delete operations in a single API call.
        /// This can greatly increase the indexing speed. 
        /// http://www.elasticsearch.org/guide/reference/api/bulk.html
        /// </summary>
        public static BulkCommand Bulk(string index, string type = null)
        {
            return new BulkCommand(index, type);
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
        /// Builds a command that allows to easily execute a query and get the number of matches for that query. 
        /// It can be executed across one or more indices and across one or more types. 
        /// The query can either be provided using a simple query string as a parameter, 
        /// or using the Query DSL defined within the request body
        /// http://www.elasticsearch.org/guide/reference/api/count.html
        /// </summary>
        public static CountCommand Count(string index = null, string type = null)
        {
            return new CountCommand(index, type);
        }

        /// <summary>
        /// Builds a command that allows to easily execute a query and get the number of matches for that query. 
        /// It can be executed across one or more indices and across one or more types. 
        /// The query can either be provided using a simple query string as a parameter, 
        /// or using the Query DSL defined within the request body
        /// http://www.elasticsearch.org/guide/reference/api/count.html
        /// </summary>
        public static CountCommand Count(string[] indexes, string[] types)
        {
            return new CountCommand(indexes, types);
        }

        /// <summary>
        /// Builds a command that allows  to instantiate an index. 
        /// ElasticSearch provides support for multiple indices, 
        /// including executing operations across several indices.
        /// Each index created can have specific settings associated with it.
        /// see http://www.elasticsearch.org/guide/reference/api/admin-indices-create-index.html
        /// </summary>
        public static CreateIndexCommand CreateIndex(string index)
        {
            return new CreateIndexCommand(index);
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
        /// Builds a command that allows to delete documents from one or more indices and one or more types based on a query.
        /// http://www.elasticsearch.org/guide/reference/api/delete-by-query/
        /// </summary>
        public static DeleteByQueryCommand DeleteByQuery(string index = null, string type = null)
        {
            return new DeleteByQueryCommand(index, type);
        }

        /// <summary>
        /// Builds a command that allows to delete documents from one or more indices and one or more types based on a query.
        /// http://www.elasticsearch.org/guide/reference/api/delete-by-query/
        /// </summary>
        public static DeleteByQueryCommand DeleteByQuery(string[] indexes, string[] types)
        {
            return new DeleteByQueryCommand(indexes, types);
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
        /// Builds a command that allows to get a typed JSON document from the index based on its id.
        /// http://www.elasticsearch.org/guide/reference/api/get.html
        /// </summary>
        public static GetCommand Get(string index = null, string type = null, string id = null)
        {
            return new GetCommand(index, type, id);
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
        /// Builds a command that allows to create Index and add or update custom Json document in that Index.
        /// http://www.elasticsearch.org/guide/reference/api/index_.html
        /// </summary>
        public static IndexCommand Index(string index, string type = null, string id = null)
        {
            return new IndexCommand(index, type, id);
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
        /// Builds a command that finds more like a specific item.
        /// http://www.elasticsearch.org/guide/reference/api/more-like-this.html
        /// </summary>
        public static MoreLikeThisCommand MoreLikeThis(string index, string type, string id)
        {
            return new MoreLikeThisCommand(index, type, id);
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
        /// Builds a command that allows to allows to optimize one or more indices through an API. 
        /// The optimize process basically optimizes the index for faster search operations 
        /// (and relates to the number of segments a lucene index within each shard).
        /// The optimize operation allows to optimize the number of segments to optimize to.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-optimize.html
        /// </summary>
        public static OptimizeCommand Optimize(string index = null, string type = null)
        {
            return new OptimizeCommand(index, type);
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
        ///  Allows to explicitly refresh one or more index, making all operations performed since the last refresh available for search.
        ///  The (near) real-time capabilities depends on the index engine used. 
        ///  For example, the robin one requires refresh to be called, but by default a refresh is scheduled periodically.
        ///  http://www.elasticsearch.org/guide/reference/api/admin-indices-refresh.html
        /// </summary>
        public static RefreshCommand Refresh(string index = null)
        {
            return new RefreshCommand(index);
        }

        /// <summary>
        ///  Allows to explicitly refresh one or more index, making all operations performed since the last refresh available for search.
        ///  The (near) real-time capabilities depends on the index engine used. 
        ///  For example, the robin one requires refresh to be called, but by default a refresh is scheduled periodically.
        ///  http://www.elasticsearch.org/guide/reference/api/admin-indices-refresh.html
        /// </summary>
        public static RefreshCommand Refresh(string[] indexes)
        {
            return new RefreshCommand(indexes);
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
        ///  Allows to scroll search request's hits.
        ///  http://www.elasticsearch.org/guide/reference/api/search/scroll
        /// </summary>
        public static SearchScrollCommand SearchScroll(string scrollId)
        {
            return new SearchScrollCommand(scrollId);
        }

        /// <summary>
        /// Builds a command that allows to get a comprehensive status information of one or more indices.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-status.html
        /// </summary>
        public static StatusCommand Status(string index = null)
        {
            return new StatusCommand(index);
        }

        /// <summary>
        /// Builds a command that allows to get a comprehensive status information of one or more indices.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-status.html
        /// </summary>
        public static StatusCommand Status(string[] indexes)
        {
            return new StatusCommand(indexes);
        }


        /// <summary>
        /// Builds a command that allows to change specific index level settings in real time.
        /// http://www.elasticsearch.org/guide/reference/api/admin-indices-update-settings.html
        /// </summary>
        public static UpdateSettingsCommand UpdateSettings(string index = null)
        {
            return new UpdateSettingsCommand(index);
        }

        /// <summary>
        /// Supports post 0.90.1 index alias api for single alias management
        /// http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/indices-aliases.html
        /// </summary>
        public static IndexAliasCommand IndexAlias(string index = null, string alias = null)
        {
            return new IndexAliasCommand(index, alias);
        }

        /// <summary>
        /// Supports post 0.90.1 index alias api for alias retrieval
        /// http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/indices-aliases.html
        /// </summary>
        public static IndexAliasesCommand IndexAliases(string index = null, string alias = null)
        {
            return new IndexAliasesCommand(index, alias);
        }
    }
}