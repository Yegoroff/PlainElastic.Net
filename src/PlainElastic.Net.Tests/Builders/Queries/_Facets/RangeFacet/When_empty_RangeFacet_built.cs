using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RangeFacet<>))]
    class When_empty_RangeFacet_built
    {
        Because of = () => result = new RangeFacet<FieldsTestClass>()
                                                .FacetName("TestFacet")
                                                .Field(f => f.StringProperty)
                                                .KeyField(f => f.IntProperty)
                                                .ValueField(f => f.EnumProperty)
                                                .KeyScript("Key 'Script'")
                                                .ValueScript("Value 'Script'")
                                                .Ranges(r => r.FromTo())
                                                .Scope("scope")
                                                .Global(true)
                                                .Nested("nested path")
                                                .FacetFilter(filter => filter.Custom("{ facet filter }"))
                                                .ToString();


        It should_return_empty_string = () => result.ShouldBeEmpty();

        private static string result;
    }
}
