using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(OrFilter<>))]
    class When_complete_OrFilter_built
    {
        Because of = () => result = new OrFilter<FieldsTestClass>()                                                
                                            .And( a => a.Custom("And"))
                                            .Exists(e => e.Custom("Exists"))
                                            .Nested(n => n.Custom("Nested"))
                                            .Range(r => r.Custom("Range"))
                                            .Term(t => t.Custom("Term"))
                                            .Terms(t => t.Custom("Terms"))                                            
                                            .ToString();

        It should_starts_with_or_declaration = () => result.ShouldStartWith("{ 'or': [".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual("{ 'or': [ { 'and': [ And ] },{ 'exists': { Exists } },{ 'nested': { Nested } },{ 'range': { Range } },{ 'term': { Term } },{ 'terms': { Terms } } ] }".AltQuote());

        private static string result;
    }
}
