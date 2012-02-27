using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(RangeQuery<>))]
    class When_RangeQuery_with_only_custom_part_built
    {
        private Because of = () => result = new RangeQuery<FieldsTestClass>()                                                
                                                .Custom("'custom_range': {0}", "0-5")
                                                .ToString();

        It should_return_query_with_only_custom_part = () => result.ShouldEqual(@"{ 'range': { 'custom_range': 0-5 } }".SmartQuote());

        private static string result;
    }
}
