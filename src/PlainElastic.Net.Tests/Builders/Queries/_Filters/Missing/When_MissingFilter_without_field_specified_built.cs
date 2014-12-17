using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MissingFilter<>))]
    class When_MissingFilter_without_field_specified_built
    {
        Because of = () =>
            result = new MissingFilter<FieldsTestClass>()
                        .ShouldMiss(true)
                        .ToString();
      
        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
