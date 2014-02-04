using Machine.Specifications;
using Moq;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;
using It = Machine.Specifications.It;
using it = Moq.It;


namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(BulkBuilder))]
    class When_Create_Bulk_operation_built_for_string
    {
        Establish context = () => {
            documantJson = "{ 'name': 'One', 'value': 1 }".AltQuote();

            serializerStub = Mock.Of<IJsonSerializer>();
        };

        Because of = () => result = new BulkBuilder(serializerStub)
                                            .Create(data: documantJson, index: "test", type: "type1");


        It should_return_correct_value = () =>
            result.ShouldEqual(("{ 'create': { '_index': 'test','_type': 'type1' } }\n" +
                                "{ 'name': 'One', 'value': 1 }\n"
                               ).AltQuote());


        private static string result;
        private static IJsonSerializer serializerStub;
        private static string documantJson;
    }
}
