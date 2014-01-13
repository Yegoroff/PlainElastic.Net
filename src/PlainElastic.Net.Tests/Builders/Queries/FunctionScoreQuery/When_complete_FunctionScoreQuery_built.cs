using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FunctionScoreQuery<>))]
    class When_complete_FunctionScoreQuery_built
    {
        Because of = () => result = new FunctionScoreQuery<FieldsTestClass>()
                                                .Query(q => q.Custom("Query"))
                                                .Filter(f => f.Custom("Filter"))
                                                .Boost(2)
                                                .BoostMode(FunctionBoostMode.min)
                                                .MaxBoost(100)
                                                .ScoreMode(FunctionScoreMode.multiply)
                                                .Function(fn => fn
                                                    .RandomScore(rs => rs
                                                        .Seed(123)
                                                    )
                                                )
                                                .Functions(fns => fns
                                                    .Function(fn => fn
                                                        .Filter(f => f.Custom("Fn-Filter"))
                                                        .RandomScore(r => r
                                                            .Seed(321)
                                                        )
                                                    )
                                                    .Function(fn => fn
                                                        .Filter(f => f.Custom("Fn-Filter2"))
                                                        .BoostFactor(bf => bf
                                                            .BoostFactor(100)
                                                        )
                                                    )
                                                )
                                                .ToString();

        It should_contain_query_part = () => result.ShouldContain("'query': Query".AltQuote());

        It should_contain_filters_part = () => result.ShouldContain("'filter': Filter".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 2".AltQuote());

        It should_contain_boost_mode_part = () => result.ShouldContain("'boost_mode': 'min'".AltQuote());

        It should_contain_max_boost_part = () => result.ShouldContain("'max_boost': 100".AltQuote());

        It should_contain_score_mode_part = () => result.ShouldContain("'score_mode': 'multiply'".AltQuote());

        It should_contain_function_part = () => result.ShouldContain("'random_score': { 'seed': 123 }".AltQuote());

        It should_contain_functions_part = () => result.ShouldContain(("'functions': [ " +
                                                                            "{ " +
                                                                                "'filter': Fn-Filter," +
                                                                                "'random_score': { 'seed': 321 }" +
                                                                            " }," +
                                                                            "{ " +
                                                                                "'filter': Fn-Filter2," +
                                                                                "'boost_factor': 100" +
                                                                            " }" +
                                                                       " ]").AltQuote());



        It should_return_correct_result = () => result.ShouldEqual(("{ 'function_score': { " +
                                                                    "'query': Query," +
                                                                    "'filter': Filter," +
                                                                    "'boost': 2," +
                                                                    "'boost_mode': 'min'," +
                                                                    "'max_boost': 100," +
                                                                    "'score_mode': 'multiply'," +
                                                                    "'random_score': { 'seed': 123 }," +
                                                                    "'functions': [ " +
                                                                            "{ " +
                                                                                "'filter': Fn-Filter," +
                                                                                "'random_score': { 'seed': 321 }" +
                                                                            " }," +
                                                                            "{ " +
                                                                                "'filter': Fn-Filter2," +
                                                                                "'boost_factor': 100" +
                                                                            " }" +
                                                                       " ]" +
                                                                    " } }").AltQuote());

        private static string result;
    }
}


