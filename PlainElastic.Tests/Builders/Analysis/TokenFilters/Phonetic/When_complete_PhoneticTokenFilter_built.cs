using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(PhoneticTokenFilter))]
    class When_complete_PhoneticTokenFilter_built
    {
        Because of = () => result = new PhoneticTokenFilter()
                                            .Name("name")
                                            .Version("3.6")
                                            .Encoder(PhoneticTokenFilterEncoders.soundex)
                                            .Replace(false)
                                            .CustomPart("{ Custom }")
                                            .ToString();

        It should_start_with_name = () => result.ShouldStartWith("'name': {".AltQuote());

        It should_contain_type_part = () => result.ShouldContain("'type': 'phonetic'".AltQuote());

        It should_contain_version_part = () => result.ShouldContain("'version': '3.6'".AltQuote());

        It should_contain_encoder_part = () => result.ShouldContain("'encoder': 'soundex'".AltQuote());

        It should_contain_replace_part = () => result.ShouldContain("'replace': false".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'name': { " +
                                                                    "'type': 'phonetic'," +
                                                                    "'version': '3.6'," +
                                                                    "'encoder': 'soundex'," +
                                                                    "'replace': false," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}