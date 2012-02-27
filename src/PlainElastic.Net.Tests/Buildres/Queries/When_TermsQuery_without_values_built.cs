using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(TermsQuery<>))]
    class When_TermsQuery_without_values_built
    {
        private Because of = () => result = new TermsQuery<FieldsTestClass>()
                                                .Field(f => f.Property1)
                                                .MinimumMatch(2)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
