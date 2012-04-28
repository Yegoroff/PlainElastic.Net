using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FilteredQuery<>))]
    class When_empty_FilteredQuery_built
    {
        Because of = () => result = new FilteredQuery<FieldsTestClass>()                                                
                                                .ToString();

        It should_return_empty_result = () => result.ShouldBeEmpty();

        private static string result;
    }
}
