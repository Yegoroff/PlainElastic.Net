using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_geo_distance_facets_result_deserialized
    {
        #region Geo Distance Facets Json Result
        private static readonly string geoDistanceFacetsJsonResult =
@"{
    'took': 60,
    'timed_out': false,
    '_shards': {
        'total': 5,
        'successful': 5,
        'failed': 0
    },
    'hits': {
        'total': 2,
        'max_score': 1.0,
        'hits': [ ]
    },
    'facets': {
        'geo1': {
            '_type': 'geo_distance',
            'ranges': [
                {
                    'to': 10.0,
                    'count': 0,
                    'min': 'Infinity',
                    'max': '-Infinity',
                    'total_count': 0,
                    'total': 0.0,
                    'mean': 0.0
                },
                {    
                    'from': 100.0,
                    'to': 1000.0,
                    'count': 2,
                    'min': 114.95,
                    'max': 1314.35,
                    'total_count': 2,
                    'total': 1429.3,
                    'mean': 714.65
                }
            ]
        }
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToSearchResult<object>(geoDistanceFacetsJsonResult);
            

        It should_contain_correct_hits_count = () =>
            result.hits.total.ShouldEqual(2);

        It should_contain_geo1_facet_with_filter_type = () =>
            result.facets["geo1"]._type.ShouldEqual("geo_distance");

        It should_deserialize_geo1_facet_to_GeoDistanceFacetResult_type = () =>
            result.facets["geo1"].ShouldBeOfType<GeoDistanceFacetResult>();

        It should_contain_facet_with_correct_from_value = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].from.ShouldEqual(100);

        It should_contain_facet_with_correct_to_value = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].to.ShouldEqual(1000);

        It should_contain_facet_with_correct_count = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].count.ShouldEqual(2);

        It should_contain_facet_with_correct_min = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].min.ShouldEqual(114.95);

        It should_contain_quantity_facet_with_correct_max = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].max.ShouldEqual(1314.35);

        It should_contain_facet_with_correct_total_count = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].total_count.ShouldEqual(2);

        It should_contain_facet_with_correct_total = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].total.ShouldEqual(1429.3);

        It should_contain_facet_with_correct_mean = () =>
            result.facets["geo1"].As<GeoDistanceFacetResult>().ranges[1].mean.ShouldEqual(714.65);


        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }

}