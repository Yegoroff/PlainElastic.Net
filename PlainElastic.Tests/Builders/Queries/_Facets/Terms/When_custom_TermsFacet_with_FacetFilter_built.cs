using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof (FacetFilter<>))]
    class When_custom_TermsFacet_with_FacetFilter_built
    {
        Because of = () => {

            result = new QueryBuilder<FieldsTestClass>()
                .Facets(f => f
                    .Terms(t => t
                        .FacetName("brand")
                        .Field("brand")
                        .FacetFilter(filter => filter
                            .Range(r => r
                                .Field("price")
                                .IncludeLower(false)
                                .IncludeUpper(true)
                                .From("Lower")
                                .To("Upper"))
                        )
                    )
                ).Build();
        };


        It should_return_correct_JSON = () =>
            result.ShouldEqual(("{ " +
                                "'facets': { " +
                                    "'brand': { " +
                                        "'terms': { 'field': 'brand' }," +
                                        "'facet_filter': { " +
                                            "'range': { " +
                                                "'price': { " +
                                                    "'include_lower': false," +
                                                    "'include_upper': true," +
                                                    "'from': 'Lower'," +
                                                    "'to': 'Upper' " +
                                                "} "+
                                            "} " +
                                        "} " +
                                    "} " +
                                 "} " +
                               "}").AltQuote());

        private static string result;
    }
}
