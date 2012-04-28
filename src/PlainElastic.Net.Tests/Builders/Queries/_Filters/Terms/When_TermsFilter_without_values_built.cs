using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermsFilter<>))]
    class When_TermsFilter_without_values_built
    {
        Because of = () => result = new TermsFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)                                                
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
