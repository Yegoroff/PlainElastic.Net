using System;
using System.Collections.Generic;
using System.Linq;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Allows to generate JSON to perform many index/delete operations in a single API call.
    /// This can greatly increase the indexing speed.
    /// see http://www.elasticsearch.org/guide/reference/api/bulk.html
    /// </summary>
    public class BulkBuilder
    {
        private readonly IJsonSerializer serializer;


        public BulkBuilder(IJsonSerializer serializer)
        {
            this.serializer = serializer;
        }


        /// <summary>
        /// Builds a Bulk JSON that allows to add or update custom Json document in specified Index.
        /// If no index and type parameters specified, they will be taken from BulkCommand parameters.
        /// </summary>
        /// <param name="data">The document to add or update in ES index.</param>
        /// <param name="index">The ES index name, if not specified will be taken from BulkCommand endpoint address.</param>
        /// <param name="type">The ES type name, if not specified will be taken from BulkCommand endpoint address.</param>
        /// <param name="id">The document id, if not specified will be generated automatically by ES (This will add new document).</param>
        /// <param name="options">The bulk operation options.</param>
        /// <param name="customOptions">The custom JSON options for create operation.
        ///  Options should be comma separated string of values:
        /// <c>"_index": "test", "_type": "first", "_id": 1, "_version": 100</c>
        /// </param>
        public string Index(object data, string index = null, string type = null, string id = null,
                            BulkOperationOptions options = null, string customOptions = null)
        {
            string optionsJson = options == null ? "" : options.ToString();

            var parameters = BuildOperationParameters(index, type, id, optionsJson, customOptions);
            var command = "{{ 'index': {{ {0} }} }}\n".AltQuoteF(parameters);

            var dataJson = data as string ?? serializer.Serialize(data);
            return command + dataJson + "\n";
        }


        /// <summary>
        /// Builds a Bulk JSON that allows to add custom Json document in specified Index.
        /// If no index and type parameters specified, they will be taken from BulkCommand parameters.
        /// </summary>
        /// <param name="data">The document to add to ES index.</param>
        /// <param name="index">The ES index name, if not specified will be taken from BulkCommand endpoint address.</param>
        /// <param name="type">The ES type name, if not specified will be taken from BulkCommand endpoint address.</param>
        /// <param name="id">The document id, if not specified will be generated automatically by ES.</param>
        /// <param name="options">The bulk operation options.</param>
        /// <param name="customOptions">The custom JSON options for create operation.
        ///  Options should be comma separated string of values:
        /// <c>"_index": "test", "_type": "first", "_id": 1, "_version": 100</c>
        /// </param>
        public string Create(object data, string index = null, string type = null, string id = null, 
                             BulkOperationOptions options = null, string customOptions = null)
        {
            string optionsJson = options == null ? "" : options.ToString();

            var parameters = BuildOperationParameters(index, type, id, optionsJson, customOptions);

            var command = "{{ 'create': {{ {0} }} }}\n".AltQuoteF(parameters);
            var dataJson = data as string ?? serializer.Serialize(data);
            return command + dataJson + "\n";
        }

        /// <summary>
        /// Builds a Bulk JSON that allows to remove custom Json document from specified Index.
        /// If no index and type parameters specified, they will be taken from BulkCommand parameters.
        /// </summary>
        /// <param name="index">The ES index name, if not specified will be taken from BulkCommand endpoint address.</param>
        /// <param name="type">The ES type name, if not specified will be taken from BulkCommand endpoint address.</param>
        /// <param name="id">The Id of document to remove from ES index.</param>
        /// <param name="options">The bulk operation options.</param>
        /// <param name="customOptions">The custom JSON options for create operation.
        ///  Options should be comma separated string of values:
        /// <c>"_index": "test", "_type": "first", "_id": 1, "_version": 100</c>
        /// </param>
        public string Delete(string id, string index = null, string type = null,
                             BulkOperationOptions options = null, string customOptions = null)
        {
            string optionsJson = options == null ? "" : options.ToString();

            var parameters = BuildOperationParameters(index, type, id, optionsJson, customOptions);

            var command = "{{ 'delete': {{ {0} }} }}\n".AltQuoteF(parameters);
            return command;
        }



        /// <summary>
        /// Returns complete Bulk JSON with all generated bulk operations.
        /// </summary>
        public string BuildCollection<T>(IEnumerable<T> collection, Func<BulkBuilder, T, string> bulkOperation)
        {
            return collection.Select(element => bulkOperation(this, element)).Join();
        }

        /// <summary>
        /// Returns deferred Bulk JSONs IEnumerable with one bulk operation in each element,
        /// this will allow to process input elements on-the-fly - not generating all bulk JSON at once.
        /// </summary>
        public IEnumerable<string> PipelineCollection<T>(IEnumerable<T> collection, Func<BulkBuilder, T, string> bulkOperation)
        {
            return collection.Select(element => bulkOperation(this, element));
        }



        private static string BuildOperationParameters(string index, string type, string id, string optionsJson, string customOptions)
        {
            var parameters = new[] {
                                         index.IsNullOrEmpty()  ? "" : "\"_index\": " + index.Quotate(),
                                         type.IsNullOrEmpty()   ? "" : "\"_type\": " + type.Quotate(),
                                         id.IsNullOrEmpty()     ? "" : "\"_id\": " + id.Quotate(),
                                         optionsJson,
                                         customOptions
                                     };
            return parameters.Where(s => !s.IsNullOrEmpty()).JoinWithComma();
        }
    }
}
