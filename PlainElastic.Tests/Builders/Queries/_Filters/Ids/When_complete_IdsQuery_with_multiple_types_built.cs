using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(IdsFilter<>))]
    class When_IdsQuery_with_multiple_types_built
    {
        Because of = () => result = new IdsFilter<FieldsTestClass>()
                                                .Types(new[] { "type1", "type2" })
                                                .Values(new[] { "id1", "id2" })
                                                .ToString();


        It should_start_with_ids_declaration = () =>
            result.ShouldStartWith("{ 'ids': {".AltQuote());

        It should_contain_types_part = () =>
            result.ShouldContain("'types': [ 'type1','type2' ]".AltQuote());

        It should_contain_values_part = () =>
            result.ShouldContain("'values': [ 'id1','id2' ]".AltQuote());

        It should_return_correct_result = () => 
            result.ShouldEqual(("{ 'ids': { " +
                                    "'types': [ 'type1','type2' ]," +
                                    "'values': [ 'id1','id2' ] " +
                               "} }").AltQuote());

        private static string result;
    }
}
