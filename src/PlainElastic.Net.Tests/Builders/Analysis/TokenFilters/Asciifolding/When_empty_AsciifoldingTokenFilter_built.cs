using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(AsciifoldingTokenFilter))]
    class When_empty_AsciifoldingTokenFilter_built
    {
        Because of = () => result = new AsciifoldingTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'asciifolding' }".AltQuote());

        private static string result;
    }
}