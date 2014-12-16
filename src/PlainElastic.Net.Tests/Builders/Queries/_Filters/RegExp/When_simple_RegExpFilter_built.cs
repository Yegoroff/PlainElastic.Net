using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(RegExpFilter<>))]
    class When_simple_RegExpFilter_built
    {
        Because of = () => result = new RegExpFilter<FieldsTestClass>()
                                                .Field(f => f.StringProperty)
                                                .Value(value: "s.y*")
                                                .ToString();


        It should_contain_field_name = () => result.ShouldContain("'StringProperty':".AltQuote());

        It should_return_correct_query = () => result.ShouldEqual(("{ 'regexp': { " +
                                                                        "'StringProperty': 's.y*'" +
                                                                     " }" +
                                                                  " }").AltQuote());

        private static string result;
    }
}
