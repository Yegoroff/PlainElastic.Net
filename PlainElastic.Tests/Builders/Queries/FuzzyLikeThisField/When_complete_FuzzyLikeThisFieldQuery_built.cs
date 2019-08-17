using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(FuzzyLikeThisFieldQuery<>))]
    class When_complete_FuzzyLikeThisFieldQuery_built
    {
        Because of = () => result = new FuzzyLikeThisFieldQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .LikeText("like text")
                                                .IgnoreTf(true)
                                                .MaxQueryTerms(10)
                                                .MinSimilarity(0.8)
                                                .PrefixLength(3)
                                                .Boost(5)
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .Custom("custom part")
                                                .ToString();

        It should_starts_with_fuzzy_like_this_field_declaration = () => result.ShouldStartWith("{ 'fuzzy_like_this_field': {".AltQuote());

        It should_contain_fields_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_like_text_part = () => result.ShouldContain("'like_text': 'like text'".AltQuote());

        It should_contain_ignore_tf_part = () => result.ShouldContain("'ignore_tf': true".AltQuote());

        It should_contain_max_query_terms_part = () => result.ShouldContain("'max_query_terms': 10".AltQuote());

        It should_contain_min_similarity_part = () => result.ShouldContain("'min_similarity': 0.8".AltQuote());

        It should_contain_prefix_length_part = () => result.ShouldContain("'prefix_length': 3".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'snowball'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom part".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                                      "'fuzzy_like_this_field': { " +
                                                                          "'StringProperty': { " +
                                                                              "'like_text': 'like text'," +
                                                                              "'ignore_tf': true," +
                                                                              "'max_query_terms': 10," +
                                                                              "'min_similarity': 0.8," +
                                                                              "'prefix_length': 3," +
                                                                              "'boost': 5," +
                                                                              "'analyzer': 'snowball'," +
                                                                              "custom part " +
                                                                          "} " +
                                                                      "} " +
                                                                  "}").AltQuote());

        private static string result;
    }
}
