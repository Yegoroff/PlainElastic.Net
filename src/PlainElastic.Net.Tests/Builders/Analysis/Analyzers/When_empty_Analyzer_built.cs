using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(Analyzer))]
    class When_empty_Analyzer_built
    {
        Because of = () => result = new Analyzer()
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'analyzer': {  }".AltQuote());

        private static string result;
    }
}