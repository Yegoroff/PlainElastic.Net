using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ExistsFilter<>))]
    class When_ExistsFilter_without_field_specified_built
    {
        Because of = () => result = new ExistsFilter<FieldsTestClass>()
                                                .ShouldExists(true)
                                                .ToString();
      
        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
