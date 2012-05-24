using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(UniqueTokenFilter))]
    class When_empty_UniqueTokenFilter_built
    {
        Because of = () => result = new UniqueTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'unique' }".AltQuote());

        private static string result;
    }
}