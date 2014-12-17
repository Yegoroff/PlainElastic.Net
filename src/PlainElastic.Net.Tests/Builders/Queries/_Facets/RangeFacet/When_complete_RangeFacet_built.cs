using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeFacet<>))]
    class When_complete_RangeFacet_built
    {
        Because of = () => result = new RangeFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .KeyField(f=> f.IntProperty)
                                                .ValueField(f => f.EnumProperty)
                                                .KeyScript("Key 'Script'")
                                                .ValueScript("Value 'Script'")
                                                .Ranges(r => r
                                                    .FromTo(from: 1, to: 5)
                                                    .FromTo(from: 10)
                                                    .FromTo(to: 50)
                                                 )
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

        It should_contain_from_to_parts = () => result.ShouldContain("{ 'from': 1, 'to': 5 }".AltQuote());
        
        It should_contain_from_only_parts = () => result.ShouldContain("{ 'from': 10 }".AltQuote());

        It should_contain_to_only_parts = () => result.ShouldContain("{ 'to': 50 }".AltQuote());


        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'range': { " +
                    "'field': 'StringProperty'," +
                    "'key_field': 'IntProperty'," +
                    "'value_field': 'EnumProperty'," +
                    "'key_script': 'Key `Script`'," +
                    "'value_script': 'Value `Script`'," +
                    "'ranges': [ " +
                        "{ 'from': 1, 'to': 5 }," +
                        "{ 'from': 10 }," +
                        "{ 'to': 50 }" +
                    " ]" +
                " }," + 
                "'scope': 'scope'," +
                "'global': true," +
                "'nested': 'nested path'," +
                "'facet_filter': { facet filter }"+
            " }").AltQuote());

        private static string result;
    }
}
