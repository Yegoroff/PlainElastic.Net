using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using PlainElastic.Net.Utils;
using It = Machine.Specifications.It;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(StringExtensions))]
    class When_First_element_from_JoinInBatches_for_enumeration_of_string_requested
    {
        Because of = () =>
            Enumeration().JoinInBatches(batchSize: 2).First();


        It should_call_enumeration_batch_size_times = () =>
            enumeratorCallCount.ShouldEqual(2);


        private static int enumeratorCallCount;
        private static string[] data = new[] { "One", "Two", "Three", "Four", "Five" };

        private static  IEnumerable<string> Enumeration()
        {
            
            foreach (var value in data)
            {
                enumeratorCallCount++;
                yield return value;
            }
        }

    }
}
