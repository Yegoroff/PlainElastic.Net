using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(QueryFilter<>))]
    class When_complete_QueryFilter_built
    {
        Because of = () => result = new QueryFilter<FieldsTestClass>()
                                                .Cache(false)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .Custom("Query")
                                                .ToString();

        It should_contain_cache_part = () => result.ShouldContain(@"'_cache': false".AltQuote());
        
        It should_contain_cache_key_part = () => result.ShouldContain(@"'_cache_key': 'CacheKey'".AltQuote());

        It should_contain_name_part = () => result.ShouldContain(@"'_name': 'FilterName'".AltQuote());

        It should_contain_query_part = () => result.ShouldContain(@"'query': Query".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'fquery': { 'query': Query,'_cache': false,'_cache_key': 'CacheKey','_name': 'FilterName' } }".AltQuote());

        private static string result;
    }
}
