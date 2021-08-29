using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FuzzyQuery<>))]
    class When_complete_FuzzyQuery_built
    {
        Because of = () => result = new FuzzyQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value("One")
                                                .Boost(5)
                                                .MaxExpansions(10)
                                                .PrefixLength(7)
                                                .MinSimilarity(0.5)
                                                .ToString();

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_max_expansions_part = () => result.ShouldContain("'max_expansions': 10".AltQuote());

        It should_contain_prefix_length_part = () => result.ShouldContain("'prefix_length': 7".AltQuote());

        It should_contain_min_similarity_part = () => result.ShouldContain("'min_similarity': 0.5".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ 'fuzzy': { " +
                                                                        "'StringProperty': { " +
                                                                            "'value': 'One'," +
                                                                            "'boost': 5," +
                                                                            "'max_expansions': 10," +
                                                                            "'prefix_length': 7," +
                                                                            "'min_similarity': 0.5 " +
                                                                        "} " +
                                                                     "} " +
                                                                   "}").AltQuote());

        private static string result;
    }
}
