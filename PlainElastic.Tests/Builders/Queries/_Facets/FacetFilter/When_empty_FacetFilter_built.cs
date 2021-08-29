using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FacetFilter<>))]
    class When_empty_FacetFilter_built
    {
        Because of = () => result = new FacetFilter<FieldsTestClass>()
                                                .Term(t => t
                                                    .Field("field")
                                                    .Value("")
                                                 )
                                                .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
