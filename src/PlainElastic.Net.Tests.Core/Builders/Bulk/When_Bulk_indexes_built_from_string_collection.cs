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
    class When_Bulk_indexes_built_from_string_collection
    {
        Establish context = () => {
            collection = new List<string>
                                        {
                                            "{'name': 'One', 'value': 1 }".AltQuote(),
                                            "{'name': 'Two', 'value': 2 }".AltQuote()
                                        };

            var serializerStub = Mock.Of<IJsonSerializer>();
            bulkBuilder = new BulkBuilder(serializerStub);
        };

        Because of = () => result = bulkBuilder.BuildCollection(
                                                    collection,
                                                    (builder, element) => builder.Index(data: element, index: "test", type: "type1")
                                                );

        It should_return_correct_value =
            () => result.ShouldEqual(("{ 'index': { '_index': 'test','_type': 'type1' } }\n" +
                                      "{'name': 'One', 'value': 1 }\n" +
                                      "{ 'index': { '_index': 'test','_type': 'type1' } }\n" +
                                      "{'name': 'Two', 'value': 2 }\n"
                                    ).AltQuote());


        private static string result;
        private static List<string> collection;
        private static BulkBuilder bulkBuilder;
    }
}
