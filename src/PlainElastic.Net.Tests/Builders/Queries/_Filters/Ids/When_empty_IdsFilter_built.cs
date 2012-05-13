using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IdsFilter<>))]
    class When_empty_IdsFilter_built
    {
        Because of = () => result = new IdsFilter<FieldsTestClass>()
                                                .Values(null)
                                                .ToString();

        It should_return_empty_result = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
