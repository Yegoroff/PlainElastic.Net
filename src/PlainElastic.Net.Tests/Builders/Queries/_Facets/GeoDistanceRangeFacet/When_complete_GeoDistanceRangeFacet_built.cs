using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceRangeFacet<>))]
    class When_complete_GeoDistanceRangeFacet_built
    {
        Because of = () => result = new GeoDistanceRangeFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .DistanceType()
                                                .DistanceUnit()
                                                .Ranges(r => r
                                                    .FromTo(from: 1, to: 5)
                                                    .FromTo(from: 10)
                                                    .FromTo(to: 50)
                                                 )
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'StringProperty': { 'lat': 0, 'lon': 0 }".AltQuote());

        It should_contain_distance_type_part = () => result.ShouldContain("'distance_type': 'arc'".AltQuote());

        It should_contain_distance_unit_part = () => result.ShouldContain("'unit': 'km'".AltQuote());

        It should_contain_from_to_parts = () => result.ShouldContain("{ 'from': 1, 'to': 5 }".AltQuote());
        
        It should_contain_from_only_parts = () => result.ShouldContain("{ 'from': 10 }".AltQuote());

        It should_contain_to_only_parts = () => result.ShouldContain("{ 'to': 50 }".AltQuote());


        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'geo_distance': { " +
                        "'StringProperty': { 'lat': 0, 'lon': 0 }," +
                "'distance_type': 'arc'," +
                "'unit': 'km'," +
                "'ranges': [ " +
                    "{ 'from': 1, 'to': 5 }," +
                    "{ 'from': 10 }," +
                    "{ 'to': 50 }" +
                " ]" +
            " }" +
            " }").AltQuote());

        private static string result;
    }
}
