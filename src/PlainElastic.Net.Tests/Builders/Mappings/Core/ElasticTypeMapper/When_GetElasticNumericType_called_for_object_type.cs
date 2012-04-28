using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticNumericType_called_for_object_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticNumericType(typeof(object));


        It should_return_null = () => result.ShouldBeNull();

        private static string result;
    }
}
