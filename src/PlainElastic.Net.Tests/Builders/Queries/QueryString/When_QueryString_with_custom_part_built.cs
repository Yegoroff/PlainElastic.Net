using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryString<>))]
    class When_QueryString_with_custom_part_built
    {
        Because of = () => result = new QueryString<FieldsTestClass>()
                                                .DefaultField(f => f.StringProperty)
                                                .Custom("custom part")
                                                .ToString();


        It should_contain_default_field_part = () => result.ShouldContain("'default_field': 'StringProperty'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom part");

        It should_return_correct_query = () => result.ShouldEqual("{ 'query_string': { 'default_field': 'StringProperty',custom part } }".AltQuote());

        private static string result;
    }
}
