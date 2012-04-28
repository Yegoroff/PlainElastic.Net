using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticType_called_for_boolean_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticType(typeof(bool));


        It should_return_boolean_ES_type_name = () => result.ShouldEqual("boolean");

        private static string result;
    }
}
