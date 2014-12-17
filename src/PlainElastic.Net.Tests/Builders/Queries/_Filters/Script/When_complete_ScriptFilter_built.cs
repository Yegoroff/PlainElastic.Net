using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ScriptFilter<>))]
    class When_complete_ScriptFilter_built
    {
        Because of = () => result = new ScriptFilter<FieldsTestClass>()
                                                .Lang(ScriptLangs.js)
                                                .Params( "{ 'param1' : 2, 'param2' : 3.1 }".AltQuote())
                                                .Script( "script 'part'")
                                                .Cache(true)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .Custom("{ custom part }")
                                                .ToString();


        It should_starts_with_script_declaration = () =>
            result.ShouldStartWith("{ 'script':".AltQuote());

        It should_contain_params_part = () =>
            result.ShouldContain("'params': { 'param1' : 2, 'param2' : 3.1 }".AltQuote());

        It should_contain_scripts_part = () =>
            result.ShouldContain("'script': 'script `part`'".AltQuote());

        It should_contain_cache_part = () => 
            result.ShouldContain("'_cache': true".AltQuote());

        It should_contain_cache_key_part = () => 
            result.ShouldContain("'_cache_key': 'CacheKey'".AltQuote());

        It should_contain_name_part = () => 
            result.ShouldContain("'_name': 'FilterName'".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'script': { " +
                                        "'lang': 'js'," +
                                        "'params': { 'param1' : 2, 'param2' : 3.1 }," +
                                        "'script': 'script `part`'," +
                                        "'_cache': true," +
                                        "'_cache_key': 'CacheKey'," +
                                        "'_name': 'FilterName'," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
