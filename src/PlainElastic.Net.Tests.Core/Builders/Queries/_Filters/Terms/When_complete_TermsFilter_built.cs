using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermsFilter<>))]
    class When_complete_TermsFilter_built
    {
        Because of = () => result = new TermsFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Values(new[] { "One", "Two" })
                                                .Execution(TermsFilterExecution.plain)
                                                .Cache(true)
                                                .Name("termsFilter")
                                                .ToString();


        It should_contain_field_part = () => result.ShouldContain(@"'StringProperty': [ 'One','Two' ]".AltQuote());

        It should_contain_execution_part = () => result.ShouldContain(@"'execution': 'plain'".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain(@"'_cache': true".AltQuote());

        It should_contain_name_part = () => result.ShouldContain(@"'_name': 'termsFilter'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(@"{ 'terms': { 'StringProperty': [ 'One','Two' ],'execution': 'plain','_cache': true,'_name': 'termsFilter' } }".AltQuote());

        private static string result;
    }
}
