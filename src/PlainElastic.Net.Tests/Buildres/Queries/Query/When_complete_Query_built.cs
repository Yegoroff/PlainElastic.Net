﻿using Machine.Specifications;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Tests.Buildres.Queries
{
    [Subject(typeof(Query<>))]
    class When_complete_Query_built
    {
        Because of = () => result = new Query<FieldsTestClass>()
                                                .Bool(b => b.Custom("bool query"))
                                                .DisMax(d => d.Custom("dismax query"))
                                                .Nested(n => n.Custom("nested query"))
                                                .QueryString(q => q.Custom("query string"))
                                                .Range(r => r.Custom("range query"))
                                                .Term(t=> t.Custom("term query"))
                                                .Terms(ts => ts.Custom("terms query"))
                                                .ConstantScore(c => c.Custom("constant score"))
                                                .Filtered(f => f.Custom("filtered"))
                                                .Fuzzy(f => f.Custom("fuzzy query"))
                                                .ToString();



        It should_return_correct_result = () => result.ShouldEqual(("'query': " +
                                                                    "{ 'bool': { bool query } }," +
                                                                    "{ 'dis_max': { dismax query } }," +
                                                                    "{ 'nested': { nested query } }," +
                                                                    "{ 'query_string': { query string } }," +
                                                                    "{ 'range': { range query } }," +
                                                                    "{ 'term': { term query } }," +
                                                                    "{ 'terms': { terms query } }," +
                                                                    "{ 'constant_score': { constant score } }," +
                                                                    "{ 'filtered': { filtered } }," +
                                                                    "{ 'fuzzy': { fuzzy query } }").AltQuote());

        private static string result;
    }
}
