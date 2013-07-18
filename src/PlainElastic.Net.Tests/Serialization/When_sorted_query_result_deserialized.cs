using System;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_sorted_query_result_deserialized
    {
        #region Sorted Query Json Result
        private static readonly string sortedQueryJsonResult =
@"{
    'took': 24,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 2,
        'max_score': null,
        'hits': [
            {
                '_index': 'geotest',
                '_type': 'pin',
                '_id': '1',
                '_score': null,
                '_source': {
                    'pin': {
                        'name': 'A',
                        'num': 5,
                        'location': {
                            'lat': 40.12,
                            'lon': -71.34
                        }
                    }
                },
                'sort': [
                    5,
                    null,
                    114.81801790248922,
                    1290.173721609207
                ]
            },
            {
                '_index': 'geotest',
                '_type': 'pin',
                '_id': '2',
                '_score': null,
                '_source': {
                    'pin': {
                        'name': 'B',
                        'num': 6,
                        'location': {
                            'lat': 41.22,
                            'lon': -71.44
                        }
                    }
                },
                'sort': [
                    6,
                    'b',
                    168.29284571945516,
                    1193.8832686273954
                ]
            }
        ]
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            {
                jsonSerializer = new JsonNetSerializer();
            

            };


        Because of = () => result = jsonSerializer.ToSearchResult<object>(sortedQueryJsonResult);
            

        It should_contain_correct_hits_count = () => 
                                                    result.hits.total.ShouldEqual(2);

        It should_contain_4_sort_results_for_first_hit = () =>
                                                            result.hits.hits[0].sort.Length.ShouldEqual(4);

        It should_contain_correct_first_element_in_sort_result_for_first_hit = () =>
                                                            ((long)(result.hits.hits[0].sort[0])).ShouldEqual(5);

        It should_contain_correct_second_element_in_sort_result_for_first_hit = () =>
                                                            ((string)(result.hits.hits[0].sort[1])).ShouldEqual(null);

        It should_contain_correct_second_element_in_sort_result_for_second_hit = () =>
                                                            ((string)(result.hits.hits[1].sort[1])).ShouldEqual("b");

        It should_contain_correct_third_element_in_sort_result_for_first_hit = () =>
                                                            ((double)(result.hits.hits[0].sort[2])).ShouldEqual(114.81801790248922);

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }
}