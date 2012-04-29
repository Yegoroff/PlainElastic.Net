using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Filter<>))]
    class When_complete_Filter_built
    {
        Because of = () => result = new Filter<FieldsTestClass>()                                                
                                            .And(a => a.Custom("And"))
                                            .Or(o => o.Custom("Or"))
                                            .Not( n => n.Custom("Not") )
                                            .Exists(e => e.Custom("Exists"))
                                            .Missing(m => m.Custom("Missing"))
                                            .Nested(n => n.Custom("Nested"))
                                            .Range(r => r.Custom("Range"))
                                            .Term(t => t.Custom("Term"))
                                            .Terms(t => t.Custom("Terms"))
                                            .Bool(b => b.Custom("Bool"))
                                            .Limit(l => l.Custom("Limit"))
                                            .Type(t => t.Custom("Type"))
                                            .Query(q => q.Custom("Query"))
                                            .MatchAll()
                                            .ToString();

        It should_starts_with_filter_declaration = () => result.ShouldStartWith("'filter': {".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual(("'filter': " +
                                                                        "{ 'and': [ And ] }," +
                                                                        "{ 'or': [ Or ] }," +
                                                                        "{ 'not': { Not } }," +
                                                                        "{ 'exists': { Exists } }," +
                                                                        "{ 'missing': { Missing } }," +
                                                                        "{ 'nested': { Nested } }," +
                                                                        "{ 'range': { Range } }," +
                                                                        "{ 'term': { Term } }," +
                                                                        "{ 'terms': { Terms } }," +
                                                                        "{ 'bool': { Bool } }," +
                                                                        "{ 'limit': { Limit } }," +
                                                                        "{ 'type': { Type } }," +
                                                                        "{ 'fquery': { 'query': Query } }," +
                                                                        "{ 'match_all': {} }").AltQuote());

        private static string result;
    }
}
