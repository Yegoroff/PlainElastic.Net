using System;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_failed_query_results_deserialized
    {
        #region Failed Query Json Result
        private static readonly string failedQueryJsonResult =
@"{
    'took': 4,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 3,
        'failed': 2,
        'failures': [
            {
                'index': 'failure-index',
                'shard': 3,
                'status': 503,
                'reason': 'No active shards'
            },
            {
                'index': 'failure-index',
                'shard': 4,
                'status': 503,
                'reason': 'No active shards'
            }
        ]
    },
    'hits': {
        'total': 1,
        'max_score': 1,
        'hits': [
            {
                '_index': 'test-inmemory-093d8fe9-rule',
                '_type': 'rule',
                '_id': 'rule1',
                '_score': 1,
                '_source': {
                    '_id': 'rule1',
                    'Name': 'testme'
                }
            }
        ]
    }
}".AltQuote();
        #endregion

        Establish context = () => {
           jsonSerializer = new JsonNetSerializer();
        };


        Because of = () =>
            result = jsonSerializer.ToSearchResult<object>(failedQueryJsonResult);

        It should_contain_correct_successful_shards_count = () =>
            result._shards.successful.ShouldEqual(3);


        It should_contain_correct_failed_shards_count = () =>
            result._shards.failed.ShouldEqual(2);

        It should_contain_correct_shard_failures_count = () =>
            result._shards.failures.Length.ShouldEqual(2);

        It should_contain_correct_shard_failures_index = () =>
            result._shards.failures[0].index.ShouldEqual("failure-index");

        It should_contain_correct_shard_failures_shard = () =>
            result._shards.failures[0].shard.ShouldEqual(3);

        It should_contain_correct_shard_failures_status = () =>
            result._shards.failures[0].status.ShouldEqual(503);

        It should_contain_correct_shard_failures_reason = () =>
            result._shards.failures[0].reason.ShouldEqual("No active shards");

        It should_contain_correct_hits_count = () => 
            result.hits.total.ShouldEqual(1);

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }
}