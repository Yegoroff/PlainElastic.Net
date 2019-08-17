using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Builders.Queries
{
    [Subject(typeof(Query<>))]
    class When_complete_Query_built
    {
        Because of = () => result = new Query<FieldsTestClass>()
                                                .Text(t => t.Custom("text query"))
                                                .TextPhrase(t => t.Custom("text phrase query"))
                                                .TextPhrasePrefix(t => t.Custom("text phrase prefix query"))
                                                .Match(m => m.Custom("match query"))
                                                .MultiMatch(m=> m.Custom("multi match query"))
                                                .Bool(b => b.Custom("bool query"))
                                                .Boosting(b => b.Custom("boosting query"))
                                                .Ids(ids => ids.Custom("ids query"))
                                                .DisMax(d => d.Custom("dismax query"))
                                                .Field(f => f.Custom("field query"))
                                                .Nested(n => n.Custom("nested query"))
                                                .QueryString(q => q.Custom("query string"))
                                                .Prefix(p => p.Custom("prefix query"))
                                                .Range(r => r.Custom("range query"))
                                                .Term(t=> t.Custom("term query"))
                                                .Terms(ts => ts.Custom("terms query"))
                                                .CustomScore(c => c.Custom("custom score"))
                                                .CustomBoostFactor(c => c.Custom("custom boost factor"))
                                                .ConstantScore(c => c.Custom("constant score"))
                                                .Filtered(f => f.Custom("filtered"))
                                                .MatchAll()
                                                .FuzzyLikeThis(f => f.Custom("flt query"))
                                                .FuzzyLikeThisField(f => f.Custom("flt_field query"))
                                                .Fuzzy(f => f.Custom("fuzzy query"))
                                                .MoreLikeThis(m=> m.Custom("mlt query"))
                                                .MoreLikeThisField(m => m.Custom("mlt_field query"))
                                                .HasChild<AnotherTestClass>( h => h.Custom("has child query"))
                                                .HasParent<AnotherTestClass>(h => h.Custom("has parent query"))
                                                .TopChildren(t => t.Custom("top children query"))
                                                .Wildcard(w => w.Custom("wildcard query"))
                                                .Indices(i => i.Custom("indices query"))
                                                .CustomFiltersScore(cfs => cfs.Custom("custom filters score query"))
                                                .ToString();



        It should_return_correct_result = () => result.ShouldEqual(("'query': " +
                                                                    "{ 'text': { text query } }," +
                                                                    "{ 'text_phrase': { text phrase query } }," +
                                                                    "{ 'text_phrase_prefix': { text phrase prefix query } }," +
                                                                    "{ 'match': { match query } }," +
                                                                    "{ 'multi_match': { multi match query } }," +
                                                                    "{ 'bool': { bool query } }," +
                                                                    "{ 'boosting': { boosting query } }," +
                                                                    "{ 'ids': { ids query } }," +
                                                                    "{ 'dis_max': { dismax query } }," +
                                                                    "{ 'field': { field query } }," +
                                                                    "{ 'nested': { nested query } }," +
                                                                    "{ 'query_string': { query string } }," +
                                                                    "{ 'prefix': { prefix query } }," +
                                                                    "{ 'range': { range query } }," +
                                                                    "{ 'term': { term query } }," +
                                                                    "{ 'terms': { terms query } }," +
                                                                    "{ 'custom_score': { custom score } }," +
                                                                    "{ 'custom_boost_factor': { custom boost factor } }," +
                                                                    "{ 'constant_score': { constant score } }," +
                                                                    "{ 'filtered': { filtered } }," +
                                                                    "{ 'match_all': {  } }," +
                                                                    "{ 'fuzzy_like_this': { flt query } }," +
                                                                    "{ 'fuzzy_like_this_field': { flt_field query } }," +
                                                                    "{ 'fuzzy': { fuzzy query } }," +
                                                                    "{ 'more_like_this': { mlt query } }," +
                                                                    "{ 'more_like_this_field': { mlt_field query } }," +
                                                                    "{ 'has_child': { has child query } }," +
                                                                    "{ 'has_parent': { has parent query } }," +
                                                                    "{ 'top_children': { top children query } }," +                                                                    
                                                                    "{ 'wildcard': { wildcard query } }," +
                                                                    "{ 'indices': { indices query } }," +
                                                                    "{ 'custom_filters_score': { custom filters score query } }").AltQuote());

        private static string result;
    }
}
