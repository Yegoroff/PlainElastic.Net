using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Utils;
using It = Machine.Specifications.It;

namespace PlainElastic.Net.Tests.Utils
{
    [Subject(typeof(StringExtensions))]
    class When_First_element_from_JoinInBatches_for_enumeration_of_string_requested
    {
        Because of = () =>
           value = Enumeration().JoinInBatches(batchSize: 2).First();

        It should_return_string_with_two_first_elements = () =>
            value.ShouldEqual("OneTwo");

        It should_call_enumeration_batch_size_times = () =>
            enumeratorCallCount.ShouldEqual(2);



        private static int enumeratorCallCount;
        private static readonly string[] data = new[] { "One", "Two", "Three", "Four", "Five" };
        private static string value;

        private static  IEnumerable<string> Enumeration()
        {
            enumeratorCallCount = 0;
            foreach (var value in data)
            {
                enumeratorCallCount++;
                yield return value;
            }
        }

    }
}
