﻿using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(CustomFiltersScoreQuery<>))]
    class When_complete_CustomFiltersScoreQuery_built
    {
        Because of = () => result = new CustomFiltersScoreQuery<FieldsTestClass>()
                                                .Query(q => q.Custom("Query"))
                                                .Filters(fs => fs
                                                    .Filter(f => f
                                                        .Boost(2)
                                                        .Script("script")
                                                        .Custom("Filter")))
                                                .ScoreMode(CustomFiltersScoreMode.total)
                                                .Lang("script lang")
                                                .Params("script params")
                                                .ToString();

        It should_contain_query_part = () => result.ShouldContain("'query': Query".AltQuote());

        It should_contain_filters_part = () => result.ShouldContain("'filters': [ { 'filter': Filter,'boost': 2,'script': 'script' } ]".AltQuote());

        It should_contain_score_mode_part = () => result.ShouldContain("'score_mode': 'total'".AltQuote());

        It should_contain_lang_part = () => result.ShouldContain("'lang': 'script lang'".AltQuote());

        It should_contain_params_part = () => result.ShouldContain("'params': script params".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("{ 'custom_filters_score': { " +
                                                                    "'query': Query," +
                                                                    "'filters': [ { 'filter': Filter,'boost': 2,'script': 'script' } ]," +
                                                                    "'score_mode': 'total'," +
                                                                    "'lang': 'script lang'," +
                                                                    "'params': script params } }").AltQuote());

        private static string result;
    }
}
