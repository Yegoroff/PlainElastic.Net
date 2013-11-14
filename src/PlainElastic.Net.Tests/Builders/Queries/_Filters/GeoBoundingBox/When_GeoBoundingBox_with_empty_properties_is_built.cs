using Machine.Specifications;

using PlainElastic.Net.Builders.Queries.Filters;

namespace PlainElastic.Net.Tests.Builders.Queries._Filters.GeoBoundingBox
{
    [Subject(typeof(GeoBoundingBoxFilter<>))]
    public class When_GeoBoundingBox_with_empty_properties_is_built
    {
        Because of = () => _result = new GeoBoundingBoxFilter<FieldsTestClass>().ToString();

        It should_return_correct_query = () => _result.ShouldBeEmpty();

        private static string _result;
    }
}