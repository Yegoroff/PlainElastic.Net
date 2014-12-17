using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MissingFilter<>))]
    class When_filled_MissingFilter_built
    {
        Because of = () => result = new MissingFilter<FieldsTestClass>()                                                
                                                .Field(f => f.StringProperty)
                                                .ToString();

        It should_starts_with_missing_declaration = () => result.ShouldStartWith("{ 'missing': {".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual("{ 'missing': { 'field': 'StringProperty' } }".AltQuote());

        private static string result;
    }
}
