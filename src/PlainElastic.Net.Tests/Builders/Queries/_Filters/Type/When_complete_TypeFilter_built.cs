using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TypeFilter<>))]
    class When_complete_TypeFilter_built
    {
        Because of = () => result = new TypeFilter<FieldsTestClass>()
                                                .Value("myType")
                                                .ToString();


        It should_starts_with_type_declaration = () => result.ShouldStartWith("{ 'type': {".AltQuote());

        It should_contain_value_part = () => result.ShouldContain("'value': 'myType'".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'type': { " +
                                                                        "'value': 'myType' " +
                                                                      "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
