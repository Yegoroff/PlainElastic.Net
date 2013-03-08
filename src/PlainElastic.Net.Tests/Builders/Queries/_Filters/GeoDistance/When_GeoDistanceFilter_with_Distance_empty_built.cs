using Machine.Specifications;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(GeoDistanceFilter<>))]
    public class When_GeoDistanceFilter_with_Distance_empty_built
    {
        Because of = () => result = new GeoDistanceFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Distance("")
                                                .ToString();

        It should_return_empty_string = () =>
            result.ShouldBeEmpty();

        private static string result;
    }
}
