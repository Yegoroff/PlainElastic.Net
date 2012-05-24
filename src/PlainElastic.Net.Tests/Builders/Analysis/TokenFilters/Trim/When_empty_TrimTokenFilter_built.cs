using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(TrimTokenFilter))]
    class When_empty_TrimTokenFilter_built
    {
        Because of = () => result = new TrimTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'trim' }".AltQuote());

        private static string result;
    }
}