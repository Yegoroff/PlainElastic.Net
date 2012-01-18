using System;
using System.Collections.Generic;
using PlainElastic.Net;
using PlainElastic.Net.Serialization;

namespace PlainSample
{
    class Program
     {
        static void Main(string[] args)
        {
            var connection = new ElasticConnection {DefaultHost = "localhost", DefaultPort = 9200};
            var serializer = new JsonNetSerializer();

            var tweet = new Tweet
            {
                User = "testUser",
                Message = "trying out Elastic Search"
            };

            var anotherTweet = new Tweet
            {
                User = "anotherUser",
                Message = "one more message"
            };

            IndexTweet(tweet, "1", connection, serializer);

            IndexTweet(anotherTweet, "2", connection, serializer);

            GetTweet("1", serializer, connection);

            SearchTweets(connection, serializer);

            DeleteTweeterIndex(connection, serializer);

            Console.ReadKey();
        }


        private static void IndexTweet(Tweet tweet, string id, ElasticConnection connection, JsonNetSerializer serializer)
        {
           /*            
           $ curl -XPUT 'http://localhost:9200/twitter/tweet/1?pretty=true' -d '{
                    "User" : "testUser",
                    "Message" : "trying out Elastic Search"
                }'            
           */

            // This is url that will be requested from ES. We can grab it and put to any ES admin console (like Head) to debug ES behavior.
            string indexCommand = new IndexCommandBuilder(index: "twitter", type: "tweet", id: id)
               // .Consistency(WriteConsistency.all)
                .Refresh(true)
                .Pretty(); // this will generate: twitter/tweet/1?pretty=true

            // This variable contains JSON of serialized tweet, thus we can check if our object serialized correctly 
            // or use it directly in ES admin console.
            string data = serializer.ToJson(tweet);

            var result = connection.Put(indexCommand, data);

            // Parse index result.
            IndexResult indexResult = serializer.ToIndexResult(result);


            PrintIndexCommand(result, indexResult, indexCommand, data);
        }

        private static void PrintIndexCommand(OperationResult result, IndexResult indexResult, string indexCommand, string data)
        {
            Console.WriteLine("Executed: PUT \r\n{0} \r\n{1} \r\n".F(indexCommand, data ));

            Console.WriteLine("Index Results \r\n{0} \r\n".F(result));

            Console.WriteLine("Parsed Index Results");
            Console.WriteLine(" ok: " + indexResult.ok);
            Console.WriteLine(" _index: " + indexResult._index);
            Console.WriteLine(" _type: " + indexResult._type);
            Console.WriteLine(" _id: " + indexResult._id);
            Console.WriteLine(" _version: " + indexResult._version);
            Console.WriteLine();
        }


        private static Tweet GetTweet(string id, JsonNetSerializer serializer, ElasticConnection connection)
        {
            /*            
            $ curl -XGET 'http://localhost:9200/twitter/tweet/1?pretty=true'
            */

            String getCommand = new GetCommandBuilder(index: "twitter", type: "tweet", id: id).Pretty(); // this will generate: twitter/tweet/1?pretty=true

            var result = connection.Get(getCommand); 

            // Deserialize Get command result to GetResult object.
            var getResult = serializer.ToGetResult<Tweet>(result);

            var getTweet = getResult.Document;

            PrintGetCommand(getTweet, result, getCommand);

            return getTweet;
        }

        private static void PrintGetCommand(Tweet getTweet, OperationResult result, string getCommand)
        {
            Console.WriteLine("Executed: GET \r\n {0} \r\n".F(getCommand));

            Console.WriteLine("Get Result: \r\n {0} \r\n".F(result));

            Console.WriteLine("Parsed Get Result: ");
            Console.WriteLine(" User: " + getTweet.User);
            Console.WriteLine(" Message: " + getTweet.Message);
            Console.WriteLine();
        }


        private static void DeleteTweeterIndex(ElasticConnection connection, JsonNetSerializer serializer)
        {
           /*            
           $ curl -XDELETE 'http://localhost:9200/twitter?pretty=true'
           */

            string deleteCommand = ElasticCommands.Delete(index: "twitter").Pretty();

            var result = connection.Delete(deleteCommand);

            DeleteResult deleteResult = serializer.ToDeleteResult(result);



            PrintDeleteCommand(deleteCommand, deleteResult, result);
        }

        private static void PrintDeleteCommand(string deleteCommand, DeleteResult deleteResult, OperationResult result)
        {
            Console.WriteLine("Executed: DELETE \r\n {0} \r\n".F(deleteCommand));

            Console.WriteLine("Delete RESULT: \r\n{0} \r\n".F(result));

            Console.WriteLine("Parsed Delete Results");
            Console.WriteLine(" ok: " + deleteResult.ok);
            Console.WriteLine(" _index: " + deleteResult._index);
            Console.WriteLine(" _type: " + deleteResult._type);
            Console.WriteLine(" _id: " + deleteResult._id);
            Console.WriteLine(" found: " + deleteResult.found);
            Console.WriteLine();
        }


        private static IEnumerable<Tweet> SearchTweets(ElasticConnection connection, JsonNetSerializer serializer)
        {
            string searchCommand = ElasticCommands.Search("twitter", "tweet").Pretty();

            var results = connection.Post(searchCommand, "{}");

            var searchResult = serializer.ToSearchResult<Tweet>(results);


            PrintSearchResults(searchResult, searchCommand, results);

            return searchResult.Documents;
        }

        private static void PrintSearchResults(SearchResult<Tweet> searchResult, string searchCommand, OperationResult results)
        {
            Console.WriteLine("Executed: GET \r\n {0} \r\n".F(searchCommand));

            Console.WriteLine("Search Result: \r\n {0} \r\n".F(results));

            Console.WriteLine("Parsed Search Results");
            Console.WriteLine(" took: " + searchResult.took);
            Console.WriteLine(" timed_out: " + searchResult.timed_out);
            Console.WriteLine(" _shards:");
            Console.WriteLine("     total: " + searchResult._shards.total);
            Console.WriteLine("     successful: " + searchResult._shards.successful);
            Console.WriteLine("     failed: " + searchResult._shards.failed);

            Console.WriteLine(" hits: ");
            Console.WriteLine("     total: " + searchResult.hits.total);
            Console.WriteLine("     max_score: " + searchResult.hits.max_score);
            Console.WriteLine("     hits: ");
            foreach (var hit in searchResult.hits.hits)
            {
                Console.WriteLine("         _id: " + hit._id);
                Console.WriteLine("         _index: " + hit._index);
                Console.WriteLine("         _type: " + hit._type);
                Console.WriteLine("         _score: " + hit._score);
                Console.WriteLine("         _source:");

                Console.WriteLine("             User: " + hit._source.User);
                Console.WriteLine("             Message: " + hit._source.Message);
                Console.WriteLine();
            }

            Console.WriteLine();
        }
     }


    public class Tweet
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
