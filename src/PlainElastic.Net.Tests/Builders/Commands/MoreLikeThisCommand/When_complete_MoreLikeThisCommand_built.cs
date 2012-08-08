using Machine.Specifications;

namespace PlainElastic.Net.Tests.Builders.Commands
{
    [Subject(typeof(MoreLikeThisCommand))]
    class When_complete_MoreLikeThisCommand_built
    {

        Because of = () => result = new MoreLikeThisCommand(index:"Index", type:"Type", id: "Id")
            .MltFields("field1,field2")
            .Boost(2)
            .BoostTerms(3)
            .MaxDocFreq(2)
            .MaxQueryTerms(2)
            .MaxWordLen(1)
            .MinDocFreq(1)
            .MinTermFreq(3)
            .MinWordLen(2)
            .PercentTermsToMatch(0.5)
            .StopWords("stop", "hammer", "time")
            .Pretty()
            
            .BuildCommand();


        It should_starts_with_index_type_and_id = () => result.ShouldStartWith("index/type/id/_mlt");

        It should_contain_parameter_fields_with_field1_and_field2 = () => result.ShouldContain("mlt_fields=field1,field2");

        It should_contain_boost = () => result.ShouldContain("boost=2");

        It should_contain_boost_terms = () => result.ShouldContain("boost_terms=3");

        It should_contain_max_doc_freq = () => result.ShouldContain("max_doc_freq=2");

        It should_contain_max_query_terms = () => result.ShouldContain("max_query_terms=2");
        
        It should_contain_max_word_len = () => result.ShouldContain("max_word_len=1");

        It should_contain_min_doc_freq = () => result.ShouldContain("min_doc_freq=1");

        It should_contain_min_term_freq = () => result.ShouldContain("min_term_freq=3");

        It should_contain_min_word_len = () => result.ShouldContain("min_word_len=2");

        It should_contain_percent_terms_to_match = () => result.ShouldContain("percent_terms_to_match=0.5");

        It should_contain_stop_words = () => result.ShouldContain("stop_words=stop,hammer,time");


        It should_return_correct_value = () => result.ShouldEqual(@"index/type/id/_mlt?mlt_fields=field1,field2&boost=2&boost_terms=3&max_doc_freq=2&max_query_terms=2&max_word_len=1&min_doc_freq=1&min_term_freq=3&min_word_len=2&percent_terms_to_match=0.5&stop_words=stop,hammer,time&pretty=true");


        private static string result;
    }
}
