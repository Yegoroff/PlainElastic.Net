using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermsStatsFacet<>))]
    class When_complete_TermsStatsFacet_built
    {
        Because of = () => result = new TermsStatsFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .KeyField(f => f.StringProperty)
                                                .ValueField(f => f.IntProperty)
                                                .Order(TermsStatsFacetOrder.term)
                                                .AllTerms(true)
                                                .Script("Script'value'")
                                                .ScriptField("Script.Field")
                                                .ValueScript("Value 'Script'")
                                                .Lang(ScriptLangs.python)
                                                .Params("test_params")
                                                .Custom("'custom': {0}".AltQuote(), "123")

                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_terms_stats_facet_type = () => result.ShouldContain("'terms_stats':".AltQuote());

        It should_contain_key_field_part = () => result.ShouldContain("'key_field': 'StringProperty'".AltQuote());

        It should_contain_value_field_part = () => result.ShouldContain("'value_field': 'IntProperty'".AltQuote());

        It should_contain_order_part = () => result.ShouldContain("'order': 'term'".AltQuote());

        It should_contain_all_terms_part = () => result.ShouldContain("'all_terms': true".AltQuote());

        It should_contain_script_part = () => result.ShouldContain("'script': 'Script`value`'".AltQuote());

        It should_contain_script_field_part = () => result.ShouldContain("'script_field': 'Script.Field'".AltQuote());

        It should_contain_value_script_part = () => result.ShouldContain("'value_script': 'Value `Script`'".AltQuote());

        It should_contain_lang_part = () => result.ShouldContain("'lang': 'python'".AltQuote());

        It should_contain_params_part = () => result.ShouldContain("'params': test_params".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("'custom': 123".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'terms_stats': { " +
                    "'key_field': 'StringProperty'," +
                    "'value_field': 'IntProperty'," +
                    "'order': 'term'," +
                    "'all_terms': true," +
                    "'script': 'Script`value`'," +
                    "'script_field': 'Script.Field'," +
                    "'value_script': 'Value `Script`'," +
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
