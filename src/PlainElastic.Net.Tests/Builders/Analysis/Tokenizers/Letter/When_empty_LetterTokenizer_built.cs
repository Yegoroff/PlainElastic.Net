using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(LetterTokenizer))]
    class When_empty_LetterTokenizer_built
    {
        Because of = () => result = new LetterTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'letter' }".AltQuote());

        private static string result;
    }
}