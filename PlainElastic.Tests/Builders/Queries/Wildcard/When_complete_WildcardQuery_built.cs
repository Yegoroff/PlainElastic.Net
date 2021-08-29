using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(WildcardQuery<>))]
    class When_complete_WildcardQuery_built
    {
        Because of = () => result = new WildcardQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value("On*s")
                                                .Boost(5)
                                                .Rewrite(Rewrite.top_terms_n, 100)
                                                .ToString();

        It should_start_with_wildcard_declaration = () => result.ShouldStartWith("{ 'wildcard': {".AltQuote());

        It should_contain_field_name = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_value_part = () => result.ShouldContain("'value': 'On*s'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_rewrite_part = () => result.ShouldContain("'rewrite': 'top_terms_100'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                                        "'wildcard': { " +
                                                                            "'StringProperty': { " +
                                                                                "'value': 'On*s'," +
                                                                                "'boost': 5," +
                                                                                "'rewrite': 'top_terms_100' " +
                                                                            "} " +
                                                                        "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
