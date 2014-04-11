using Machine.Specifications;
using PlainElastic.Net.Mappings;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(GeoPointMap<>))]
    class When_complete_GeoPoint_mapping_built
    {
        Because of = () => result = new GeoPointMap<FieldsTestClass>()
                                                .Field(doc => doc.GeoPointProperty)
                                                .Boost(5)
                                                .IncludeInAll(true)
                                                .Index(IndexState.analyzed)
                                                .IndexName("index name")
                                                .NullValue("null value")
                                                .Store(true)
                                                .IndexLatLon(true)
                                                .IndexGeoHash(true)
                                                .GeoHashPrefix(true)
                                                .GeoHashPrecision(12)
                                                .Normalize(false)
                                                .NormalizeLat(false)
                                                .NormalizeLon(false)
                                                .Validate(true)
                                                .ValidateLat(true)
                                                .ValidateLon(true)
                                                .ToString();


        It should_start_from_specified_field_name = () => result.ShouldStartWith("'GeoPointProperty': {".AltQuote());

        It should_contain_date_type_declaration_part = () => result.ShouldContain("'type': 'geo_point'".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_include_in_all_part = () => result.ShouldContain("'include_in_all': true".AltQuote());

        It should_contain_index_part = () => result.ShouldContain("'index': 'analyzed'".AltQuote());

        It should_contain_index_name_part = () => result.ShouldContain("'index_name': 'index name'".AltQuote());

        It should_contain_null_value_part = () => result.ShouldContain("'null_value': 'null value'".AltQuote());

        It should_contain_store_part = () => result.ShouldContain("'store': true".AltQuote());


        It should_generate_correct_JSON_result = () =>
            result.ShouldEqual(("'GeoPointProperty': { " +
                                    "'type': 'geo_point'," +
                                    "'boost': 5," +
                                    "'include_in_all': true," +
                                    "'index': 'analyzed'," +
                                    "'index_name': 'index name'," +
                                    "'null_value': 'null value'," +
                                    "'store': true," +
                                    "'lat_lon': true," +
                                    "'geohash': true," +
                                    "'geohash_prefix': true," +
                                    "'geohash_precision': '12'," +
                                    "'normalize': false," +
                                    "'normalize_lat': false," +
                                    "'normalize_lon': false," +
                                    "'validate': true," +
                                    "'validate_lat': true," +
                                    "'validate_lon': true" +
                                " }").AltQuote());

        private static string result;
    }
}
