using System;
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

            IndexTweet(tweet, connection, serializer);

            GetTweet(serializer, connection);

            DeleteTweeterIndex(connection, serializer);

            Console.ReadKey();
        }


        private static void IndexTweet(Tweet tweet, ElasticConnection connection, JsonNetSerializer serializer)
        {
           /*            
           $ curl -XPUT 'http://localhost:9200/twitter/tweet/1?pretty=true' -d '{
                    "User" : "testUser",
                    "Message" : "trying out Elastic Search"
                }'            
           */

            // This is url that will be requested from ES. We can grab it and put to any ES admin console (like Head) to debug ES behavior.
            string indexCommand = new IndexCommandBuilder(index: "twitter", type: "tweet", id: "1").Pretty();

            // This variable contains JSON of serialized tweet, thus we can check if our object serialized correctly 
            // or use it directly in ES admin console.
            string data = serializer.ToJson(tweet);

            var result = connection.Put(indexCommand, data);

            // Parse index result.
            IndexResult indexResult = serializer.ToIndexResult(result);



            Console.WriteLine("Executed: PUT \r\n" +
                  indexCommand + "\r\n" +
                  data +
                  "\r\n");

            Console.WriteLine("Index Results \r\n" +
                              result +
                              "\r\n");

            Console.WriteLine("Parsed Index Results");
            Console.WriteLine("ok: "     + indexResult.ok);
            Console.WriteLine("_index: " + indexResult._index);
            Console.WriteLine("_type: "  + indexResult._type);
            Console.WriteLine("_id: "    + indexResult._id);
            Console.WriteLine("_version: " + indexResult._version);
            Console.WriteLine();
        }


        private static Tweet GetTweet(JsonNetSerializer serializer, ElasticConnection connection)
        {
            /*            
            $ curl -XGET 'http://localhost:9200/twitter/tweet/1?pretty=true'
            */

            String getCommand = new GetCommandBuilder(index: "twitter", type: "tweet", id: "1").Pretty(); // this will generate: twitter/tweet/1?pretty=true

            var result = connection.Get(getCommand); 

            // Deserialize Get command result to Tweet object.
            var getTweet = serializer.ToGetResult<Tweet>(result);


            Console.WriteLine("Executed: GET \r\n" +
                              getCommand + 
                              "\r\n");

            Console.WriteLine("Get Result: \r\n" +
                              result +
                              "\r\n");
            Console.WriteLine("Parsed Get Result: ");
            Console.WriteLine("User: " + getTweet.User);
            Console.WriteLine("Message: " + getTweet.Message);
            Console.WriteLine();

            return getTweet;
        }

        private static void DeleteTweeterIndex(ElasticConnection connection, JsonNetSerializer serializer)
        {
           /*            
           $ curl -XDELETE 'http://localhost:9200/twitter?pretty=true'
           */

            string deleteCommand = ElasticCommands.Delete(index: "twitter").Pretty();

            var result = connection.Delete(deleteCommand);

            DeleteResult deleteResult = serializer.ToDeleteResult(result);



            Console.WriteLine("Delete RESULT: \r\n" + result);

            Console.WriteLine("Parsed Delete Results");
            Console.WriteLine("ok: " + deleteResult.ok);
            Console.WriteLine("_index: " + deleteResult._index);
            Console.WriteLine("_type: " + deleteResult._type);
            Console.WriteLine("_id: " + deleteResult._id);
            Console.WriteLine("found: " + deleteResult.found);
            Console.WriteLine();

        }
    
    }


    public class Tweet
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
