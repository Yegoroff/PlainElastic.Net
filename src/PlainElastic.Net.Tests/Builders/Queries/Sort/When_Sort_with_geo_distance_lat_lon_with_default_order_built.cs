using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Sort<>))]
    public class When_Sort_with_geo_distance_lat_lon_with_default_order_built
    {
        Because of = () => result = new Sort<FieldsTestClass>()
                                       .GeoDistance("field", 40, -70, DistanceUnit.miles)
                                       .ToString();

        It should_contain_correct_unit = () => result.ShouldContain("'unit': 'miles'".AltQuote());

        It should_return_correct_value = () => result.ShouldEqual("'sort': [{ '_geo_distance': { 'unit': 'miles','field': { 'lat': 40,'lon': -70 } } }]".AltQuote());

        private static string result;
    }
}