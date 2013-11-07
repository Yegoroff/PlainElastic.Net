using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HasChildFilter<,>))]
    class When_complete_HasChildFilter_built
    {
        Because of = () => result = new HasChildFilter<FieldsTestClass, AnotherTestClass>()
                                                .Type("childType")
                                                .Query(q => q
                                                    .Term(t => t.Field(another => another.AnotherProperty).Value("query") )
                                                )
                                                .Filter(f=>f
                                                    .Term(t => t.Field(another => another.AnotherProperty).Value("filter") )
                                                )
                                                .Scope("query_scope")
                                                .Name("filter_name")
                                                .Custom("{ custom part }")
                                                .ToString();


        It should_starts_with_has_child_declaration = () =>
            result.ShouldStartWith("{ 'has_child':".AltQuote());

        It should_contain_type_part = () =>
            result.ShouldContain("'type': 'childType'".AltQuote());

        It should_contain_query_part = () =>
            result.ShouldContain("'query': { 'term': { 'AnotherProperty': { 'value': 'query' } } }".AltQuote());

        It should_contain_filter_part = () =>
            result.ShouldContain("'filter': { 'term': { 'AnotherProperty': 'filter' } }".AltQuote());

        It should_contain_scope_part = () =>
            result.ShouldContain("'_scope': 'query_scope'".AltQuote());

        It should_contain_name_part = () =>
            result.ShouldContain("'_name': 'filter_name'".AltQuote());


        It should_contain_custom_part = () =>
            result.ShouldContain("{ custom part }".AltQuote());


        It should_return_correct_result = () =>
            result.ShouldEqual(("{ " +
                                    "'has_child': { " +
                                        "'type': 'childType'," +
                                        "'query': { 'term': { 'AnotherProperty': { 'value': 'query' } } }," +
                                        "'filter': { 'term': { 'AnotherProperty': 'filter' } }," +
                                        "'_scope': 'query_scope'," +
                                        "'_name': 'filter_name'," +
                                        "{ custom part } " +
                                   "} " +
                               "}").AltQuote());

        private static string result;
    }
}
