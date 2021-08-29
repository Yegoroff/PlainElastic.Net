using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    class When_Sort_with_script_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                                .Script(script: "doc['field_name'].value * factor", type: "number", @params: "{ \"factor\": 1.1 }", order: SortDirection.asc)
                                                .ToString();

        It should_return_correct_value = () => result.ShouldEqual( ("'sort': [{ " +
                                                                        "'_script': { " +
                                                                            "'script': 'doc[`field_name`].value * factor'," +
                                                                            "'type': 'number'," +
                                                                            "'params': { " +
                                                                                "'factor': 1.1" +
                                                                            " }," +
                                                                            "'order': 'asc'" +
                                                                        " }" +
                                                                    " }]").AltQuote());

        private static string result;
    }
}
