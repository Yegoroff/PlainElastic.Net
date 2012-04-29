using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermsQuery<>))]
    class When_complete_TermsQuery_built
    {
        Because of = () => result = new TermsQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Values("One", "Two")
                                                .MinimumMatch(2)
                                                .ToString();

        It should_contain_minimum_match_part = () => result.ShouldContain(@"'minimum_match': 2".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'terms': { 'StringProperty': [ 'One','Two' ],'minimum_match': 2 } }".AltQuote());

        private static string result;
    }
}
