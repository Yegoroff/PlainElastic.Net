using Machine.Specifications;

using PlainElastic.Net.Builders.Queries.Filters;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries._Filters.GeoBoundingBox
{
    [Subject(typeof(GeoBoundingBoxFilter<>))]
    public class When_complete_GeoBoundingBox_Is_Built
    {
        Because of = () => _result = new GeoBoundingBoxFilter<FieldsTestClass>()
                                            .Field(f => f.StringProperty)
                                            .TopLeft(1.01, 2.02)
                                            .BottomRight(3.03, 4.04)
                                            .ToString();

        It should_query_the_correct_field = () => _result.ShouldContain("'StringProperty': {".AltQuote());

        It should_set_the_top_left_point = () => _result.ShouldContain("'top_left': { 'lat': 1.01,'lon': 2.02 }".AltQuote());

        It should_set_the_bottom_right_point = () => _result.ShouldContain("'bottom_right': { 'lat': 3.03,'lon': 4.04 }".AltQuote());

        It should_return_correct_query = () => _result.ShouldEqual("{ 'geo_bounding_box': { 'StringProperty': { 'top_left': { 'lat': 1.01,'lon': 2.02 },'bottom_right': { 'lat': 3.03,'lon': 4.04 } } } }".AltQuote());

        private static string _result;
    }
}