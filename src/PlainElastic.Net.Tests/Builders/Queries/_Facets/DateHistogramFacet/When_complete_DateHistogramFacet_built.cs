using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(DateHistogramFacet<>))]
    class When_complete_DateHistogramFacet_built
    {
        Because of = () => result = new DateHistogramFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .KeyField(f=> f.IntProperty)
                                                .ValueField(f => f.EnumProperty)
                                                .KeyScript("Key 'Script'")
                                                .ValueScript("Value 'Script'")
                                                .Lang(ScriptLangs.python)
                                                .Params("script parameters")                                             
                                                .Interval("120min")
                                                .PreZoneAdjustLargeInterval(true)
                                                .PreZone("pre-zone")
                                                .PostZone("post-zone")
                                                .PreOffset("pre-offset")
                                                .PostOffset("post-offset")
                                                .Factor(10.5)
                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_key_field_part = () => result.ShouldContain("'key_field': 'IntProperty'".AltQuote());
        
        It should_contain_value_field_part = () => result.ShouldContain("'value_field': 'EnumProperty'".AltQuote());

        It should_contain_key_script_part = () => result.ShouldContain("'key_script': 'Key `Script`'".AltQuote());

        It should_contain_value_script_part = () => result.ShouldContain("'value_script': 'Value `Script`'".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_contain_interval_parts = () => result.ShouldContain("'interval': '120min'".AltQuote());

        It should_contain_pre_zone_adjust_large_interval_parts = () => result.ShouldContain("'pre_zone_adjust_large_interval': true".AltQuote());

        It should_contain_pre_zone_parts = () => result.ShouldContain("'pre_zone': 'pre-zone'".AltQuote());

        It should_contain_post_zone_parts = () => result.ShouldContain("'post_zone': 'post-zone'".AltQuote());

        It should_contain_pre_offset_parts = () => result.ShouldContain("'pre_offset': 'pre-offset'".AltQuote());

        It should_contain_post_offset_parts = () => result.ShouldContain("'post_offset': 'post-offset'".AltQuote());

        It should_contain_factor_parts = () => result.ShouldContain("'factor': 10.5".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'date_histogram': { " +
                    "'field': 'StringProperty'," +
                    "'key_field': 'IntProperty'," +
                    "'value_field': 'EnumProperty'," +
                    "'key_script': 'Key `Script`'," +
                    "'value_script': 'Value `Script`'," +
                    "'lang': 'python'," +
                    "'params': script parameters," +                    
                    "'interval': '120min'," +
                    "'pre_zone_adjust_large_interval': true," +
                    "'pre_zone': 'pre-zone'," +
                    "'post_zone': 'post-zone'," +
                    "'pre_offset': 'pre-offset'," +
                    "'post_offset': 'post-offset'," +
                    "'factor': 10.5" +
                " }," + 
                "'scope': 'scope'," +
                "'global': true," +
                "'nested': 'nested path'," +
                "'facet_filter': { facet filter }"+
            " }").AltQuote());

        private static string result;
    }
}
