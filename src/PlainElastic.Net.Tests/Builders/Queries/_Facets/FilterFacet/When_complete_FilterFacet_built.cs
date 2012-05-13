using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FilterFacet<>))]
    class When_complete_FilterFacet_built
    {
        Because of = () => result = new FilterFacet<FieldsTestClass>()
                                        .FacetName("TestFacet")
                                        .Filter(f => f.
                                            Term(t => t
                                                .Custom("Term Filter")
                                            )
                                        )
                                        .Custom("'custom': {0}".AltQuote(), "123")

                                        .Scope("scope")
                                        .Global(true)
                                        .Nested("nested path")
                                        .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                        .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_filter_part = () => result.ShouldContain("'filter': { 'term': { Term Filter } }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("'custom': 123".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'filter': { " +
                    "'term': { Term Filter } " +
                "}," +
                "'custom': 123," +
                "'scope': 'scope'," +
                "'global': true," +
                "'nested': 'nested path'," +
                "'facet_filter': { facet filter }"+
            " }").AltQuote());

        private static string result;
    }
}
