using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(CustomBoostFactorQuery<>))]
    class When_complete_CustomBoostFactorQuery_built
    {
        Because of = () => result = new CustomBoostFactorQuery<FieldsTestClass>()
                                                .Query(q => q.Custom("{ query }"))
                                                .BoostFactor(5.2)
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_starts_with_custom_boost_factor_declaration = () =>
            result.ShouldStartWith("{ 'custom_boost_factor':".AltQuote());

        It should_contain_query_part = () =>
            result.ShouldContain("'query': { query }".AltQuote());

        It should_contain_boost_factor_part = () =>
            result.ShouldContain("'boost_factor': 5.2".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'custom_boost_factor': { " +
                                        "'query': { query }," +
                                        "'boost_factor': 5.2," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
