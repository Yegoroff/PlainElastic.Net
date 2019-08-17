using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(FlushCommand))]
    class When_FlushCommand_with_multiple_indexes_built
    {

        Because of = () => result = new FlushCommand(indexes: new[] { "Index1", "Index2" }, types: new[] { "Type1", "Type2" })
            .BuildCommand();


        It should_starts_with_indexes_and_types = () => result.ShouldStartWith("index1,index2/type1,type2");

        It should_contains_flush_verb = () => result.ShouldContain("_flush");

        It should_return_correct_value = () => result.ShouldEqual(@"index1,index2/type1,type2/_flush");


        private static string result;
    }
}
