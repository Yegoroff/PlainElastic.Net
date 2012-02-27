using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(RangeFilter<>))]
    class When_complete_RangeFilter_built
    {
        private Because of = () => result = new RangeFilter<FieldsTestClass>()
                                                .Field(f => f.Property1)
                                                .From("1")
                                                .To("100")
                                                .IncludeLower(true)
                                                .IncludeUpper(false)
                                                .Cache(false)
                                                .Custom("'custom': {0}", "123")
                                                .ToString();

        It should_contain_cache_part = () => result.ShouldContain(@"'_cache': false".SmartQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'range': { 'Property1': { 'from': '1','to': '100','include_lower': true,'include_upper': false,'custom': 123 },'_cache': false } }".SmartQuote());

        private static string result;
    }
}
