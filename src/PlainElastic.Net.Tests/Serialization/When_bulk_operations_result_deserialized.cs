using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_bulk_operations_result_deserialized
    {
        #region Bulk Operatins Json Result
        private static readonly string bulkOperationJsonResult =
@"{
    'took': 100,
    'items': [
        {
            'index': {
                '_index': 'test',
                '_type': 'type1',
                '_id': '2',
                '_version': 1,
                'status': 201
            }
        },
        {
            'index': {
                '_index': 'test',
                '_type': 'type1',
                '_id': '3',
                '_version': 1,
                'status': 201
            }
        },
        {
            'create': {
                '_index': 'test',
                '_type': 'type1',
                '_id': '4',
                '_version': 1,
                'status': 201
            }
        },
        {
            'create': {
                '_index': 'test',
                '_type': 'type1',
                '_id': '4',
                'error': 'DocumentAlreadyExistsEngineException[[test][0] [type1][4]: document already exists]'
            }
        },
        {
            'delete': {
                '_index': 'test',
                '_type': 'type1',
                '_id': '1',
                '_version': 2,
                'status': 404,
                'found': false
            }

        }
    ]
}".AltQuote();
        #endregion

        Establish context = () =>
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToBulkResult(bulkOperationJsonResult);
            

        It should_contain_correct_took_number = () =>
            result.took.ShouldEqual(100);

        It should_contain_5_items = () =>
            result.items.Count.ShouldEqual(5);

        It should_contain_first_index_item = () =>
            result.items[0].ResultType.ShouldEqual(BulkOperationType.Index);

        It should_contain_first_index_item_with_id_2 = () =>
            result.items[0].Result._id.ShouldEqual("2");

        It should_contain_first_index_item_with_index_test = () =>
            result.items[0].Result._index.ShouldEqual("test");

        It should_contain_first_index_item_with_type_type1 = () =>
            result.items[0].Result._type.ShouldEqual("type1");

        It should_contain_first_index_item_with_version_1 = () =>
           result.items[0].Result._version.ShouldEqual(1);

        It should_contain_first_index_item_with_status_201 = () =>
           result.items[0].Result.status.ShouldEqual(201);


        It should_contain_second_index_item = () =>
            result.items[1].ResultType.ShouldEqual(BulkOperationType.Index);

        It should_contain_second_index_item_with_id_3 = () =>
            result.items[1].Result._id.ShouldEqual("3");

        It should_contain_third_create_item = () =>
            result.items[2].ResultType.ShouldEqual(BulkOperationType.Create);

        It should_contain_third_create_item_with_id_4 = () =>
            result.items[2].Result._id.ShouldEqual("4");

        It should_contain_fourth_create_item = () =>
            result.items[3].ResultType.ShouldEqual(BulkOperationType.Create);

        It should_contain_fourth_create_item_with_id_4 = () =>
            result.items[3].Result._id.ShouldEqual("4");

        It should_contain_fourth_create_item_with_correct_error = () =>
            result.items[3].Result.error.ShouldEqual("DocumentAlreadyExistsEngineException[[test][0] [type1][4]: document already exists]");

        It should_contain_fifth_delete_item = () =>
            result.items[4].ResultType.ShouldEqual(BulkOperationType.Delete);

        It should_contain_fifth_delete_item_with_id_1 = () =>
            result.items[4].Result._id.ShouldEqual("1");

        It should_contain_fifth_delete_item_with_version_2 = () =>
            result.items[4].Result._version.ShouldEqual(2);


        private static JsonNetSerializer jsonSerializer;
        private static BulkResult result;
    }

}