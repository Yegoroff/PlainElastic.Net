using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(LengthTokenFilter))]
    class When_empty_LengthTokenFilter_built
    {
        Because of = () => result = new LengthTokenFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'length' }".AltQuote());

        private static string result;
    }
}