using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(RootObject<>))]
    class When_simplest_RootObject_mapping_built
    {
        Because of = () => result = new RootObject<FieldsTestClass>("TestObject")
                                                .ToString();

        It should_start_from_specified_type_name = () => result.ShouldStartWith("'TestObject': {".AltQuote());

        It should_generate_correct_JSON_result = () => result.ShouldEqual(("'TestObject': { }").AltQuote());

        private static string result;
    }
}
