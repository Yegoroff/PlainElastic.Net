using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(LimitFilter<>))]
    class When_complete_LimitFilter_built
    {
        Because of = () => result = new LimitFilter<FieldsTestClass>()
                                                .Value(100)
                                                .ToString();


        It should_starts_with_limit_declaration = () => result.ShouldStartWith("{ 'limit': {".AltQuote());

        It should_contain_value_part = () => result.ShouldContain("'value': 100".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'limit': { " +
                                                                        "'value': 100 " +
                                                                      "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
