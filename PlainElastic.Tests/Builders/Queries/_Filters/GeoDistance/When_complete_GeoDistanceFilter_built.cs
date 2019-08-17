using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFilter<>))]
    public class When_complete_GeoDistanceFilter_built
    {
        Because of = () => result = new GeoDistanceFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Distance("200km")
                                                .DistanceType(DistanceType.plane)
                                                .OptimizeBoundingBox(OptimizeBoundingBox.indexed)
                                                .GeoPoint(lat: 40, lon: -70)
                                                .Cache(true)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_starts_with_geo_distance_declaration = () => result.ShouldStartWith("{ 'geo_distance': {".AltQuote());

        It should_contain_distance_part = () => result.ShouldContain("'distance': '200km'".AltQuote());

        It should_contain_distance_type_part = () => result.ShouldContain("'distance_type': 'plane'".AltQuote());

        It should_contain_optimize_bounding_box_part = () => result.ShouldContain("'optimize_bbox': 'indexed'".AltQuote());

        It should_contain_field_name_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_lat_part = () => result.ShouldContain("'lat': 40".AltQuote());

        It should_contain_lon_part = () => result.ShouldContain("'lon': -70".AltQuote());

        It should_contain_cache_part = () =>
            result.ShouldContain("'_cache': true".AltQuote());

        It should_contain_cache_key_part = () =>
            result.ShouldContain("'_cache_key': 'CacheKey'".AltQuote());

        It should_contain_name_part = () =>
            result.ShouldContain("'_name': 'FilterName'".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                              "'geo_distance': { " +
                                                                  "'distance': '200km'," +
                                                                  "'distance_type': 'plane'," +
                                                                  "'optimize_bbox': 'indexed'," +
                                                                  "'StringProperty': { " +
                                                                      "'lat': 40," +
                                                                      "'lon': -70 " +
                                                                  "}," +
                                                                  "'_cache': true," +
                                                                  "'_cache_key': 'CacheKey'," +
                                                                  "'_name': 'FilterName'," +
                                                                  "{ custom part } " +
                                                              "} " +
                                                          "}").AltQuote());

        private static string result;
    }
}
