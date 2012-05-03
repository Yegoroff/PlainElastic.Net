using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TextQuery<>))]
    class When_TextQuery_without_query_built
    {
        Because of = () => result = new TextQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Boost(5)
                                                .Type(TextQueryType.phrase)
                                                .Operator(Operator.AND)
                                                .Analyzer(DefaultAnalyzers.standard)
                                                .Fuzziness(0.3)
                                                .PrefixLength(7)
                                                .MaxExpansions(10)
                                                .Slop(4)
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
