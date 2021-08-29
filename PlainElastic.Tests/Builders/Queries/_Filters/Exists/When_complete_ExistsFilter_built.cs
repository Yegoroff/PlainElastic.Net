using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(ExistsFilter<>))]
    class When_complete_ExistsFilter_built
    {
        Because of = () => result = new ExistsFilter<FieldsTestClass>()                                                
                                                .Field(f => f.StringProperty)
                                                .ShouldExists(true)
                                                .Name("ExistsFilter")
                                                .ToString();

        It should_starts_with_exists_declaration = () => result.ShouldStartWith("{ 'exists': {".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_name_part = () => result.ShouldContain("'_name': 'ExistsFilter'".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual("{ 'exists': { 'field': 'StringProperty','_name': 'ExistsFilter' } }".AltQuote());

        private static string result;
    }
}
