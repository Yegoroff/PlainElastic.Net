using System.Collections.Generic;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_index_aliases_command_result_deserialized
    {
        #region Index Aliases Command Json Result
        private static readonly string indexAliasesCommandJsonResult = @"{'index_name':{'aliases':{'alias_name':{}}}}".AltQuote();
        #endregion

        Establish context = () =>
            jsonSerializer = new JsonNetSerializer();


        Because of = () =>
            result = jsonSerializer.ToIndexAliasesResult(indexAliasesCommandJsonResult.AltQuote());

        private It should_contain_result_for_specified_index = () => result.ContainsKey("index_name");
        
        private It should_contain_aliases_for_specified_index = () => result["index_name"].Aliases.ContainsKey("alias_name");

        private static JsonNetSerializer jsonSerializer;
        private static IDictionary<string, IndexAliasesResult> result;
    }

}