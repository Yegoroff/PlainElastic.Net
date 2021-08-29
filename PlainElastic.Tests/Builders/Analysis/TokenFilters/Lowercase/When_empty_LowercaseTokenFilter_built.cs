using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(LowercaseTokenFilter))]
    class When_empty_LowercaseTokenFilter_built
    {
        Because of = () => result = new LowercaseTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'lowercase' }".AltQuote());

        private static string result;
    }
}