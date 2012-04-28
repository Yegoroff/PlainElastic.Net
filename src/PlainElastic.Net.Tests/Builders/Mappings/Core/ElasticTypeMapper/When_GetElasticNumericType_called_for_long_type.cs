using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticNumericType_called_for_long_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticNumericType(typeof(long));


        It should_return_long_ES_type_name = () => result.ShouldEqual("long");

        private static string result;
    }
}
