using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(CustomScoreQuery<>))]
    class When_empty_CustomScoreQuery_built
    {
        Because of = () => result = new CustomScoreQuery<FieldsTestClass>()
                                                .Query(q => q)
                                                .Boost(5)
                                                .Lang(ScriptLangs.js)
                                                .Params("'param1' : 2, 'param2' : 3.1".AltQuote())
                                                .Script("script 'part'")
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
