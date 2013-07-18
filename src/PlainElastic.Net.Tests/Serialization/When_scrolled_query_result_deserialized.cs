using System;
using Machine.Specifications;
using PlainElastic.Net.Serialization;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Serialization
{
    [Subject(typeof(JsonNetSerializer))]
    class When_scrolled_query_result_deserialized
    {
        #region Scrolled Query Json Result
        private static readonly string scrolleddQueryJsonResult =
@"{
    '_scroll_id': 'c2NhbjsxMDsyNjgwNjpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzI2ODA4OmJjTUJRWTBnU25LZDM3SmFtVWVFc3c7MjY4MDQ6YmNNQlFZMGdTbktkMzdKYW1VZUVzdzsyNjgwMjpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzI2ODA1OmJjTUJRWTBnU25LZDM3SmFtVWVFc3c7MjY4MDc6YmNNQlFZMGdTbktkMzdKYW1VZUVzdzsyNjgwMzpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzI2ODAxOmJjTUJRWTBnU25LZDM3SmFtVWVFc3c7MjY4MDk6YmNNQlFZMGdTbktkMzdKYW1VZUVzdzsyNjgxMDpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzE7dG90YWxfaGl0czoxMDg4OTgwOw==',
    'took': 5,
    'timed_out': false,
    '_shards': {
        'total': 10,
        'successful': 10,
        'failed': 0
    },
    'hits': {
        'total': 1080,
        'max_score': 0.0,
        'hits': [
            
        ]
    }
}".AltQuote();
        #endregion

        Establish context = () => 
            {
                jsonSerializer = new JsonNetSerializer();            
            };


        Because of = () => result = jsonSerializer.ToSearchResult<object>(scrolleddQueryJsonResult);
            

        It should_contain_correct_hits_count = () => 
                                                    result.hits.total.ShouldEqual(1080);

        It should_contain_correct_scroll_id = () =>
                                                 result._scroll_id.ShouldEqual("c2NhbjsxMDsyNjgwNjpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzI2ODA4OmJjTUJRWTBnU25LZDM3SmFtVWVFc3c7MjY4MDQ6YmNNQlFZMGdTbktkMzdKYW1VZUVzdzsyNjgwMjpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzI2ODA1OmJjTUJRWTBnU25LZDM3SmFtVWVFc3c7MjY4MDc6YmNNQlFZMGdTbktkMzdKYW1VZUVzdzsyNjgwMzpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzI2ODAxOmJjTUJRWTBnU25LZDM3SmFtVWVFc3c7MjY4MDk6YmNNQlFZMGdTbktkMzdKYW1VZUVzdzsyNjgxMDpiY01CUVkwZ1NuS2QzN0phbVVlRXN3OzE7dG90YWxfaGl0czoxMDg4OTgwOw==");


        private static JsonNetSerializer jsonSerializer;
        private static SearchResult<object> result;
    }
}