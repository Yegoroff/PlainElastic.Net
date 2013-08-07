using System;
using System.Collections.Generic;
using PlainElastic.Net;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainSample
{
    public class PlainSample
     {
        public void Execute()
        {
            Console.WriteLine("PLAIN SAMPLE");

            var connection = new ElasticConnection("localhost", 9200);
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


            var tweets = new List<Tweet> {
                                    new Tweet
                                    {
                                        User = "firstUser",
                                        Message = "first bulk tweet"
                                    },
                                    new Tweet
                                    {
                                        User = "secondUser",
                                        Message = "second bulk tweet"
                                    },
                                    new Tweet
                                    {
                                        User = "thirdUser",
                                        Message = "third bulk tweet"
                                    },                                 
                             };


            IndexTweet(tweet, "1", connection, serializer);

            IndexTweet(anotherTweet, "2", connection, serializer);

            BulkTweetIndex(tweets, connection, serializer);

            GetTweet("1", serializer, connection);

            SearchTweets(connection, serializer);

            CountTweets(connection, serializer);

            DeleteTweeterIndex(connection, serializer);

            Console.WriteLine("Press any key");
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

            // This is url that will be requested from ES. We can grab it and put to any ES admin console (like ElasticHead) to debug ES behavior.
            string indexCommand =  Commands.Index(index: "twitter", type: "tweet", id: id)
                .Refresh(true)
                .Pretty(); // this will generate: twitter/tweet/1?pretty=true

            // This variable contains JSON of serialized tweet, thus we can check if our object serialized correctly 
            // or use it directly in ES admin console.
            string tweetJson = serializer.ToJson(tweet);

            var result = connection.Put(indexCommand, tweetJson);

            // Parse index result.
            IndexResult indexResult = serializer.ToIndexResult(result);


            PrintIndexCommand(result, indexResult, indexCommand, tweetJson);
        }

        private static void PrintIndexCommand(OperationResult result, IndexResult indexResult, string indexCommand, string data)
        {
            Console.WriteLine("Executed: \r\nPUT {0} \r\n{1} \r\n".F(indexCommand, data));

            Console.WriteLine("Index Results \r\n{0} \r\n".F(result));

            Console.WriteLine("Parsed Index Results");
            Console.WriteLine(" ok: " + indexResult.ok);
            Console.WriteLine(" _index: " + indexResult._index);
            Console.WriteLine(" _type: " + indexResult._type);
            Console.WriteLine(" _id: " + indexResult._id);
            Console.WriteLine(" _version: " + indexResult._version);
            Console.WriteLine();
        }



        private static void BulkTweetIndex(IEnumerable<Tweet> tweets, ElasticConnection connection, JsonNetSerializer serializer)
        {
            string bulkCommand = new BulkCommand(index: "twitter", type: "tweet").Refresh();

            int id = 10; // start adding tweets from id = 10 
            string bulkJson = new BulkBuilder(serializer)
                                    .BuildCollection(tweets, 
                                    (builder, tweet) => builder.Index(data: tweet, id: (id++).AsString())
                                    );
            
            string result = connection.Post(bulkCommand, bulkJson);

            //Parse bulk result;
            BulkResult bulkResult = serializer.ToBulkResult(result);

            PrintBulkCommand(bulkCommand, bulkJson, bulkResult);
        }

        private static void PrintBulkCommand(string bulkCommand, string bulkJson, BulkResult bulkResult)
        {
            Console.WriteLine("Executed: \r\nPOST {0} \r\n{1} \r\n".F(bulkCommand, bulkJson));

            Console.WriteLine("Parsed Bulk Results");

            foreach (var item in bulkResult.items)
            {
                Console.WriteLine(" operation: " + item.ResultType);
                Console.WriteLine("     _index: " + item.Result._index);
                Console.WriteLine("     _type: " + item.Result._type);
                Console.WriteLine("     _id: " + item.Result._id);
                Console.WriteLine();
            }
        }


        private static Tweet GetTweet(string id, JsonNetSerializer serializer, ElasticConnection connection)
        {
            /*            
            $ curl -XGET 'http://localhost:9200/twitter/tweet/1?pretty=true'
            */

            String getCommand = Commands.Get(index: "twitter", type: "tweet", id: id).Pretty(); // this will generate: twitter/tweet/1?pretty=true

            var result = connection.Get(getCommand); 

            // Deserialize Get command result to GetResult object.
            var getResult = serializer.ToGetResult<Tweet>(result);

            var getTweet = getResult.Document;

            PrintGetCommand(getTweet, result, getCommand);

            return getTweet;
        }

        private static void PrintGetCommand(Tweet getTweet, OperationResult result, string getCommand)
        {
            Console.WriteLine("Executed: \r\nGET {0} \r\n".F(getCommand));

            Console.WriteLine("Get Result: \r\n {0} \r\n".F(result.Result.BeautifyJson()));

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

            string deleteCommand = Commands.Delete(index: "twitter").Pretty();

            var result = connection.Delete(deleteCommand);

            DeleteResult deleteResult = serializer.ToDeleteResult(result);



            PrintDeleteCommand(deleteCommand, deleteResult, result);
        }

        private static void PrintDeleteCommand(string deleteCommand, DeleteResult deleteResult, OperationResult result)
        {
            Console.WriteLine("Executed: \r\nDELETE {0} \r\n".F(deleteCommand));

            Console.WriteLine("Delete RESULT: \r\n{0} \r\n".F(result));

            Console.WriteLine("Parsed Delete Results");
            Console.WriteLine(" ok: " + deleteResult.ok);
            Console.WriteLine(" acknowledged: " + deleteResult.acknowledged);
            Console.WriteLine(" _index: " + deleteResult._index);
            Console.WriteLine(" _type: " + deleteResult._type);
            Console.WriteLine(" _id: " + deleteResult._id);
            Console.WriteLine(" found: " + deleteResult.found);
            Console.WriteLine();
        }


        private static IEnumerable<Tweet> SearchTweets(ElasticConnection connection, JsonNetSerializer serializer)
        {
            string searchCommand = Commands.Search("twitter", "tweet").Pretty();

            /*
{
    "query": {
        "term": {
            "User": {
                "value": "testuser",
                "boost": "5"
            }
        }
    }
}
             */


            string query = new QueryBuilder<Tweet>()
                .Query(qry => qry
                    .Term(term => term
                        .Field(tweet => tweet.User)
                        .Value("testUser".ToLower()) // by default terms query requires lowercased values.
                        .Boost(5)
                     )
                    // Alternate way 
                    //.Custom(" 'term': {{  '{0}': {{ 'value': '{1}', 'boost': '5' }} }}".AltQuote(), "User", "testuser")
                ).BuildBeautified();

            var results = connection.Post(searchCommand, query);

            var searchResult = serializer.ToSearchResult<Tweet>(results);


            PrintSearchResults(searchResult, searchCommand, query, results);

            return searchResult.Documents;
        }

        private static void PrintSearchResults(SearchResult<Tweet> searchResult, string searchCommand, string query, OperationResult results)
        {
            Console.WriteLine("Executed: \r\nPOST {0} \r\n{1} \r\n".F(searchCommand, query));

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

        private static long CountTweets(ElasticConnection connection, JsonNetSerializer serializer)
        {
            string searchCommand = Commands.Count("twitter", "tweet").Pretty();

            string query = new CountBuilder<Tweet>().Query(qry => qry
                                                        .Filtered(filtq => filtq
                                                            //.Query(q=>q.MatchAll())
                                                            .Filter(f => f
                                                                .Query(q => q
                                                                    .Cache(true)
                                                                    .Term(t => t
                                                                        .Field(x => x.User)
                                                                        .Value("testuser")))

                                                            )
                                                        )                                                        
                                                        
            ).BuildBeautified();

            var results = connection.Post(searchCommand, query);

            var searchResult = serializer.ToCountResult(results);

            PrintCountResults(searchResult, searchCommand, query, results);

            return searchResult.count;
        }

        private static void PrintCountResults(CountResult countResult, string countCommand, string query, OperationResult results)
        {
            Console.WriteLine("Executed: \r\nPOST {0} \r\n{1} \r\n".F(countCommand, query));

            Console.WriteLine("Count Result: \r\n {0} \r\n".F(results));

            Console.WriteLine("Parsed Count Results");
            Console.WriteLine(" count: " + countResult.count);
            Console.WriteLine(" status: " + countResult.status);
            Console.WriteLine(" error: " + countResult.error);
            Console.WriteLine(" _shards:");
            Console.WriteLine("     total: " + countResult._shards.total);
            Console.WriteLine("     successful: " + countResult._shards.successful);
            Console.WriteLine("     failed: " + countResult._shards.failed);

            Console.WriteLine();
        }
     }
}
