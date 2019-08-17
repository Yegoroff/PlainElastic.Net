using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IdsQuery<>))]
    class When_complete_IdsQuery_built
    {
        Because of = () => result = new IdsQuery<FieldsTestClass>()
                                                .Type("Index_type")
                                                .Values(new[] { "id1", "id2" })
                                                .Boost(10)
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_start_with_ids_declaration = () =>
            result.ShouldStartWith("{ 'ids': {".AltQuote());

        It should_contain_type_part = () =>
            result.ShouldContain("'type': 'Index_type'".AltQuote());

        It should_contain_values_part = () =>
            result.ShouldContain("'values': [ 'id1','id2' ]".AltQuote());

        It should_contain_boost_part = () =>
            result.ShouldContain("'boost': 10".AltQuote());


        It should_return_correct_result = () => 
            result.ShouldEqual(("{ 'ids': { " +
                                    "'type': 'Index_type'," +
                                    "'values': [ 'id1','id2' ]," +
                                    "'boost': 10," +
                                    "{ custom part } " +
                               "} }").AltQuote());

        private static string result;
    }
}
