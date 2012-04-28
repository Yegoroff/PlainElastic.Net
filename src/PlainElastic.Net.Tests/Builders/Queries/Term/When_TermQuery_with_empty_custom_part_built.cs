using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermQuery<>))]
    class When_TermQuery_with_empty_custom_part_built
    {
        Because of = () => result = new TermQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
