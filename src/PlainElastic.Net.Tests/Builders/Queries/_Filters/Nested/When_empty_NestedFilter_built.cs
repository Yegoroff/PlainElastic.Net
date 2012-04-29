using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NestedFilter<>))]
    class When_empty_NestedFilter_built
    {
        Because of = () => result = new NestedFilter<FieldsTestClass>()                                                
                                                .Path(f=>f.StringProperty)
                                                .Cache(true)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
