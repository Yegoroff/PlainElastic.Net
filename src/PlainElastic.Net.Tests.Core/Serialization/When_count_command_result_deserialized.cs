using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_count_command_result_deserialized
    {
        #region Count Command Json Result
        private static readonly string countCommandJsonResult =
@"{
    'count': 100,
    '_shards': {
        'total': 5,
        'successful': 3,
        'failed': 2
    }
}".AltQuote();
        #endregion

        Establish context = () =>
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToCountResult(countCommandJsonResult.AltQuote());
            

        It should_contain_correct_count_number = () =>
            result.count.ShouldEqual(100);

        It should_contain_correct_shards_total = () =>
            result._shards.total.ShouldEqual(5);

        It should_contain_correct_shards_sucessfull= () =>
            result._shards.successful.ShouldEqual(3);

        It should_contain_correct_shards_filed = () =>
            result._shards.failed.ShouldEqual(2);


        private static JsonNetSerializer jsonSerializer;
        private static CountResult result;
    }

}