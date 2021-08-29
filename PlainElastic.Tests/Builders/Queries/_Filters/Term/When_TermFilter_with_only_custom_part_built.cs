using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermFilter<>))]
    class When_TermFilter_with_only_custom_part_built
    {
        Because of = () => result = new TermFilter<FieldsTestClass>()
                                                .Custom("'tag': {0}".AltQuote(), "wow".Quotate())
                                                .ToString();

        It should_contain_custom_part = () => result.ShouldContain(@"'tag': 'wow'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'term': { 'tag': 'wow' } }".AltQuote());

        private static string result;
    }
}
