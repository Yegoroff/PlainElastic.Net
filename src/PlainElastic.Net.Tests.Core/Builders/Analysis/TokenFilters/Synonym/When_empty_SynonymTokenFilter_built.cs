using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(SynonymTokenFilter))]
    class When_empty_SynonymTokenFilter_built
    {
        Because of = () => result = new SynonymTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'synonym' }".AltQuote());

        private static string result;
    }
}