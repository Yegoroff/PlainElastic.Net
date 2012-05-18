using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(StandardTokenFilter))]
    class When_empty_StandardTokenFilter_built
    {
        Because of = () => result = new StandardTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'standard' }".AltQuote());

        private static string result;
    }
}