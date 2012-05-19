using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(ReverseTokenFilter))]
    class When_empty_ReverseTokenFilter_built
    {
        Because of = () => result = new ReverseTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'reverse' }".AltQuote());

        private static string result;
    }
}