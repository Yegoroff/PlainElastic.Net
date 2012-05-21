using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TruncateTokenFilter))]
    class When_empty_TruncateTokenFilter_built
    {
        Because of = () => result = new TruncateTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'truncate' }".AltQuote());

        private static string result;
    }
}