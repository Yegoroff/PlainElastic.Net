using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFacet<>))]
    class When_minimum_GeoDistanceRangeFacet_built
    {
        Because of = () => result = new GeoDistanceFacet<FieldsTestClass>()
            .FacetName("TestFacet")
            .Field(f => f.StringProperty)
            .Geohash("ghash")
            .Ranges(r => r.FromTo(from: 1))
            .ToString();


        It should_return_minimal_facet_string = () => result.ShouldEqual(
            "'TestFacet': { 'geo_distance': { 'StringProperty': 'ghash','ranges': [ { 'from': 1 } ] } }".AltQuote()
            );

        private static string result;
    }
}