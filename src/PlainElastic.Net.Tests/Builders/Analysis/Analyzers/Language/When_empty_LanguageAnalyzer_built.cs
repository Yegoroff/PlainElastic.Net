﻿using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(LanguageAnalyzer))]
    class When_empty_LanguageAnalyzer_built
    {
        Because of = () => result = new LanguageAnalyzer()
                                            .Name("name")
                                            .Type(LanguageAnalyzerTypes.russian)
                                            .ToString();

        It should_return_correct_result = () => result.ShouldEqual("'name': { 'type': 'russian' }".AltQuote());

        private static string result;
    }
}