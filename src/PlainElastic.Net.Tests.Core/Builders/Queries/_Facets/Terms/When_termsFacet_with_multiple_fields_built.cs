using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof (FacetFilter<>))]
    class When_termsFacet_with_multiple_fields_built
    {
        Because of = () => {

            result = new QueryBuilder<FieldsTestClass>()
                .Facets(f => f
                    .Terms(t => t
                        .FacetName("brand")
                        .Fields("field1", "field2")
                    )
                ).Build();
        };


        It should_return_correct_JSON = () =>
            result.ShouldEqual(("{ " +
                                "'facets': { " +
                                    "'brand': { " +
                                        "'terms': { 'fields': ['field1','field2'] }" +
                                    " }" +
                                 " }" +
                               " }").AltQuote());

        private static string result;
    }
}
