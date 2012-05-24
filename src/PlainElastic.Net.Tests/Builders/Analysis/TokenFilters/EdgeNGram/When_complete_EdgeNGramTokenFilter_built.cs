using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(EdgeNGramTokenFilter))]
    class When_complete_EdgeNGramTokenFilter_built
    {
        Because of = () => result = new EdgeNGramTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .MinGram(2)
                                            .MaxGram(3)
                                            .Side(EdgeNGramSide.front)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'edgeNGram'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_min_gram_part = () => result.ShouldContain("'min_gram': 2".AltQuote());

        It should_contain_max_gram_part = () => result.ShouldContain("'max_gram': 3".AltQuote());

        It should_contain_side_part = () => result.ShouldContain("'side': 'front'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'edgeNGram'," +
                                                                    "'version': '3.6'," +
                                                                    "'min_gram': 2," +
                                                                    "'max_gram': 3," +
                                                                    "'side': 'front'," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}