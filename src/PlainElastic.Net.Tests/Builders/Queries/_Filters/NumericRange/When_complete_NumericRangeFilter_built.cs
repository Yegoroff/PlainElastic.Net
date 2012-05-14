using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NumericRangeFilter<>))]
    class When_complete_NumericRangeFilter_built
    {
        Because of = () => result = new NumericRangeFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .From("1")
                                                .To("100")
                                                .IncludeLower(true)
                                                .IncludeUpper(false)
                                                .Cache(false)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .Custom("'custom': {0}".AltQuote(), "123")
                                                .ToString();

        It should_contain_cache_part = () => result.ShouldContain("'_cache': false".AltQuote());

        It should_contain_cache_key_part = () => result.ShouldContain("'_cache_key': 'CacheKey'".AltQuote());

        It should_contain_name_part = () => result.ShouldContain("'_name': 'FilterName'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ 'numeric_range': { " +
                                                                        "'StringProperty': { " +
                                                                              "'from': '1'," +
                                                                              "'to': '100'," +
                                                                              "'include_lower': true," +
                                                                              "'include_upper': false," +
                                                                              "'custom': 123 " +
                                                                        "}," +
                                                                        "'_cache': false," +
                                                                        "'_cache_key': 'CacheKey'," +
                                                                        "'_name': 'FilterName' " +
                                                                    "} " +
                                                                  "}").AltQuote());
        private static string result;
    }
}
