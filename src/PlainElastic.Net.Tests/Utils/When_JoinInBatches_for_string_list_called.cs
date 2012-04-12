using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_JoinInBatches_for_string_list_called
    {
        Establish context = () => {

            stringList = new List<string>
                             {
                                "One",
                                "Two",
                                "Three",
                                "Four",
                                "Five"
                             };

        };

        Because of = () =>
            result = stringList.JoinInBatches(batchSize: 2);

        It should_return_3_batches = () =>
            result.Count().ShouldEqual(3);

        It should_return_first_batch_equal_to_OneTwo = () =>
            result.First().ShouldEqual("OneTwo");

        It should_return_second_batch_equal_to_ThreeFour = () =>
            result.Skip(1).First().ShouldEqual("ThreeFour");

        It should_return_third_batch_equal_to_Five = () =>
            result.Skip(2).First().ShouldEqual("Five");

        
        private static List<string> stringList;
        private static IEnumerable<string> result;
    }
}
