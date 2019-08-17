using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(ShingleTokenFilter))]
    class When_complete_ShingleTokenFilter_built
    {
        Because of = () => result = new ShingleTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .MaxShingleSize(2)
                                            .OutputUnigrams(false)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'shingle'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_max_shingle_size_part = () => result.ShouldContain("'max_shingle_size': 2".AltQuote());

        It should_contain_output_unigrams_part = () => result.ShouldContain("'output_unigrams': false".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'shingle'," +
                                                                    "'version': '3.6'," +
                                                                    "'max_shingle_size': 2," +
                                                                    "'output_unigrams': false," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}