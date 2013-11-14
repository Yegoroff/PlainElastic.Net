using Machine.Specifications;
using PlainElastic.Net.Builders.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries._PartialFields
{
    [Subject(typeof(PartialFields<>))]
    public class When_complete_PartialFields_built
    {
        Because of = () => result = new PartialFields<FieldsTestClass>()
                                        .Partial( p => p
                                            .PartialName("MyView")
                                            .IncludeFields(new [] {"*"})
                                            .ExcludeFields(f=> f.StringProperty,f=>f.BoolProperty)
                                            )
                                      .ToString();

        It should_return_correct_JSON = () => result.ShouldEqual("'partial_fields': { 'MyView': { 'include': [ '*' ],'exclude': [ 'StringProperty','BoolProperty' ] } }".AltQuote());

        private static string result;
    }
}