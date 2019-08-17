using Machine.Specifications;
using PlainElastic.Net.IndexSettings;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(IndexSettingsBuilder))]
    class When_empty_IndexSettingsBuilder_built
    {
        Because of = () => result = new IndexSettingsBuilder()
                                            .Build();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}   