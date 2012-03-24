using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(ConstantScoreQuery<>))]
    class When_empty_ConstantScoreQuery_built
    {
        Because of = () => result = new ConstantScoreQuery<FieldsTestClass>()
                                                .Boost(5)
                                                .ToString();

        private It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
