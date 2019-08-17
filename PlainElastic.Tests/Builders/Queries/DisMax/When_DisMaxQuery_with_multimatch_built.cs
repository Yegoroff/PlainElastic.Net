using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Tests.Builders.Queries
{

    [Subject(typeof(DisMaxQuery<>))]
    class When_DisMaxQuery_with_multimatch_built
    {
        Because of = () => result = new DisMaxQuery<FieldsTestClass>()
                                                .Queries(q => q
                                                    .MultiMatch(m=>m
                                                        .Field("field")
                                                        .Query("text")
                                                    )
                                                )
                                                .Boost(10)
                                                .TieBreaker(0.5)
                                                .ToString();

        It should_return_correct_result = () =>
            result.ShouldEqual( ("{ 'dis_max': { " +
                                    "'queries': [ " +
                                        "{ " +
                                            "'multi_match': { " +
                                                "'fields': [ 'field' ]," +
                                                "'query': 'text'" +
                                            " }" +
                                        " }" +
                                    " ]," +
                                    "'boost': 10," +
                                    "'tie_breaker': 0.5" +
                                " }" +
                              " }").AltQuote() );


        private static string result;
    }
}
