using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    public class When_Sort_with_geo_distance_lat_lon_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                       .GeoDistance("field", 40, -70, DistanceUnit.miles, SortDirection.asc)
                                       .ToString();

        It should_contain_correct_order = () => result.ShouldContain(@"'order': 'asc'".AltQuote());

        It should_contain_correct_unit = () => result.ShouldContain("'unit': 'miles'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual("'sort': [{ '_geo_distance': { 'unit': 'miles','order': 'asc','field': { 'lat': 40,'lon': -70 } } }]".AltQuote());

        private static string result;
    }
}