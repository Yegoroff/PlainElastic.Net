using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NestedQuery<>))]
    class When_empty_NestedQuery_built
    {
        Because of = () => result = new NestedQuery<FieldsTestClass>()                                                
                                                .ScoreMode(ScoreMode.max)
                                                .Path(f=>f.StringProperty)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
