using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HasParentQuery<,>))]
    class When_empty_HasParentQuery_built
    {
        Because of = () => result = new HasParentQuery<FieldsTestClass, AnotherTestClass>()
                                                .ParentType("parentType")
                                                .Query(q => q)
                                                .ScoreType(HasParentScoreType.score)
                                                .Boost(5)
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
