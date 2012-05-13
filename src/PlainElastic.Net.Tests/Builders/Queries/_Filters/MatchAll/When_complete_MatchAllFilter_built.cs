using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MatchAllFilter<>))]
    class When_complete_MatchAllFilter_built
    {
        Because of = () => result = new MatchAllFilter<FieldsTestClass>()
                                                .ToString();


        It should_starts_with_match_all_declaration = () => result.ShouldStartWith("{ 'match_all': {".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'match_all': {} }").AltQuote());

        private static string result;
    }
}
