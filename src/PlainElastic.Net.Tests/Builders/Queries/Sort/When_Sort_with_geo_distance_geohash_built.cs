using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    public class When_Sort_with_geo_distance_geohash_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                       .GeoDistance("field", "drm3btev3e86", DistanceUnit.miles, SortDirection.asc)
                                       .ToString();

        It should_contain_correct_order = () => result.ShouldContain(@"'order': 'asc'".AltQuote());

        It should_contain_correct_unit = () => result.ShouldContain("'unit': 'miles'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual("'sort': [{ '_geo_distance': { 'unit': 'miles','order': 'asc','field.location': 'drm3btev3e86' } }]".AltQuote());

        private static string result;
    }
}