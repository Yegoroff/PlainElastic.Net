using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NestedFilter<>))]
    class When_complete_NestedFilter_built
    {
        Because of = () => result = new NestedFilter<FieldsTestClass>()                                                
                                                .Path(f=>f.StringProperty)
                                                .Cache(true)
                                                .Query( q=>q
                                                    .Custom("Query")
                                                 )
                                                 .Filter(f=>f 
                                                    .Custom("Filter")
                                                 )
                                                .ToString();

        It should_starts_with_nested_declaration = () => result.ShouldStartWith(@"{ 'nested': {".AltQuote());

        It should_contain_path = () => result.ShouldContain(@"'path': 'StringProperty'".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain(@"'_cache': true".AltQuote());
        
        It should_contain_query_part = () => result.ShouldContain(@"'query': Query".AltQuote());

        It should_contain_filter_part = () => result.ShouldContain(@"'filter': Filter ".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(@"{ 'nested': { 'path': 'StringProperty','_cache': true,'query': Query,'filter': Filter } }".AltQuote());

        private static string result;
    }
}
