using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(ElisionTokenFilter))]
    class When_empty_ElisionTokenFilter_built
    {
        Because of = () => result = new ElisionTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'elision' }".AltQuote());

        private static string result;
    }
}