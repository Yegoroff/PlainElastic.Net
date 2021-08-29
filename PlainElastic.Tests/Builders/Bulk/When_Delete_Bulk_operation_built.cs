using Machine.Specifications;
using Moq;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;
using It = Machine.Specifications.It;
using it = Moq.It;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(BulkBuilder))]
    class When_Delete_Bulk_operation_built
    {
        Establish context = () => {
            document = new FieldsTestClass {StringProperty = "1"};

            serializerMock = new Mock<IJsonSerializer>();            
        };

        Because of = () => 
            result = new BulkBuilder(serializerMock.Object)
                                            .Delete(index: "test", type: "type1", id: document.StringProperty, customOptions: "custom options",
                                                   options: new BulkOperationOptions
                                                   {
                                                       Parent = "parent",
                                                       Percolate = "percolate",
                                                       Routing = "routing",
                                                       Timestamp = "timestamp",
                                                       Ttl = "ttl",
                                                       Version = 100,
                                                       VersionType = "external"
                                                   });


        It should_not_call_serializer = () =>
            serializerMock.Verify(s => s.Serialize(it.IsAny<object>()), Times.Never());

        It should_return_correct_value = () =>
            result.ShouldEqual("{ 'delete': { '_index': 'test','_type': 'type1','_id': '1','_version_type': 'external','_version': 100,'_routing': 'routing','_percolate': 'percolate','_parent': 'parent','_timestamp': 'timestamp','_ttl': 'ttl',custom options } }\n"
                               .AltQuote());

        
        private static string result;
        private static Mock<IJsonSerializer> serializerMock;
        private static FieldsTestClass document;
    }
}
