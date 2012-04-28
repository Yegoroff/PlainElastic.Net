using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticNumericType_called_for_short_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticNumericType(typeof(short));


        It should_return_short_ES_type_name = () => result.ShouldEqual("short");

        private static string result;
    }
}
