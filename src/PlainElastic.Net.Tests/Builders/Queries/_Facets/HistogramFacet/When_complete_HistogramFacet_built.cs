using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HistogramFacet<>))]
    class When_complete_HistogramFacet_built
    {
        Because of = () => result = new HistogramFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .KeyField(f=> f.IntProperty)
                                                .ValueField(f => f.EnumProperty)
                                                .KeyScript("Key Script")
                                                .ValueScript("Value Script")
                                                .Lang(ScriptLangs.python)
                                                .Params("script parameters")
                                                .Interval(120)
                                                .TimeInterval("5m")
                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_key_field_part = () => result.ShouldContain("'key_field': 'IntProperty'".AltQuote());
        
        It should_contain_value_field_part = () => result.ShouldContain("'value_field': 'EnumProperty'".AltQuote());

        It should_contain_key_script_part = () => result.ShouldContain("'key_script': 'Key Script'".AltQuote());
        
        It should_contain_value_script_part = () => result.ShouldContain("'value_script': 'Value Script'".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_contain_interval_parts = () => result.ShouldContain("'interval': 120".AltQuote());
        
        It should_contain_from_only_parts = () => result.ShouldContain("'time_interval': '5m' ".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'histogram': { " +
                    "'field': 'StringProperty'," +
                    "'key_field': 'IntProperty'," +
                    "'value_field': 'EnumProperty'," +
                    "'key_script': 'Key Script'," +
                    "'value_script': 'Value Script'," +
                    "'lang': 'python'," +
                    "'params': script parameters," +                    
                    "'interval': 120," +
                    "'time_interval': '5m'" +
                " }," + 
                "'scope': 'scope'," +
                "'global': true," +
                "'nested': 'nested path'," +
                "'facet_filter': { facet filter }"+
            " }").AltQuote());

        private static string result;
    }
}
