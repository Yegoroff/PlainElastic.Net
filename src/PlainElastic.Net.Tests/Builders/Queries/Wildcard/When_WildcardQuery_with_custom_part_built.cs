using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(WildcardQuery<>))]
    class When_WildcardQuery_with_custom_part_built
    {
        Because of = () => result = new WildcardQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value("One")
                                                .Custom("\"boost's value\": {0}", "5")
                                                .ToString();

        It should_contain_custom_part = () => result.ShouldContain("\"boost's value\": 5");

        It should_return_correct_query = () => result.ShouldEqual("{ \"term\": { \"StringProperty\": { \"value\": \"One\",\"boost's value\": 5 } } }");

        private static string result;
    }
}
