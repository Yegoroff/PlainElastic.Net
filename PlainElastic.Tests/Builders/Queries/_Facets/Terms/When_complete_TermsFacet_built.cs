using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermsFacet<>))]
    class When_complete_TermsFacet_built
    {
        Because of = () => result = new TermsFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .Order(TermsFacetOrder.term)
                                                .AllTerms(true)
                                                .Exclude("One", "Two")
                                                .Regex("Regex Expression")
                                                .RegexFlags(RegexFlags.CANON_EQ | RegexFlags.UNICODE_CASE)
                                                .Script("Script'value'")
                                                .ScriptField("Script.Field")
                                                .Custom("'custom': {0}".AltQuote(), "123")

                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_order_part = () => result.ShouldContain("'order': 'term'".AltQuote());

        It should_contain_all_terms_part = () => result.ShouldContain("'all_terms': true".AltQuote());

        It should_contain_exclude_part = () => result.ShouldContain("'exclude': [ 'One','Two' ]".AltQuote());

        It should_contain_regex_part = () => result.ShouldContain("'regex': 'Regex Expression'".AltQuote());

        It should_contain_regex_flags = () => result.ShouldContain("'regex_flags': 'CANON_EQ|UNICODE_CASE'".AltQuote());

        It should_contain_script_part = () => result.ShouldContain("'script': 'Script`value`'".AltQuote());

        It should_contain_script_field_part = () => result.ShouldContain("'script_field': 'Script.Field'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("'custom': 123".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'terms': { " +
                    "'field': 'StringProperty'," +
                    "'order': 'term'," +
                    "'all_terms': true," +
                    "'exclude': [ 'One','Two' ]," +
                    "'regex': 'Regex Expression'," +
                    "'regex_flags': 'CANON_EQ|UNICODE_CASE'," +
                    "'script': 'Script`value`'," +
                    "'script_field': 'Script.Field'," +
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
