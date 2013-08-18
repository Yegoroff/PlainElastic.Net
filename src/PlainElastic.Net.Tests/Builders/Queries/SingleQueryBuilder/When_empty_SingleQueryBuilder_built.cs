using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(SingleQueryBuilder<>))]
    class When_empty_SingleQueryBuilder_built
    {
        Because of = () =>
            result = new SingleQueryBuilder<FieldsTestClass>()
                                                .Build();

        It should_return_correct_result = () =>
                result.ShouldEqual(("").AltQuote());

        private static string result;
    }
}
