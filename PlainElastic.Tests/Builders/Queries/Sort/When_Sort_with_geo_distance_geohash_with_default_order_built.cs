using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    public class When_Sort_with_geo_distance_geohash_with_default_order_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                       .GeoDistance("field", "drm3btev3e86", DistanceUnit.miles)
                                       .ToString();

        It should_contain_correct_unit = () => result.ShouldContain("'unit': 'miles'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual("'sort': [{ '_geo_distance': { 'unit': 'miles','field.location': 'drm3btev3e86' } }]".AltQuote());

        private static string result;
    }
}