using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HasChildQuery<>))]
    class When_complete_HasChildQuery_built
    {
        Because of = () => result = new HasChildQuery<FieldsTestClass>()
                                                .Type("childType")
                                                .Query(q => q.Custom("{ query }"))
                                                .Scope("query_scope")
                                                .Boost(5)
                                                .Custom("{ custom part }")
                                                .ToString();


        It should_starts_with_has_child_declaration = () =>
            result.ShouldStartWith("{ 'has_child':".AltQuote());

        It should_contain_type_part = () =>
            result.ShouldContain("'type': 'childType'".AltQuote());

        It should_contain_query_part = () =>
            result.ShouldContain("'query': { query }".AltQuote());

        It should_contain_scope_part = () =>
            result.ShouldContain("'_scope': 'query_scope'".AltQuote());

        It should_contain_boost_part = () =>
            result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'has_child': { " +
                                        "'type': 'childType'," +    
                                        "'query': { query }," +
                                        "'_scope': 'query_scope'," +
                                        "'boost': 5," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
