using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(AndFilter<>))]
    class When_complete_AndFilter_built
    {
        Because of = () => result = new AndFilter<FieldsTestClass>()                                                
                                            .And( a => a.Custom("And"))
                                            .Exists(e => e.Custom("Exists"))
                                            .Nested(n => n.Custom("Nested"))
                                            .Range(r => r.Custom("Range"))
                                            .Term(t => t.Custom("Term"))
                                            .Terms(t => t.Custom("Terms"))                                            
                                            .ToString();

        It should_starts_with_and_declaration = () => result.ShouldStartWith("{ 'and': [".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual("{ 'and': [ { 'and': [ And ] },{ 'exists': { Exists } },{ 'nested': { Nested } },{ 'range': { Range } },{ 'term': { Term } },{ 'terms': { Terms } } ] }".AltQuote());

        private static string result;
    }
}
