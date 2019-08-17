using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(StatisticalFacet<>))]
    class When_complete_StatisticalFacet_built
    {
        Because of = () => result = new StatisticalFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .Script("Script'value'")
                                                .Lang(ScriptLangs.python)
                                                .Params("test_params")
                                                .Custom("'custom': {0}".AltQuote(), "123")

                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_script_part = () => result.ShouldContain("'script': 'Script`value`'".AltQuote());

        It should_contain_lang_part = () => result.ShouldContain("'lang': 'python'".AltQuote());

        It should_contain_params_part = () => result.ShouldContain("'params': test_params".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("'custom': 123".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'statistical': { " +
                    "'field': 'StringProperty'," +
                    "'script': 'Script`value`'," +
                    "'lang': 'python'," +
                    "'params': test_params," +
                    "'custom': 123" +
                " }," + 
                "'scope': 'scope'," +
                "'global': true," +
                "'nested': 'nested path'," +
                "'facet_filter': { facet filter }"+
            " }").AltQuote());

        private static string result;
    }
}
