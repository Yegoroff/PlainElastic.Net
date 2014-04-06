using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NestedFilter<>))]
    class When_NestedFilter_with_query_part_built
    {
        Because of = () => result = new NestedFilter<FieldsTestClass>()                                                
                                                .Path(f=>f.StringProperty)
                                                .Cache(true)
                                                .Query( q=>q
                                                    .Custom("Query")
                                                 )
                                                .ToString();

        It should_starts_with_nested_declaration = () => result.ShouldStartWith(@"{ 'nested': {".AltQuote());

        It should_contain_path = () => result.ShouldContain(@"'path': 'StringProperty'".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain(@"'_cache': true".AltQuote());
        
        It should_contain_query_part = () => result.ShouldContain(@"'query': Query ".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(@"{ 'nested': { 'path': 'StringProperty','_cache': true,'query': Query } }".AltQuote());

        private static string result;
    }
}
