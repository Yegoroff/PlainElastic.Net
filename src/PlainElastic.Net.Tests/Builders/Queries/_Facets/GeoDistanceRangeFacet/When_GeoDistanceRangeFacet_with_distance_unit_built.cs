using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceRangeFacet<>))]
    class When_GeoDistanceRangeFacet_with_distance_unit_built
    {
        Because of = () => result = new GeoDistanceRangeFacet<FieldsTestClass>()
            .FacetName("TestFacet")
            .Field(f => f.StringProperty)
            .Ranges(r => r.FromTo())
            .DistanceUnit()
            .ToString();


        It should_return_facet_string = () => result.ShouldEqual(
            "'TestFacet': { 'geo_distance': { 'StringProperty': { 'lat': 0, 'lon': 0 },'unit': 'km' } }".AltQuote()
            );

        private static string result;
    }
}