using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermFilter<>))]
    class When_TermFilter_without_value_built
    {
        Because of = () => result = new TermFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Cache(true)
                                                .Name("filterName")                                                
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
