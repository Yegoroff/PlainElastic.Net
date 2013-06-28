using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_highlighted_result_deserialized
    {
        #region Highlighted Json Result
        private static readonly string highlightedJsonResult =
            @"{
    'took': 4,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 1,
        'max_score': 1.0,
        'hits': [
            {
                '_index': 'companies',
                '_type': 'company',
                '_id': '1',
                '_score': 1.0,
                '_source': {
                    'Name': 'Highlight Test, Inc.',
                    'Description': 'Highlight Test, Inc. is a test for highlight results deserialization.',
                    'Version': 1
                },
                'highlight': {
                    'Name': [
                        '<em>Highlight</em> Test, Inc.'
                    ],
                    'Description': [
                        '<em>Highlight</em> Test, Inc. is a test for highlight results deserialization.'
                    ]
                }
            }
        ]
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            jsonSerializer = new JsonNetSerializer();


        Because of = () => 
            result = jsonSerializer.ToSearchResult<object>(highlightedJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(1);

         It should_contain_hit_with_highlighted_Name_field_with_highlighted_fragment = () =>
            result.hits.hits[0].highlight["Name"].Single().ShouldEqual("<em>Highlight</em> Test, Inc.");

         It should_contain_hit_with_highlighted_Description_field_with_highlighted_fragment = () =>
            result.hits.hits[0].highlight["Description"].Single().ShouldEqual("<em>Highlight</em> Test, Inc. is a test for highlight results deserialization.");

        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }
}