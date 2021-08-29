using Machine.Specifications;
using PlainElastic.Net.Queries;


namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(CustomBoostFactorQuery<>))]
    class When_empty_CustomBoostFactorQuery_built
    {
        Because of = () => result = new CustomBoostFactorQuery<FieldsTestClass>()
                                                .Query(q => q)
                                                .BoostFactor(5.2)
                                                .ToString();

        It should_return_empty_string = () => 
            result.ShouldBeEmpty();

        private static string result;
    }
}
