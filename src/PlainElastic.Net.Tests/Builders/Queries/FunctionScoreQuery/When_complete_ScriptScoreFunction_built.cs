using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ScriptScoreFunction<>))]
    class When_complete_ScriptScoreFunction_built
    {
        Because of = () => result = new ScriptScoreFunction<FieldsTestClass>()
                                                .Script("Script")
                                                .Lang(ScriptLangs.python)
                                                .Params("{{ 'param1': {0} }}".AltQuoteF(123))
                                                .ToString();

        It should_contain_script_part = () => result.ShouldContain("'script': 'Script'".AltQuote());

        It should_contain_lang_part = () => result.ShouldContain("'lang': 'python'".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("'script_score': { " +
                                                                            "'script': 'Script'," +
                                                                            "'lang': 'python'," +
                                                                            "'params': { 'param1': 123 }" +
                                                                        " }").AltQuote());

        private static string result;
    }
}
