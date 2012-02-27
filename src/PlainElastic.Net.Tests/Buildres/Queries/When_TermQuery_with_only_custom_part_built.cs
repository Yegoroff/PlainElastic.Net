using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(TermQuery<>))]
    class When_TermQuery_with_only_custom_part_built
    {
        private Because of = () => result = new TermQuery<FieldsTestClass>()
                                                .Custom("'tag': {0}", "wow".Quotate())
                                                .ToString();

        It should_contain_custom_part = () => result.ShouldContain(@"'tag': 'wow'".SmartQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'term': { 'tag': 'wow' } }".SmartQuote());

        private static string result;
    }
}
