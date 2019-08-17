using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(DecayFunction<>))]
    class When_complete_DecayFunction_built
    {
        Because of = () => result = new DecayFunction<FieldsTestClass>()
                                                .Type(DecayFunctionType.gauss)
                                                .Field( f=> f.DateProperty)
                                                .Origin("2013-09-17")
                                                .Scale("10d")
                                                .Offset("5d")
                                                .Decay(0.5)
                                                .ToString();

        It should_contain_origin_part = () => result.ShouldContain("'origin': '2013-09-17'".AltQuote());

        It should_contain_scale_part = () => result.ShouldContain("'scale': '10d'".AltQuote());

        It should_contain_offset_part = () => result.ShouldContain("'offset': '5d'".AltQuote());

        It should_contain_decay_part = () => result.ShouldContain("'decay': 0.5".AltQuote());

        It should_return_correct_result = () => result.ShouldEqual(("'gauss': { " +
                                                                        "'DateProperty': { " +
                                                                            "'origin': '2013-09-17'," +
                                                                            "'scale': '10d'," +
                                                                            "'offset': '5d'," +
                                                                            "'decay': 0.5" +
                                                                        " }" +
                                                                    " }").AltQuote());

        private static string result;
    }
}
