using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(MappingCharFilter))]
    class When_empty_MappingCharFilter_built
    {
        Because of = () => result = new MappingCharFilter()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'mapping' }".AltQuote());

        private static string result;
    }
}