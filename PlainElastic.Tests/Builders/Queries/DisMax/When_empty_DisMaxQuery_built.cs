using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(DisMaxQuery<>))]
    class When_empty_DisMaxQuery_built
    {
        Because of = () => result = new DisMaxQuery<FieldsTestClass>()
                                                .Queries(q => q                                                    
                                                )
                                                .Boost(10)
                                                .TieBreaker(0.5)
                                                .ToString();

        It should_return_empty_result = () => result.ShouldBeEmpty();

        private static string result;
    }
}
