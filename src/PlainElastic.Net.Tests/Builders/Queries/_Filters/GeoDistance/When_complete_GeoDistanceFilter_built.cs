using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFilter<>))]
    class When_complete_GeoDistanceFilter_built
    {
        Because of = () => result = new GeoDistanceFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Distance("200km")
                                                .Point(lat: 40, lon: -70)
                                                .ToString();


        It should_starts_with_geo_distance_declaration = () => result.ShouldStartWith("{ 'geo_distance': {".AltQuote());

        It should_contain_distance_part = () => result.ShouldContain("'distance': '200km'".AltQuote());

        It should_contain_field_name_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_lat_part = () => result.ShouldContain("'lat': 40".AltQuote());

        It should_contain_lon_part = () => result.ShouldContain("'lon': -70".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                              "'geo_distance': { " +
                                                                  "'distance': '200km', " +
                                                                  "'StringProperty': { " +
                                                                      "'lat': 40, " +
                                                                      "'lon': -70 " +
                                                                  "} " +
                                                              "} " +
                                                          "}").AltQuote());

        private static string result;
    }
}
