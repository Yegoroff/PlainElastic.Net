using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeQuery<>))]
    class When_RangeQuery_with_only_custom_part_built
    {
        Because of = () => result = new RangeQuery<FieldsTestClass>()                                                
                                                .Custom("'custom_range': {0}".AltQuote(), "0-5")
                                                .ToString();

        It should_return_query_with_only_custom_part = () => result.ShouldEqual(@"{ 'range': { 'custom_range': 0-5 } }".AltQuote());

        private static string result;
    }
}
