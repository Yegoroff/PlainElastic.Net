using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFacet<>))]
    class When_GeoDistanceRangeFacet_with_distance_unit_built
    {
        Because of = () => result = new GeoDistanceFacet<FieldsTestClass>()
            .FacetName("TestFacet")
            .Field(f => f.StringProperty)
            .GeoPoint(lat:10, lon:20)
            .Ranges(r => r.FromTo(from: 1))
            .Unit()
            .ToString();


        It should_return_facet_string = () => result.ShouldEqual(
            ("'TestFacet': { " +
                "'geo_distance': { " +
                    "'StringProperty': { " +
                        "'lat': 10," +
                        "'lon': 20" +
                    " }," +
                "'ranges': [ { 'from': 1 } ]," +
                "'unit': 'km'" +
                " }" +
             " }").AltQuote()
            );

        private static string result;
    }
}