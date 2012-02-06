using System;
using System.Collections.Generic;
using PlainElastic.Net;
using PlainElastic.Net.QueryBuilder;
using PlainElastic.Net.Serialization;

namespace PlainSample
{
    class ClientSample
     {
        public void Execute()
        {
            Console.WriteLine("CLIENT SAMPLE");

            var client = new ElasticClient(defaultHost: "localhost", defaultPort: 9200);
            
            var firstTweet = new Tweet
            {
                User = "testUser",
                Message = "trying out Elastic Search"
            };

            var anotherTweet = new Tweet
            {
                User = "anotherUser",
                Message = "one more message"
            };


            IndexResult indexResult1 = client.Index(ElasticCommands.Index(index: "twitter", type: "tweet", id: "1").Refresh(true),
                         firstTweet);

            IndexResult indexResult2 = client.Index(ElasticCommands.Index(index: "twitter", type: "tweet", id: "2").Refresh(true),
                         anotherTweet);

            GetResult<Tweet> getResult = client.Get<Tweet>(ElasticCommands.Get(index: "twitter", type: "tweet", id: "2"));

            SearchResult<Tweet> searchResult = client.Search(ElasticCommands.Search("twitter", "tweet"),
                                                            new QueryBuilder<Tweet>()
                                                            .Query(q => q
                                                                .Term(t => t
                                                                    .Field(tweet => tweet.User)
                                                                    .Value("testUser")
                                                                    .Boost(2)
                                                                )
                                                            ));

            DeleteResult deleteResult = client.Delete(ElasticCommands.Delete(index: "twitter"));


            PrintIndexResult(indexResult1);

            PrintIndexResult(indexResult2);

            PrintGetResult(getResult);

            PrintSearchResults(searchResult);

            PrintDeleteResult(deleteResult);

            Console.ReadKey();
        }




        private static void PrintIndexResult(IndexResult indexResult)
        {
            Console.WriteLine("Index Results:");
            Console.WriteLine(" ok: " + indexResult.ok);
            Console.WriteLine(" _index: " + indexResult._index);
            Console.WriteLine(" _type: " + indexResult._type);
            Console.WriteLine(" _id: " + indexResult._id);
            Console.WriteLine(" _version: " + indexResult._version);
            Console.WriteLine();
        }

        private static void PrintGetResult(GetResult<Tweet> result)
        {
            Console.WriteLine("Get Result: ");

            Console.WriteLine(" _id: " + result._id);
            Console.WriteLine(" _index: " + result._index);
            Console.WriteLine(" _type: " + result._type);
            Console.WriteLine(" _version: " + result._version);
            Console.WriteLine(" _source: " + result._source);

            Console.WriteLine(" Tweet: ");
            Console.WriteLine("     User: " + result.Document.User);
            Console.WriteLine("     Message: " + result.Document.Message);
            Console.WriteLine();
        }

        private static void PrintSearchResults(SearchResult<Tweet> searchResult)
        {
            Console.WriteLine("Search Results:");
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
     
        private static void PrintDeleteResult(DeleteResult deleteResult)
        {
            Console.WriteLine("Delete Results:");
            Console.WriteLine(" ok: " + deleteResult.ok);
            Console.WriteLine(" _index: " + deleteResult._index);
            Console.WriteLine(" _type: " + deleteResult._type);
            Console.WriteLine(" _id: " + deleteResult._id);
            Console.WriteLine(" found: " + deleteResult.found);
            Console.WriteLine();
        }
    
    }
}
