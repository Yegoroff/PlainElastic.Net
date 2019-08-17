using Machine.Specifications;
using Moq;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;
using It = Machine.Specifications.It;
using it = Moq.It;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(BulkBuilder))]
    class When_Index_Bulk_operation_built
    {
        Establish context = () => {
            document = new FieldsTestClass {StringProperty = "1"};

            serializerMock = new Mock<IJsonSerializer>();
            serializerMock.Setup(s => s.Serialize(it.IsAny<FieldsTestClass>())).Returns("{ Serialized Object }");
        };

        Because of = () => result = new BulkBuilder(serializerMock.Object)
                                            .Index(data: document, index: "test", type: "type1", id: document.StringProperty, customOptions: "custom options",
                                                   options: new BulkOperationOptions {
                                                                    Parent = "parent",
                                                                    Percolate = "percolate",
                                                                    Routing = "routing",
                                                                    Timestamp = "timestamp",
                                                                    Ttl = "ttl",
                                                                    Version = 100,
                                                                    VersionType = "external"
                                                                });

        It should_call_serializer_with_specified_document = () =>
            serializerMock.Verify(s => s.Serialize(document), Times.Once());


        It should_return_correct_value = () =>
            result.ShouldEqual(("{ 'index': { '_index': 'test','_type': 'type1','_id': '1','_version_type': 'external','_version': 100,'_routing': 'routing','_percolate': 'percolate','_parent': 'parent','_timestamp': 'timestamp','_ttl': 'ttl',custom options } }\n" +
                                "{ Serialized Object }\n"
                               ).AltQuote());


        private static string result;
        private static Mock<IJsonSerializer> serializerMock;
        private static FieldsTestClass document;
    }
}
