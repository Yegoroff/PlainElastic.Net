using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(PrefixQuery<>))]
    class When_complete_PrefixQuery_built
    {
        Because of = () => result = new PrefixQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Prefix("pre")
                                                .Boost(5)
                                                .Rewrite(Rewrite.top_terms_boost_n, 100)
                                                .Custom("custom part")
                                                .ToString();


        It should_starts_with_prefix_declaration = () => result.ShouldStartWith("{ 'prefix': {".AltQuote());

        It should_contain_field_name_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_prefix_part = () => result.ShouldContain("'prefix': 'pre'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_rewrite_part = () => result.ShouldContain("'rewrite': 'top_terms_boost_100'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom part".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                              "'prefix': { " +
                                                                  "'StringProperty': { " +
                                                                      "'prefix': 'pre'," +
                                                                      "'boost': 5," +
                                                                      "'rewrite': 'top_terms_boost_100'," +
                                                                      "custom part " +
                                                                  "} " +
                                                              "} " +
                                                          "}").AltQuote());

        private static string result;
    }
}
