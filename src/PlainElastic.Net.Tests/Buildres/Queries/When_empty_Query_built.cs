using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(Query<>))]
    class When_empty_Query_built
    {
        private Because of = () => 
            result = new Query<FieldsTestClass>()                         
                        .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
