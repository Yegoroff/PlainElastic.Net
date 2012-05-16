using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PathHierarchyTokenizer))]
    class When_empty_PathHierarchyTokenizer_built
    {
        Because of = () => result = new PathHierarchyTokenizer()
                                            .Name("name")
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'path_hierarchy' }".AltQuote());

        private static string result;
    }
}