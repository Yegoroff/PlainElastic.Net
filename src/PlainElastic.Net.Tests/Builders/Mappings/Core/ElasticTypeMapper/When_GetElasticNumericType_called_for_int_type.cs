using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticNumericType_called_for_int_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticNumericType(typeof(int));


        It should_return_integer_ES_type_name = () => result.ShouldEqual("integer");

        private static string result;
    }
}
