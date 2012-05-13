using System;
using Machine.Specifications;
using PlainElastic.Net.Mappings;

namespace PlainElastic.Net.Tests.Builders.Mappings
{
    [Subject(typeof(ElasticCoreTypeMapper))]
    class When_GetElasticType_called_for_datetime_type
    {
        Because of = () =>
            result = ElasticCoreTypeMapper.GetElasticType(typeof(DateTime));


        It should_return_date_ES_type_name = () => result.ShouldEqual("date");

        private static string result;
    }
}
