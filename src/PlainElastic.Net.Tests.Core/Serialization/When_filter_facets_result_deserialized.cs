using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_filter_facets_result_deserialized
    {
        #region Filter Facets Json Result
        private static readonly string filterFacetsJsonResult =
@"{
    'took': 16,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 3000,
        'max_score': 1.0,
        'hits': [ ]
    },
    'facets': {
        'Segment': {
            '_type': 'filter',
            'count': 1000
        },
        'Family': {
            '_type': 'filter',
            'count': 2000
        }
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            jsonSerializer = new JsonNetSerializer();


        Because of = () => 
            result = jsonSerializer.ToSearchResult<object>(filterFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(3000);

        It should_contain_Segment_facet_with_filter_type = () =>
            result.facets["Segment"]._type.ShouldEqual("filter");

        It should_deserialize_Segment_facet_to_FilterFacetResults_type = () =>
            result.facets["Segment"].ShouldBeOfType<FilterFacetResult>();

        It should_contain_Segment_facet_with_correct_hit_count = () =>
            result.facets["Segment"].As<FilterFacetResult>().count.ShouldEqual(1000);

        It should_contain_Family_facet_with_filter_type = () =>
            result.facets["Family"]._type.ShouldEqual("filter");

        It should_deserialize_Family_facet_to_FilterFacetResults_type = () =>
            result.facets["Family"].ShouldBeOfType<FilterFacetResult>();

        It should_contain_Family_facet_with_correct_hit_count = () =>
            result.facets["Family"].As<FilterFacetResult>().count.ShouldEqual(2000);  


        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }

}