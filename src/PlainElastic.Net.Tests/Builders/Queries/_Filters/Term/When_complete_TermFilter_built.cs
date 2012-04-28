using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(TermFilter<>))]
    class When_complete_TermFilter_built
    {
        Because of = () => result = new TermFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value("One")
                                                .Cache(true)
                                                .Name("termFilter")
                                                .ToString();


        It should_contain_field_and_value_part = () => result.ShouldContain("'StringProperty': 'One'".AltQuote());

        It should_contain_cache_part = () => result.ShouldContain("'_cache': true".AltQuote());
        
        It should_contain_name_part = () => result.ShouldContain("'_name': 'termFilter'".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual("{ 'term': { 'StringProperty': 'One','_cache': true,'_name': 'termFilter' } }".AltQuote());

        private static string result;
    }
}
