using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NotFilter<>))]
    class When_complete_NotFilter_built
    {
        Because of = () => result = new NotFilter<FieldsTestClass>()
                                                .Filter(f => f
                                                    .Term(t => t
                                                        .Field(doc=>doc.StringProperty)
                                                        .Value("1")                                                        
                                                    )
                                                )
                                                .Cache(true)
                                                .ToString();


        It should_starts_with_not_declaration = () => result.ShouldStartWith("{ 'not': {".AltQuote());

        It should_contain_filter_part = () => result.ShouldContain("'filter': ".AltQuote());

        It should_contain_internal_term_filter_part = () => result.ShouldContain("{ 'term': { 'StringProperty': '1' } }".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain("'_cache': true".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ 'not': { " +
                                                                        "'filter': { " +
                                                                            "'term': { 'StringProperty': '1' } " +
                                                                        "}," +
                                                                        "'_cache': true " +
                                                                      "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
