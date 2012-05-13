using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(BoolFilter<>))]
    class When_empty_BoolFilter_built
    {
        Because of = () => result = new BoolFilter<FieldsTestClass>()
                                                .Must(m => m
                                                )
                                                .MustNot(mn => mn                                                    
                                                )
                                                .Should(s => s                                                    
                                                )
                                                .MinimumNumberShouldMatch(2)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
