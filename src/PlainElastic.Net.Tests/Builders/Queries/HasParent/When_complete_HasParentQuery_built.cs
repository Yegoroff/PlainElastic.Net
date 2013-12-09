using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HasParentQuery<,>))]
    class When_complete_HasParentQuery_built
    {
        Because of = () => result = new HasParentQuery<FieldsTestClass, AnotherTestClass>()
                                                .ParentType("parentType")
                                                .Query(q => q
                                                    .Term(t => t.Field(another => another.AnotherProperty).Value("test") )
                                                )
                                                .ScoreType(HasParentScoreType.score)
                                                .Boost(5)
                                                .Custom("{ custom part }")
                                                .ToString();


        It should_starts_with_has_child_declaration = () =>
            result.ShouldStartWith("{ 'has_parent':".AltQuote());

        It should_contain_type_part = () =>
            result.ShouldContain("'parent_type': 'parentType'".AltQuote());

        It should_contain_query_part = () =>
            result.ShouldContain("'query': { 'term': { 'AnotherProperty': { 'value': 'test' } } }".AltQuote());

        It should_contain_scope_part = () =>
            result.ShouldContain("'score_type': 'score'".AltQuote());

        It should_contain_boost_part = () =>
            result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'has_parent': { " +
                                        "'parent_type': 'parentType'," +
                                        "'query': { 'term': { 'AnotherProperty': { 'value': 'test' } } }," +
                                        "'score_type': 'score'," +
                                        "'boost': 5," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
