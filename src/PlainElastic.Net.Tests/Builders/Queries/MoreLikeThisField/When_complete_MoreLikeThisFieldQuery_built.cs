using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MoreLikeThisFieldQuery<>))]
    class When_complete_MoreLikeThisFieldQuery_built
    {
        Because of = () => result = new MoreLikeThisFieldQuery<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .LikeText("like text")
                                                .PercentTermsToMatch(0.5)
                                                .MinTermFreq(5)
                                                .MaxQueryTerms(15)
                                                .StopWords("One", "Two", "Three")
                                                .MinDocFreq(10)
                                                .MaxDocFreq(18)
                                                .MinWordLen(2)
                                                .MaxWordLen(7)
                                                .BoostTerms(3)
                                                .Boost(5)
                                                .Analyzer(DefaultAnalyzers.snowball)
                                                .Custom("custom part")
                                                .ToString();

        It should_starts_with_more_like_this_field_declaration = () => result.ShouldStartWith("{ 'more_like_this_field': {".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'StringProperty': {".AltQuote());

        It should_contain_like_text_part = () => result.ShouldContain("'like_text': 'like text'".AltQuote());

        It should_contain_percent_terms_to_match_part = () => result.ShouldContain("'percent_terms_to_match': 0.5".AltQuote());

        It should_contain_min_term_freq_part = () => result.ShouldContain("'min_term_freq': 5".AltQuote());
        
        It should_contain_max_query_terms_part = () => result.ShouldContain("'max_query_terms': 15".AltQuote());

        It should_contain_stop_words_part = () => result.ShouldContain("'stop_words': [ 'One','Two','Three' ]".AltQuote());

        It should_contain_min_doc_freq_part = () => result.ShouldContain("'min_doc_freq': 10".AltQuote());

        It should_contain_max_doc_freq_part = () => result.ShouldContain("'max_doc_freq': 18".AltQuote());

        It should_contain_min_word_len_part = () => result.ShouldContain("'min_word_len': 2".AltQuote());

        It should_contain_max_word_len_part = () => result.ShouldContain("'max_word_len': 7".AltQuote());

        It should_contain_boost_terms_part = () => result.ShouldContain("'boost_terms': 3".AltQuote());

        It should_contain_boost_part = () => result.ShouldContain("'boost': 5".AltQuote());

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': 'snowball'".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("custom part".AltQuote());


        It should_return_correct_query = () => result.ShouldEqual(("{ " +
                                                                      "'more_like_this_field': { " +
                                                                          "'StringProperty': { " +
                                                                              "'like_text': 'like text'," +
                                                                              "'percent_terms_to_match': 0.5," +
                                                                              "'min_term_freq': 5," +
                                                                              "'max_query_terms': 15," +
                                                                              "'stop_words': [ 'One','Two','Three' ]," +
                                                                              "'min_doc_freq': 10," +
                                                                              "'max_doc_freq': 18," +
                                                                              "'min_word_len': 2," +
                                                                              "'max_word_len': 7," +
                                                                              "'boost_terms': 3," +
                                                                              "'boost': 5," +
                                                                              "'analyzer': 'snowball'," +
                                                                              "custom part " +
                                                                          "} " +
                                                                      "} " +
                                                                  "}").AltQuote());

        private static string result;
    }
}
