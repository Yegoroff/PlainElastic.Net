using Machine.Specifications;
using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.IndexSettings
{
    [Subject(typeof(Analysis))]
    class When_complete_Analysis_built
    {
        Because of = () => result = new Analysis()
                                            .Analyzer(a => a.Custom("Analyzers"))
                                            .Custom("{ Custom }")
                                            .ToString();

        It should_contain_analyzer_part = () => result.ShouldContain("'analyzer': { Analyzers }".AltQuote());

        It should_contain_custom_part = () => result.ShouldContain("{ Custom }".AltQuote());
        
        It should_return_correct_result = () => result.ShouldEqual(("'analysis': { " +
                                                                    "'analyzer': { Analyzers }," +
                                                                    "{ Custom } }").AltQuote());

        private static string result;
    }
}