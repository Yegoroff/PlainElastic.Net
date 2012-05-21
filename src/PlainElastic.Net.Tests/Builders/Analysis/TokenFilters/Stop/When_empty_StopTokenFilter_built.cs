using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StopTokenFilter))]
    class When_empty_StopTokenFilter_built
    {
        Because of = () => result = new StopTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'stop' }".AltQuote());

        private static string result;
    }
}