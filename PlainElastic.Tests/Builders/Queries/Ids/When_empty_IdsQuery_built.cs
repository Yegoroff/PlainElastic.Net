using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IdsQuery<>))]
    class When_empty_IdsQuery_built
    {
        Because of = () => result = new IdsQuery<FieldsTestClass>()
                                                .Values(null)
                                                .ToString();

        It should_return_empty_result = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
