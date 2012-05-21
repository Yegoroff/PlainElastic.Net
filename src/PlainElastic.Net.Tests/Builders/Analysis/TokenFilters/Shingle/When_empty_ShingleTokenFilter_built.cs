using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(ShingleTokenFilter))]
    class When_empty_ShingleTokenFilter_built
    {
        Because of = () => result = new ShingleTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'shingle' }".AltQuote());

        private static string result;
    }
}