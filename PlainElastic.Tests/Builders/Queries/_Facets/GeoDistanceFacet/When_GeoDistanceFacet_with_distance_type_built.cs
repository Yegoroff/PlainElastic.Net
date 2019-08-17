using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFacet<>))]
    class When_GeoDistanceFacet_with_distance_type_built
    {
        Because of = () => result = new GeoDistanceFacet<FieldsTestClass>()
            .FacetName("TestFacet")
            .Field(f => f.StringProperty)
            .GeoPoint(lat: 10, lon: 20)
            .Ranges(r => r.FromTo(from: 1))
            .DistanceType()
            .ToString();


        It should_return_facet_string = () => result.ShouldEqual(
            ("'TestFacet': { " +
                "'geo_distance': { " +
                    "'StringProperty': { " +
                        "'lat': 10," +
                        "'lon': 20" +
                    " }," +
                    "'ranges': [ { 'from': 1 } ]," +
                    "'distance_type': 'sloppy_arc'" +
                " }" +
            " }").AltQuote()
            );

        private static string result;
    }
}