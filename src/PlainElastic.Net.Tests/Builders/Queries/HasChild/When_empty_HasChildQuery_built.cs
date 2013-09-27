using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HasChildQuery<,>))]
    class When_empty_HasChildQuery_built
    {
        Because of = () => result = new HasChildQuery<FieldsTestClass, AnotherTestClass>()
                                                .Type("childType")
                                                .Query(q => q)
                                                .Scope("query_scope")
                                                .Boost(5)
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
