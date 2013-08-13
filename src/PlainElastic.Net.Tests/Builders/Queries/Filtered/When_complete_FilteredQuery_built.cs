using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FilteredQuery<>))]
    class When_complete_FilteredQuery_built
    {
        Because of = () => result = new FilteredQuery<FieldsTestClass>()
                                                .Query(q => q.Custom("{ query }"))
                                                .Filter(f => f.Custom("{ filter }"))
                                                .GeoBoundingBox(b => b.Custom("{ bounding_box }"))
                                                .Custom("{ custom part }")
                                                .ToString();

        It should_return_correct_result = () => result.ShouldEqual(@"{ 'filtered': { 'query': { query },'filter': { filter },'geo_bounding_box': { bounding_box },{ custom part } } }".AltQuote());

        private static string result;
    }
}
