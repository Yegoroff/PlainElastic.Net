using System;
using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;

namespace PlainSample
{
    class ClientSample
     {
        public void Execute()
        {
            Console.WriteLine("CLIENT SAMPLE");

            var client = new ElasticClient<Tweet>(defaultHost: "localhost", defaultPort: 9200);
            
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


            var indexSettings = new IndexSettingsBuilder()
                    .NumberOfShards(8)
                    .NumberOfReplicas(1)
                    .Analysis(analysis => analysis
                        .Analyzer(analyzer => analyzer
                            .Custom("keyword_lowercase", custom => custom
                            .Tokenizer(DefaultTokenizers.keyword)
                            .Filter(DefaultTokenFilters.lowercase))));

            client.CreateIndex(new IndexCommand(index: "twitter").Refresh(), indexSettings);


            IndexResult indexResult1 = client.Index(new IndexCommand(index: "twitter", type: "tweet", id: "1").Refresh(),
                         firstTweet);

            IndexResult indexResult2 = client.Index(Commands.Index(index: "twitter", type: "tweet", id: "2").Refresh(),
                         anotherTweet);

            GetResult<Tweet> getResult = client.Get(new GetCommand(index: "twitter", type: "tweet", id: "2"));

            SearchResult<Tweet> searchResult = client.Search(new SearchCommand("twitter", "tweet"),
                                                            new QueryBuilder<Tweet>()
                                                            .Query(q => q
                                                                .Term(t => t
                                                                    .Field(tweet => tweet.User)
                                                                    .Value("testUser")
                                                                    .Boost(2)
                                                                )
                                                            ));

            DeleteResult deleteResult = client.Delete(Commands.Delete(index: "twitter"));


            PrintIndexResult(indexResult1);

            PrintIndexResult(indexResult2);

            PrintGetResult(getResult);

            PrintSearchResults(searchResult);

            PrintDeleteResult(deleteResult);

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }




        private static void PrintIndexResult(IndexResult indexResult)
        {
            Console.WriteLine("Index Results:");
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
            Console.WriteLine(" acknowledged: " + deleteResult.acknowledged);
            Console.WriteLine(" _index: " + deleteResult._index);
            Console.WriteLine(" _type: " + deleteResult._type);
            Console.WriteLine(" _id: " + deleteResult._id);
            Console.WriteLine(" found: " + deleteResult.found);
            Console.WriteLine();
        }
    
    }
}
