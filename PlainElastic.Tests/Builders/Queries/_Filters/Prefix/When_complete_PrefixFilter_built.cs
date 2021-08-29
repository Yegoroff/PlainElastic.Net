using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(PrefixFilter<>))]
    class When_complete_PrefixFilter_built
    {
        Because of = () => result = new PrefixFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Prefix("pre")
                                                .Cache(true)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .Custom("custom part")
                                                .ToString();


        It should_starts_with_prefix_declaration = () => result.ShouldStartWith("{ 'prefix': {".AltQuote());

        It should_contain_field_name_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_prefix_part = () => result.ShouldContain("'prefix': 'pre'".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain("'_cache': true".AltQuote());

        It should_contain_cache_key_part = () => result.ShouldContain("'_cache_key': 'CacheKey'".AltQuote());

        It should_contain_name_part = () => result.ShouldContain("'_name': 'FilterName'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom part".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                              "'prefix': { " +
                                                                  "'StringProperty': { " +
                                                                      "'prefix': 'pre'," +
                                                                      "'_cache': true," +
                                                                      "'_cache_key': 'CacheKey'," +
                                                                      "'_name': 'FilterName'," +
                                                                      "custom part " +
                                                                  "} " +
                                                              "} " +
                                                          "}").AltQuote());

        private static string result;
    }
}
