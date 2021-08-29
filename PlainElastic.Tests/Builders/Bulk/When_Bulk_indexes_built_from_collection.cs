using System.Collections.Generic;
using Machine.Specifications;
using Moq;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;
using It = Machine.Specifications.It;
using it = Moq.It;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(BulkBuilder))]
    class When_Bulk_indexes_built_from_collection
    {
        Establish context = () => {
            collection = new List<FieldsTestClass>
                                                   {
                                                       new FieldsTestClass {StringProperty = "1"},
                                                       new FieldsTestClass {StringProperty = "2"},
                                                       new FieldsTestClass {StringProperty = "3"}
                                                   };

            serializerMock = new Mock<IJsonSerializer>();
            serializerMock.Setup(s => s.Serialize(it.IsAny<FieldsTestClass>())).Returns("{ Serialized Object }");

            bulkBuilder = new BulkBuilder(serializerMock.Object);
        };

        Because of = () => result = bulkBuilder.BuildCollection(
                                                    collection,
                                                    (builder, element) => builder.Index(data: element, index: "test", type: "type1", id: element.StringProperty)
                                                );

        It should_return_correct_value =
            () => result.ShouldEqual(("{ 'index': { '_index': 'test','_type': 'type1','_id': '1' } }\n" +
                                      "{ Serialized Object }\n" +
                                      "{ 'index': { '_index': 'test','_type': 'type1','_id': '2' } }\n" +
                                      "{ Serialized Object }\n" +
                                      "{ 'index': { '_index': 'test','_type': 'type1','_id': '3' } }\n" +
                                      "{ Serialized Object }\n").AltQuote());


        private static string result;
        private static Mock<IJsonSerializer> serializerMock;
        private static List<FieldsTestClass> collection;
        private static BulkBuilder bulkBuilder;
    }
}
