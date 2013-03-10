using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFilter<>))]
    public class When_GeoDistanceFilter_with_empty_geo_point_built
    {
        Because of = () => result = new GeoDistanceFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Distance("10km")
                                                .GeoPoint(null, 10)
                                                .Cache(true)
                                                .CacheKey("CacheKey")
                                                .Name("FilterName")
                                                .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
