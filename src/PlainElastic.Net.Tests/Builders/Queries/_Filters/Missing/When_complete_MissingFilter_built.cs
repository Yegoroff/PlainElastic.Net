using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(MissingFilter<>))]
    class When_complete_MissingFilter_built
    {
        Because of = () => result = new MissingFilter<FieldsTestClass>()                                                
                                                .Field(f => f.StringProperty)
                                                .ShouldMiss(true)
                                                .Name("MissFilter")
                                                .ToString();

        It should_starts_with_missing_declaration = () => result.ShouldStartWith("{ 'missing': {".AltQuote());

        It should_contain_field_part = () => result.ShouldContain("'field': 'StringProperty'".AltQuote());

        It should_contain_name_part = () => result.ShouldContain("'_name': 'MissFilter'".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual("{ 'missing': { 'field': 'StringProperty','_name': 'MissFilter' } }".AltQuote());

        private static string result;
    }
}
