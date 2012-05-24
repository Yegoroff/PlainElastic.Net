using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(WordDelimiterTokenFilter))]
    class When_empty_WordDelimiterTokenFilter_built
    {
        Because of = () => result = new WordDelimiterTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'word_delimiter' }".AltQuote());

        private static string result;
    }
}