using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(NestedQuery<>))]
    class When_complete_NestedQuery_built
    {
        Because of = () => result = new NestedQuery<FieldsTestClass>()
                                                .ScoreMode(ScoreMode.max)
                                                .Scope("scope")
                                                .Path(f=>f.StringProperty)
                                                .Query( q=>q
                                                    .Custom("Query")
                                                 )
                                                .ToString();

        It should_starts_with_nested_declaration = () => result.ShouldStartWith("{ 'nested': {".AltQuote());

        It should_contain_score_mode = () => result.ShouldContain("'score_mode': 'max'".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'_scope': 'scope'".AltQuote());

        It should_contain_path = () => result.ShouldContain("'path': 'StringProperty'".AltQuote());
        
        It should_contain_query_part = () => result.ShouldContain("'query': Query ".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("{ " +
                                                                    "'nested': { " +
                                                                        "'score_mode': 'max'," +
                                                                        "'_scope': 'scope'," +
                                                                        "'path': 'StringProperty'," +
                                                                        "'query': Query " +
                                                                    "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
