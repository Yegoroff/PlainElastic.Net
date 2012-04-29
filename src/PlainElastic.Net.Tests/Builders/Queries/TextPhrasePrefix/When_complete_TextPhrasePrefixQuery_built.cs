using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TextPhrasePrefixQuery<>))]
    class When_complete_TextPhrasePrefixQuery_built
    {
        Because of = () => result = new TextPhrasePrefixQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Query("One")
                                                .Boost(5)                                                
                                                .Operator(Operator.AND)
                                                .Analyzer(DefaultAnalyzers.standard)
                                                .Fuzziness(0.3)
                                                .PrefixLength(7)
                                                .MaxExpansions(10)
                                                .Slop(4)
                                                .ToString();

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_operator_part = () => result.ShouldContain("'operator': 'AND'".AltQuote());

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'standard'".AltQuote());

        It should_contain_fuzziness_part = () => result.ShouldContain("'fuzziness': 0.3".AltQuote());

        It should_contain_prefix_length_part = () => result.ShouldContain("'prefix_length': 7".AltQuote());

        It should_contain_max_expansions_part = () => result.ShouldContain("'max_expansions': 10".AltQuote());

        It should_contain_slop_part = () => result.ShouldContain("'slop': 4".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ 'text_phrase_prefix': { " +
                                                                        "'StringProperty': { " +
                                                                            "'query': 'One'," +
                                                                            "'boost': 5," +
                                                                            "'operator': 'AND'," +
                                                                            "'analyzer': 'standard'," +
                                                                            "'fuzziness': 0.3," +
                                                                            "'prefix_length': 7," +
                                                                            "'max_expansions': 10," +
                                                                            "'slop': 4 " +
                                                                        "} " +
                                                                     "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
