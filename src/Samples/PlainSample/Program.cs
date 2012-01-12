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

           
            IndexTweet(connection, serializer);

            GetTweet(serializer, connection);

            DeleteTweet(connection);


            Console.ReadKey();
        }


        private static void IndexTweet(ElasticConnection connection, JsonNetSerializer serializer)
        {
            var tweet = new Tweet
                            {
                                User = "testUser",
                                Message = "Test Message"
                            };

            string indexCommand = new IndexCommandBuilder(index: "tweeter", type: "tweet", id: "1").Pretty();
            string data = serializer.ToJson(tweet);

            var result = connection.Put(indexCommand, data);

            var indexResult = serializer.ToIndexResult(result);


            Console.WriteLine("Index RESULTS \r\n" +
                              result +
                              "\r\n");

            Console.WriteLine("ok: " + indexResult.ok);
            Console.WriteLine("_index: " + indexResult._index);
            Console.WriteLine("_type: " + indexResult._type);
            Console.WriteLine("_id: " + indexResult._id);
            Console.WriteLine("_version: " + indexResult._version);
            Console.WriteLine();
        }

        private static void GetTweet(JsonNetSerializer serializer, ElasticConnection connection)
        {
            String getCommand = new GetCommandBuilder(index: "tweeter", type: "tweet", id: "1").Pretty();

            OperationResult result = connection.Get(getCommand);

            var getTweet = serializer.ToGetResult<Tweet>(result);


            Console.WriteLine("Get RESULT: \r\n" +
                              result +
                              "\r\n");

            Console.WriteLine("User: " + getTweet.User);
            Console.WriteLine("Message: " + getTweet.Message);
            Console.WriteLine();
        }

        private static void DeleteTweet(ElasticConnection connection)
        {
            OperationResult result = connection.Delete("tweeter");

            Console.WriteLine("Delete RESULT: \r\n" + result);
        }
    
    }


    public class Tweet
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
