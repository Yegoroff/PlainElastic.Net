using System.Collections.Generic;
using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeFacet<>))]
    class When_complete_RangeFacet_built
    {
        Because of = () => result = new RangeFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .Ranges(new List<RangeToFrom>(){new RangeToFrom(){From = 1, To = 5}})
                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_starts_with_facet_name = () => result.ShouldStartWith("'TestFacet'".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_scope_part = () => result.ShouldContain("'scope': 'scope'".AltQuote());

        It should_contain_global_part = () => result.ShouldContain("'global': true".AltQuote());

        It should_contain_nested_part = () => result.ShouldContain("'nested': 'nested path'".AltQuote());

        It should_contain_facet_filter_part = () => result.ShouldContain("'facet_filter': { facet filter }".AltQuote());

        It should_return_correct_JSON = () => result.ShouldEqual( (
            "'TestFacet': { " +
                "'range': { " +
                    "'field': 'StringProperty'," +
                    "'ranges': [ {'from': 1, 'to': 5} ]" +
                " }," + 
                "'scope': 'scope'," +
                "'global': true," +
                "'nested': 'nested path'," +
                "'facet_filter': { facet filter }"+
            " }").AltQuote());

        private static string result;
    }
}
