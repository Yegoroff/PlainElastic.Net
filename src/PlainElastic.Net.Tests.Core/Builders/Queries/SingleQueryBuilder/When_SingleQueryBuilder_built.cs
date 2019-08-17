using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(SingleQueryBuilder<>))]
    class When_SingleQueryBuilder_built
    {
        Because of = () =>
            result = new SingleQueryBuilder<FieldsTestClass>()
                                                .MatchAll()
                                                .Build();


        It should_return_correct_result = () =>
                result.ShouldEqual(("{ 'match_all': {  } }").AltQuote());

        private static string result;
    }
}
