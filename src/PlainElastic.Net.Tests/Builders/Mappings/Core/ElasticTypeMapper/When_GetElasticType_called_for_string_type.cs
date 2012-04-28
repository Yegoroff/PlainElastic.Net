using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticType_called_for_string_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticType(typeof(string));


        It should_return_string_ES_type_name = () => result.ShouldEqual("string");

        private static string result;
    }
}
