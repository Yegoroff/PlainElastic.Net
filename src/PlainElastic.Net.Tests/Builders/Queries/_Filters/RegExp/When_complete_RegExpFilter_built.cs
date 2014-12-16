using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RegExpFilter<>))]
    class When_complete_RegExpFilter_built
    {
        Because of = () => result = new RegExpFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value(value: "s.y*",
                                                       flags: RegExpSyntaxFlags.COMPLEMENT | RegExpSyntaxFlags.EMPTY | RegExpSyntaxFlags.INTERSECTION)
                                                .Cache(true)
                                                .CacheKey("key")
                                                .Name("test")
                                                .ToString();


        It should_contain_field_name = () => result.ShouldContain("'StringProperty':".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain("'_cache': true".AltQuote());

        It should_contain_cachekey_part = () => result.ShouldContain("'_cache_key': 'key'".AltQuote());

        It should_contain_name_part = () => result.ShouldContain("'_name': 'test'".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ 'regexp': { " +
                                                                        "'StringProperty': { " +
                                                                                "'value': 's.y*', " +
                                                                                "'flags': 'COMPLEMENT|EMPTY|INTERSECTION'" +
                                                                        " }," +
                                                                        "'_cache': true," +
                                                                        "'_cache_key': 'key'," +
                                                                        "'_name': 'test' } }").AltQuote());

        private static string result;
    }
}
