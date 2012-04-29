using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FilterFacet<>))]
    class When_empty_FilterFacet_built
    {
        Because of = () => result = new FilterFacet<FieldsTestClass>()
                                        .FacetName("TestFacet")
                                        .Filter(f => f.
                                            Term(t => t)
                                        )
                                        .Scope("scope")
                                        .Global(true)
                                        .Nested("nested path")
                                        .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                        .ToString();

        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
