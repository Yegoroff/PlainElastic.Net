using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(HasChildFilter<,>))]
    class When_empty_HasChildFilter_built
    {
        Because of = () => result = new HasChildFilter<FieldsTestClass, AnotherTestClass>()
                                                .Type("childType")
                                                .Query(q => q)
                                                .Scope("query_scope")
                                                .Name("filter_name")
                                                .Custom("")
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
