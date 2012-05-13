using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(Analysis))]
    class When_empty_Analysis_built
    {
        Because of = () => result = new Analysis()
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'analysis': {  }".AltQuote());

        private static string result;
    }
}