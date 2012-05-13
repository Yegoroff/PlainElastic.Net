using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(CountCommand))]
    class When_CountCommand_with_multiple_indexes_and_types_built
    {

        Because of = () => result = new CountCommand(indexes: new[] { "index1", "index2" }, types: new[] { "Type1", "Type2" })
            .Pretty()
            .BuildCommand();

        It should_starts_with_indexes_and_types = () => result.ShouldStartWith("index1,index2/type1,type2");

        It should_return_correct_value = () => result.ShouldEqual(@"index1,index2/type1,type2/_count?pretty=true");


        private static string result;
    }
}
