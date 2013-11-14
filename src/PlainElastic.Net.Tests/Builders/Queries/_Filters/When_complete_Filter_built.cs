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
                                            .GeoBoundingBox(b => b.Custom("BoundingBox"))
                                            .Or(o => o.Custom("Or"))
                                            .Not(n => n.Custom("Not"))
                                            .Exists(e => e.Custom("Exists"))
                                            .Missing(m => m.Custom("Missing"))
                                            .Ids(ids => ids.Custom("Ids"))
                                            .Nested(n => n.Custom("Nested"))
                                            .HasChild<AnotherTestClass>(h => h.Custom("HasChild"))
                                            .HasParent<AnotherTestClass>(h => h.Custom("HasParent"))
                                            .Range(r => r.Custom("Range"))
                                            .NumericRange(n => n.Custom("NumericRange"))
                                            .Term(t => t.Custom("Term"))
                                            .Terms(t => t.Custom("Terms"))
                                            .Bool(b => b.Custom("Bool"))
                                            .Limit(l => l.Custom("Limit"))
                                            .Type(t => t.Custom("Type"))
                                            .Query(q => q.Custom("Query"))
                                            .Prefix(p => p.Custom("Prefix"))
                                            .Indices(i => i.Custom("Indices"))
                                            .Script(s => s.Custom("Script"))
                                            .GeoDistance(g => g.Custom("GeoDistance"))
                                            .MatchAll()
                                            .ToString();

        It should_starts_with_filter_declaration = () => result.ShouldStartWith("'filter': {".AltQuote());


        It should_return_correct_result = () => result.ShouldEqual(("'filter': " +
                                                                        "{ 'and': [ And ] }," +
                                                                        "{ 'geo_bounding_box': BoundingBox }," +
                                                                        "{ 'or': [ Or ] }," +
                                                                        "{ 'not': { Not } }," +
                                                                        "{ 'exists': { Exists } }," +
                                                                        "{ 'missing': { Missing } }," +
                                                                        "{ 'ids': { Ids } }," +
                                                                        "{ 'nested': { Nested } }," +
                                                                        "{ 'has_child': { HasChild } }," +
                                                                        "{ 'has_parent': { HasParent } }," +
                                                                        "{ 'range': { Range } }," +
                                                                        "{ 'numeric_range': { NumericRange } }," +
                                                                        "{ 'term': { Term } }," +
                                                                        "{ 'terms': { Terms } }," +
                                                                        "{ 'bool': { Bool } }," +
                                                                        "{ 'limit': { Limit } }," +
                                                                        "{ 'type': { Type } }," +
                                                                        "{ 'fquery': { 'query': Query } }," +
                                                                        "{ 'prefix': { Prefix } }," +
                                                                        "{ 'indices': { Indices } }," +
                                                                        "{ 'script': { Script } }," +
                                                                        "{ 'geo_distance': { GeoDistance } }," +
                                                                        "{ 'match_all': {} }").AltQuote());

        private static string result;
    }
}
