using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFacet<>))]
    class When_empty_GeoDistanceFacet_built
    {
        Because of = () => result = new GeoDistanceFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .GeoPoint(null, null)
                                                .Geohash(null)
                                                .ValueField(f => f.IntProperty)
                                                .ValueScript("value script")
                                                .Lang(ScriptLangs.python)
                                                .Params("script params")
                                                .DistanceType(DistanceType.plane)
                                                .Unit(DistanceUnit.cm)
                                                .Ranges(r => r
                                                    .FromTo(from: 1, to: 5)
                                                    .FromTo(from: 10)
                                                    .FromTo(to: 50)
                                                 )
                                                .ToString();


        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
