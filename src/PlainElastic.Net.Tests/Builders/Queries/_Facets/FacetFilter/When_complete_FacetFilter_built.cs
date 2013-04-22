using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FacetFilter<>))]
    class When_complete_FacetFilter_built
    {
        Because of = () => result = new FacetFilter<FieldsTestClass>()
                                        .And(a => a.Custom("And"))
                                        .Exists(e => e.Custom("Exists"))
                                        .Nested(n => n.Custom("Nested"))
                                        .Range(r => r.Custom("Range"))
                                        .Term(t => t.Custom("Term"))
                                        .Terms(t => t.Custom("Terms"))
                                        .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'facet_filter'".AltQuote());

        It should_contain_and_filter_part = () => result.ShouldContain("'and': [".AltQuote());

        It should_contain_exists_filter_part = () => result.ShouldContain("'exists': { Exists }".AltQuote());

        It should_contain_nested_filter_part = () => result.ShouldContain("'nested': { Nested }".AltQuote());

        It should_contain_range_filter_part = () => result.ShouldContain("'range': { Range }".AltQuote());

        It should_contain_term_filter_part = () => result.ShouldContain("'term': { Term }".AltQuote());

        It should_contain_terms_filter_part = () => result.ShouldContain("'terms': { Terms }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual(("'facet_filter': " +
                                                                    "{ 'and': [ And ] }," +
                                                                    "{ 'exists': { Exists } }," +
                                                                    "{ 'nested': { Nested } }," +
                                                                    "{ 'range': { Range } }," +
                                                                    "{ 'term': { Term } }," +
                                                                    "{ 'terms': { Terms } }"
                                                                 ).AltQuote());

        private static string result;
    }
}
