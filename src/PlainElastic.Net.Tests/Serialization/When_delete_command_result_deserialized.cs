using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_delete_command_result_deserialized
    {
        #region Delete Command Json Result
        private static readonly string deleteCommandJsonResult =
@"{
    'found': true,
    '_index': 'twitter',
    '_type': 'tweet',
    '_id': '1',
    '_version': 3
}".AltQuote();
        #endregion

        Establish context = () =>
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToDeleteResult(deleteCommandJsonResult.AltQuote());
            
        It should_contain_correct_index = () =>
            result._index.ShouldEqual("twitter");

        It should_contain_correct_type = () =>
            result._type.ShouldEqual("tweet");

        It should_contain_correct_id = () =>
            result._id.ShouldEqual("1");

        It should_contain_correct_version = () =>
            result._version.ShouldEqual(3);

        private static JsonNetSerializer jsonSerializer;
        private static DeleteResult result;
    }

}