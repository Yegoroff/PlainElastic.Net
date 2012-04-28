using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticNumericType_called_for_boolean_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticNumericType(typeof(bool));


        It should_return_byte_ES_type_name = () => result.ShouldEqual("byte");

        private static string result;
    }
}
