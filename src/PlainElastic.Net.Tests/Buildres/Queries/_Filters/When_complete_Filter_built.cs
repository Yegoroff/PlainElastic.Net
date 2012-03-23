using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(Filter<>))]
    class When_complete_Filter_built
    {
        Because of = () => result = new Filter<FieldsTestClass>()                                                
                                            .And( a => a.Custom("And"))
                                            .Exists(e => e.Custom("Exists"))
                                            .Nested(n => n.Custom("Nested"))
                                            .Range(r => r.Custom("Range"))
                                            .Term(t => t.Custom("Term"))
                                            .Terms(t => t.Custom("Terms"))
                                            .ToString();

        It should_starts_with_nested_declaration = () => result.ShouldStartWith("'filter': {".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual("'filter': { 'and': [ And ] },{ 'exists': { Exists } },{ 'nested': { Nested } },{ 'range': { Range } },{ 'term': { Term } },{ 'terms': { Terms } }".AltQuote());

        private static string result;
    }
}
