using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFilter<>))]
    public class When_complete_GeoDistanceFilter_built_with_geohash_specified
    {
        Because of = () => result = new GeoDistanceFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Distance(200, DistanceUnit.km)
                                                .Geohash("ubcu4xtthj86")
                                                .ToString();

        It should_starts_with_geo_distance_declaration = () => result.ShouldStartWith("{ 'geo_distance': {".AltQuote());

        It should_contain_distance_part = () => result.ShouldContain("'distance': '200km'".AltQuote());

        It should_contain_geohash_part = () => result.ShouldContain("'StringProperty': 'ubcu4xtthj86'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                              "'geo_distance': { " +
                                                                  "'distance': '200km'," +
                                                                  "'StringProperty': 'ubcu4xtthj86' " +
                                                              "} " +
                                                          "}").AltQuote());

        private static string result;
    }
}
