using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFacet<>))]
    class When_complete_GeoDistanceFacet_built
    {
        Because of = () => result = new GeoDistanceFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .GeoPoint(lat:10, lon:20)
                                                .Geohash("ghash")
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


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_geo_point_part = () => result.ShouldContain("'StringProperty': { 'lat': 10,'lon': 20 }".AltQuote());

        It should_contain_geohash_part = () => result.ShouldContain("'StringProperty': 'ghash'".AltQuote());

        It should_contain_value_field_part = () => result.ShouldContain("'value_field': 'IntProperty'".AltQuote());

        It should_contain_value_script_part = () => result.ShouldContain("'value_script': 'value script'".AltQuote());

        It should_contain_lang_part = () => result.ShouldContain("'lang': 'python'".AltQuote());

        It should_contain_params_part = () => result.ShouldContain("'params': script params".AltQuote());


        It should_contain_distance_type_part = () => result.ShouldContain("'distance_type': 'plane'".AltQuote());

        It should_contain_distance_unit_part = () => result.ShouldContain("'unit': 'cm'".AltQuote());


        It should_contain_from_to_parts = () => result.ShouldContain("{ 'from': 1, 'to': 5 }".AltQuote());
        
        It should_contain_from_only_parts = () => result.ShouldContain("{ 'from': 10 }".AltQuote());

        It should_contain_to_only_parts = () => result.ShouldContain("{ 'to': 50 }".AltQuote());


        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'geo_distance': { " +
                        "'StringProperty': { 'lat': 10,'lon': 20 }," +
                        "'StringProperty': 'ghash'," +
                        "'value_field': 'IntProperty'," +
                        "'value_script': 'value script'," +
                        "'lang': 'python'," +
                        "'params': script params," +
                        "'distance_type': 'plane'," +
                        "'unit': 'cm'," +
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
