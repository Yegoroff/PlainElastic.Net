using System.Collections.Generic;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_index_alias_command_result_deserialized
    {
        #region Count Command Json Result
        private static readonly string indexAliasCommandJsonResult = @"{'index_name':{'aliases':{'alias_name':{}}}}".AltQuote();
        #endregion

        Establish context = () =>
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToIndexAliasResult(indexAliasCommandJsonResult.AltQuote());

        private It should_contain_result_for_specified_index = () => result.ContainsKey("index_name");
        
        private It should_contain_aliases_for_specified_index = () => result["index_name"].Aliases.ContainsKey("alias_name");

        private static JsonNetSerializer jsonSerializer;
        private static IDictionary<string, IndexAliasResult> result;
    }

}