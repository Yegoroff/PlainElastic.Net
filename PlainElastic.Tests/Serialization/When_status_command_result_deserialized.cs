using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_status_command_result_deserialized
    {
        #region Status Command Json Result
        private static readonly string statusCommandJsonResult =
@"{
    '_shards': {
        'total': 5,
        'successful': 3,
        'failed': 2
    },
    'indices': {
        'twitter': {
            'index': {
                'primary_size': '430b',
                'primary_size_in_bytes': 5000000000,
                'size': '430b',
                'size_in_bytes': 5000000000
            },
            'translog': {
                'operations': 5
            },
            'docs': {
                'num_docs': 1,
                'max_doc': 2,
                'deleted_docs': 3
            },
            'merges': {
                'current': 1,
                'current_docs': 2,
                'current_size': '2b',
                'current_size_in_bytes': 3,
                'total': 5,
                'total_time': '2s',
                'total_time_in_millis': 3,
                'total_docs': 4,
                'total_size': '5b',
                'total_size_in_bytes': 6
            },
            'refresh': {
                'total': 20,
                'total_time': '0s',
                'total_time_in_millis': 0
            },
            'flush': {
                'total': 15,
                'total_time': '39ms',
                'total_time_in_millis': 39
            },
            'shards': {
                '0': [
                    {
                        'routing': {
                            'state': 'STARTED',
                            'primary': true,
                            'node': '2xDKC9yKQSuy6egd1bOXrw',
                            'relocating_node': null,
                            'shard': 0,
                            'index': 'twitter'
                        },
                        'state': 'STARTED',
                        'index': {
                            'size': '86b',
                            'size_in_bytes': 86
                        },
                        'translog': {
                            'id': 1343687338418,
                            'operations': 0
                        },
                        'docs': {
                            'num_docs': 0,
                            'max_doc': 0,
                            'deleted_docs': 0
                        },
                        'merges': {
                            'current': 0,
                            'current_docs': 0,
                            'current_size': '0b',
                            'current_size_in_bytes': 0,
                            'total': 0,
                            'total_time': '0s',
                            'total_time_in_millis': 0,
                            'total_docs': 0,
                            'total_size': '0b',
                            'total_size_in_bytes': 0
                        },
                        'refresh': {
                            'total': 4,
                            'total_time': '0s',
                            'total_time_in_millis': 0
                        },
                        'flush': {
                            'total': 3,
                            'total_time': '6ms',
                            'total_time_in_millis': 6
                        },
                        'gateway_recovery': {
                            'stage': 'DONE',
                            'start_time_in_millis': 1343687338416,
                            'time': '81ms',
                            'time_in_millis': 81,
                            'index': {
                                'progress': 10,
                                'size': '0b',
                                'size_in_bytes': 0,
                                'reused_size': '0b',
                                'reused_size_in_bytes': 0,
                                'expected_recovered_size': '0b',
                                'expected_recovered_size_in_bytes': 0,
                                'recovered_size': '0b',
                                'recovered_size_in_bytes': 0
                            },
                            'translog': {
                                'recovered': 0
                            }
                        }
                    }
                ]
            }
        }
    }
}".AltQuote();
        #endregion

        Establish context = () =>
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToStatusResult(statusCommandJsonResult.AltQuote());
            

        It should_contain_correct_shards_total = () =>
            result._shards.total.ShouldEqual(5);

        It should_contain_correct_shards_sucessfull= () =>
            result._shards.successful.ShouldEqual(3);

        It should_contain_correct_shards_filed = () =>
            result._shards.failed.ShouldEqual(2);

        It should_contain_twitter_index = () =>
            result.indices["twitter"].ShouldNotBeNull();

        It should_contain_correct_twitter_index_primary_size_in_bytes = () =>
            result.indices["twitter"].index.primary_size_in_bytes.ShouldEqual(5000000000);

        It should_contain_correct_twitter_index_size_in_bytes = () =>
            result.indices["twitter"].index.size_in_bytes.ShouldEqual(5000000000);

        It should_contain_correct_translog_operations = () =>
            result.indices["twitter"].translog.operations.ShouldEqual(5);

        It should_contain_correct_shards_routing_state = () =>
            result.indices["twitter"].shards[0][0].routing.state.ShouldEqual("STARTED");

        It should_contain_correct_shards_gateway_recovery_index_progress = () =>
            result.indices["twitter"].shards[0][0].gateway_recovery.index.progress.ShouldEqual(10);


        private static JsonNetSerializer jsonSerializer;
        private static StatusResult result;
    }

}