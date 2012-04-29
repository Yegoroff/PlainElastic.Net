using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(BoolQuery<>))]
    class When_BoolQuery_with_useActualShouldCount_built
    {
        Because of = () => result = new BoolQuery<FieldsTestClass>()
                                                .Should( s => s
                                                    .Term(t => t.Custom("term1"))
                                                    .Term(t => t
                                                        .Field(doc=> doc.StringProperty)
                                                        .Value("")
                                                    ) 
                                                )
                                                .MinimumNumberShouldMatch(2, useActualShouldCount: true)
                                                .ToString();

        It should_contain_minimum_number_should_match_equals_to_1 = () => result.ShouldContain("'minimum_number_should_match': 1".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual(@"{ 'bool': { 'should': [ { 'term': { term1 } } ],'minimum_number_should_match': 1 } }".AltQuote());

        private static string result;
    }
}
