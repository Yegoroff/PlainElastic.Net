using PlainElastic.Net;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainSample
{
	partial class ClientSample
	{
		public void ExecuteAsync()
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

			var res1 = client.BeginGet(new GetCommand(index: "twitter", type: "tweet", id: "2"), null, null);
			res1.AsyncWaitHandle.WaitOne();
			GetResult<Tweet> getResult = client.EndGet(res1);

			var res2 = client.BeginSearch(new SearchCommand("twitter", "tweet"),
															new QueryBuilder<Tweet>()
															.Query(q => q
																.Term(t => t
																	.Field(tweet => tweet.User)
																	.Value("testUser")
																	.Boost(2)
																)
															), null, null);
			res2.AsyncWaitHandle.WaitOne();
			SearchResult<Tweet> searchResult = client.EndSearch(res2);

			DeleteResult deleteResult = client.Delete(Commands.Delete(index: "twitter"));


			PrintIndexResult(indexResult1);

			PrintIndexResult(indexResult2);

			PrintGetResult(getResult);

			PrintSearchResults(searchResult);

			PrintDeleteResult(deleteResult);

			Console.WriteLine("Press any key");
			Console.ReadKey();


		}
	}
}
