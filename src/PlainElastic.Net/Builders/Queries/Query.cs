using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The query element within the search request body allows to define a query using the Query DSL.
    /// see http://www.elasticsearch.org/guide/reference/api/search/query.html
    /// </summary>
    public class Query<T> : QueryBase<Query<T>>
    {
        
        /// <summary>
        /// A family of text queries that accept text, analyzes it, and constructs a query out of it.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
        /// </summary>  
        [Obsolete("Use MatchQuery instead")]
        public Query<T> Text(Func<TextQuery<T>, TextQuery<T>> textQuery)
        {
            RegisterJsonPartExpression(textQuery);
            return this;
        }

        /// <summary>
        /// Analyzes the text and creates a phrase query out of the analyzed text.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
        /// </summary>
        public Query<T> TextPhrase(Func<TextPhraseQuery<T>, TextPhraseQuery<T>> textPhraseQuery)
        {
            RegisterJsonPartExpression(textPhraseQuery);
            return this;
        }

        /// <summary>
        /// Analyzes the text and creates a phrase query out of the analyzed text and
        /// allows for prefix matches on the last term in the text.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
        /// </summary>
        public Query<T> TextPhrasePrefix(Func<TextPhrasePrefixQuery<T>, TextPhrasePrefixQuery<T>> textPhrasePrefixQuery)
        {
            RegisterJsonPartExpression(textPhrasePrefixQuery);
            return this;
        }

        /// <summary>
        /// A family of match queries that accept text/numerics/dates, analyzes it, and constructs a query out of it.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/match-query/
        /// </summary>
        public Query<T> Match(Func<MatchQuery<T>, MatchQuery<T>> matchQuery)
        {
            RegisterJsonPartExpression(matchQuery);
            return this;
        }

        /// <summary>
        /// The multi_match query builds further on top of the match query by allowing multiple fields to be specified.
        /// The idea here is to allow to more easily build a concise match type query 
        /// over multiple fields instead of using a relatively more expressive query
        /// by using multiple match queries within a bool query.
        /// http://www.elasticsearch.org/guide/reference/query-dsl/multi-match-query/
        /// </summary>
        public Query<T> MultiMatch(Func<MultiMatchQuery<T>, MultiMatchQuery<T>> multiMatchQuery)
        {
            RegisterJsonPartExpression(multiMatchQuery);
            return this;
        }

        /// <summary>
        /// A query that matches documents matching boolean combinations of other queries. 
        /// The bool query maps to Lucene BooleanQuery. It is built using one or more boolean clauses, 
        /// each clause with a typed occurrence
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/bool-query.html
        /// </summary>  
        public Query<T> Bool(Func<BoolQuery<T>, BoolQuery<T>> boolQuery)
        {
            RegisterJsonPartExpression(boolQuery);
            return this;
        }

        /// <summary>
        /// A query that can be used to effectively demote results that match a given query. 
        /// Unlike the “NOT” clause in bool query, this still selects documents 
        /// that contain undesirable terms, but reduces their overall score.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/boosting-query.html
        /// </summary>
        public Query<T> Boosting(Func<BoostingQuery<T>, BoostingQuery<T>> boostingQuery)
        {
            RegisterJsonPartExpression(boostingQuery);
            return this;
        }

        /// <summary>
        /// A query that filters documents that only have the provided ids. 
        /// Note, this query does not require the _id field to be indexed since it works using the _uid field.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/ids-query.html
        /// </summary>
        public Query<T> Ids(Func<IdsQuery<T>, IdsQuery<T>> idsQuery)
        {
            RegisterJsonPartExpression(idsQuery);
            return this;
        }

        /// <summary>
        /// A query that generates the union of documents produced by its subqueries, 
        /// and that scores each document with the maximum score for that document as produced by any subquery, 
        /// plus a tie breaking increment for any additional matching subqueries.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/dis-max-query.html
        /// </summary>   
        public Query<T> DisMax(Func<DisMaxQuery<T>, DisMaxQuery<T>> disMaxQuery)
        {
            RegisterJsonPartExpression(disMaxQuery);
            return this;
        }

        /// <summary>
        /// A query that executes a query string against a specific field.
        /// It is a simplified version of query_string query 
        /// (by setting the default_field to the field this query executed against). 
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/field-query.html
        /// </summary>
        [Obsolete("Use QueryString instead")]
        public Query<T> Field(Func<FieldQuery<T>, FieldQuery<T>> fieldQuery)
        {
            RegisterJsonPartExpression(fieldQuery);
            return this;
        }

        /// <summary>
        /// A query that allows you to modify the score of documents that are retrieved by a query. 
        /// This can be useful if, for example, a score function is computationally expensive 
        /// and it is sufficient to compute the score on a filtered set of documents.
        /// see: http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-function-score-query.html
        /// </summary>
        public Query<T> FunctionScore(Func<FunctionScoreQuery<T>, FunctionScoreQuery<T>> functionScoreQuery)
        {
            RegisterJsonPartExpression(functionScoreQuery);
            return this;
        }

        /// <summary>
        /// Fuzzy like this query find documents that are “like” provided text by running it against one or more fields.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/flt-query.html
        /// </summary>
        public Query<T> FuzzyLikeThis(Func<FuzzyLikeThisQuery<T>, FuzzyLikeThisQuery<T>> fuzzyLikeThisQuery)
        {
            RegisterJsonPartExpression(fuzzyLikeThisQuery);
            return this;
        }

        /// <summary>
        /// The fuzzy_like_this_field query is the same as the fuzzy_like_this query, 
        /// except that it runs against a single field. 
        /// It provides nicer query DSL over the generic fuzzy_like_this query, 
        /// and support typed fields query (automatically wraps typed fields with type filter to match only on the specific type).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/flt-field-query.html
        /// </summary>
        public Query<T> FuzzyLikeThisField(Func<FuzzyLikeThisFieldQuery<T>, FuzzyLikeThisFieldQuery<T>> fuzzyLikeThisFieldQuery)
        {
            RegisterJsonPartExpression(fuzzyLikeThisFieldQuery);
            return this;
        }

        /// <summary>
        /// More like this query find documents that are “like” provided text by running it against one or more fields.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/mlt-query.html
        /// </summary>
        public Query<T> MoreLikeThis(Func<MoreLikeThisQuery<T>, MoreLikeThisQuery<T>> moreLikeThisQuery)
        {
            RegisterJsonPartExpression(moreLikeThisQuery);
            return this;
        }

        /// <summary>
        /// The more_like_this_field query is the same as the more_like_this query, 
        /// except it runs against a single field. It provides nicer query DSL over the generic more_like_this query,
        /// and support typed fields query (automatically wraps typed fields with type filter to match only on the specific type).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/mlt-field-query.html
        /// </summary>
        [Obsolete("Use MoreLikeThisQuery set to a specific field")]
        public Query<T> MoreLikeThisField(Func<MoreLikeThisFieldQuery<T>, MoreLikeThisFieldQuery<T>> moreLikeThisFieldQuery)
        {
            RegisterJsonPartExpression(moreLikeThisFieldQuery);
            return this;
        }

        /// <summary>
        /// The has_child query accepts a query and the child type to run against,
        /// and results in parent documents that have child docs matching the query.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-child-query.html
        /// </summary>
        public Query<T> HasChild<TChild>(Func<HasChildQuery<T, TChild>, HasChildQuery<T, TChild>> hasChildQuery)
        {
            RegisterJsonPartExpression(hasChildQuery);
            return this;
        }

        /// <summary>
        /// The has_parent query accepts a query and the parent type to run against,
        /// The query is executed in the parent document space, which is specified by the parent type. 
        /// This query return child documents which associated parents have matched.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-parent-query/
        /// </summary>
        public Query<T> HasParent<TParent>(Func<HasParentQuery<T, TParent>, HasParentQuery<T, TParent>> hasParentQuery)
        {
            RegisterJsonPartExpression(hasParentQuery);
            return this;
        }


        /// <summary>
        /// The top_children query runs the child query with an estimated hits size,
        /// and out of the hit docs, aggregates it into parent docs. 
        /// If there aren’t enough parent docs matching the requested from/size search request,
        /// then it is run again with a wider (more hits) search.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/top-children-query.html
        /// </summary>
        public Query<T> TopChildren(Func<TopChildrenQuery<T>, TopChildrenQuery<T>> topChildrenQuery)
        {
            RegisterJsonPartExpression(topChildrenQuery);
            return this;
        }

        /// <summary>
        /// A query that allows to query nested objects / docs.
        /// The query is executed against the nested objects / docs as if they were indexed 
        /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-query.html
        /// </summary>   
        public Query<T> Nested(Func<NestedQuery<T>, NestedQuery<T>> nestedQuery)
        {
            RegisterJsonPartExpression(nestedQuery);
            return this;
        }

        /// <summary>
        /// A query that allows to wrap another query and customize the scoring of it 
        /// optionally with a computation derived from other field values in the doc (numeric ones) using script expression. 
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/custom-score-query.html
        /// </summary>
        [Obsolete("Use FunctionScore instead")]
        public Query<T> CustomScore(Func<CustomScoreQuery<T>, CustomScoreQuery<T>> customScoreQuery)
        {
            RegisterJsonPartExpression(customScoreQuery);
            return this;
        }

        /// <summary>
        /// A query that allows  query allows to wrap another query and multiply its score by the provided boost_factor.
        /// This can sometimes be desired since boost value set on specific queries gets normalized, while this query boost factor does not.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/custom-boost-factor-query.html
        /// </summary>
        [Obsolete("Use FunctionScore instead")]
        public Query<T> CustomBoostFactor(Func<CustomBoostFactorQuery<T>, CustomBoostFactorQuery<T>> customBoostFactor)
        {
            RegisterJsonPartExpression(customBoostFactor);
            return this;
        }

        /// <summary>
        /// A query that wraps a filter or another query and simply returns a constant score equal 
        /// to the query boost for every document in the filter. Maps to Lucene ConstantScoreQuery.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/constant-score-query.html
        /// </summary>   
        public Query<T> ConstantScore(Func<ConstantScoreQuery<T>, ConstantScoreQuery<T>> constantScoreQuery)
        {
            RegisterJsonPartExpression(constantScoreQuery);
            return this;
        }

        /// <summary>
        /// A query that applies a filter to the results of another query. This query maps to Lucene FilteredQuery.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/filtered-query.html
        /// </summary>   
        public Query<T> Filtered(Func<FilteredQuery<T>, FilteredQuery<T>> filteredQuery)
        {
            RegisterJsonPartExpression(filteredQuery);
            return this;
        }

        /// <summary>
        /// A fuzzy based query that uses similarity based on Levenshtein (edit distance) algorithm.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/fuzzy-query.html
        /// </summary>   
        public Query<T> Fuzzy(Func<FuzzyQuery<T>, FuzzyQuery<T>> fuzzyQuery)
        {
            RegisterJsonPartExpression(fuzzyQuery);
            return this;
        }

        /// <summary>
        /// A query that matches all documents. Maps to Lucene MatchAllDocsQuery.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/match-all-query.html        
        /// </summary>   
        public Query<T> MatchAll(Func<MatchAllQuery<T>, MatchAllQuery<T>> matchAllQuery = null)
        {
            if (matchAllQuery == null)
                matchAllQuery = m => m;

            RegisterJsonPartExpression(matchAllQuery);
            return this;
        }

        /// <summary>
        /// A query that uses a query parser in order to parse its content
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/query-string-query.html
        /// </summary>    
        public Query<T> QueryString(Func<QueryString<T>, QueryString<T>> queryString)
        {
            RegisterJsonPartExpression(queryString);
            return this;
        }

        /// <summary>
        /// Matches documents that have fields containing terms with a specified prefix (not analyzed).
        /// The prefix query maps to Lucene PrefixQuery
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/prefix-query.html
        /// </summary>
        public Query<T> Prefix(Func<PrefixQuery<T>, PrefixQuery<T>> prefixQuery)
        {
            RegisterJsonPartExpression(prefixQuery);
            return this;
        }

        /// <summary>
        /// Matches documents with fields that have terms within a certain range. 
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-query.html
        /// </summary>
        public Query<T> Range(Func<RangeQuery<T>, RangeQuery<T>> rangeQuery)
        {
            RegisterJsonPartExpression(rangeQuery);
            return this;
        }

        /// <summary>
        /// Matches documents that have fields that contain a term (not analyzed). The term query maps to Lucene TermQuery
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-query.html
        /// </summary>
        public Query<T> Term(Func<TermQuery<T>, TermQuery<T>> termQuery)
        {
            RegisterJsonPartExpression(termQuery);
            return this;
        }

        /// <summary>
        /// A query that match on any (configurable) of the provided terms.
        /// This is a simpler syntax query for using a bool query with several term queries in the should clauses
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/terms-query.html
        /// </summary>
        public Query<T> Terms(Func<TermsQuery<T>, TermsQuery<T>> termsQuery)
        {
            RegisterJsonPartExpression(termsQuery);
            return this;
        }

        /// <summary>
        /// Matches documents that have fields matching a wildcard expression (not analyzed).
        /// Supported wildcards are *, which matches any character sequence (including the empty one), 
        /// and ?, which matches any single character.
        /// Note that this query can be slow, as it needs to iterate over many terms. 
        /// In order to prevent extremely slow wildcard queries, 
        /// a wildcard term should not start with one of the wildcards * or ?. 
        /// The wildcard query maps to Lucene WildcardQuery.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/wildcard-query.html
        /// </summary>
        public Query<T> Wildcard(Func<WildcardQuery<T>, WildcardQuery<T>> wildcardQuery)
        {
            RegisterJsonPartExpression(wildcardQuery);
            return this;
        }

        /// <summary>
        /// A query can be used when executed across multiple indices, 
        /// allowing to have a query that executes only when executed on an index that matches a specific list of indices,
        /// and another query that executes when it is executed on an index that does not match the listed indices.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/indices-query.html
        /// </summary>
        public Query<T> Indices(Func<IndicesQuery<T>, IndicesQuery<T>> indicesQuery)
        {
            RegisterJsonPartExpression(indicesQuery);
            return this;
        }


        /// <summary>
        /// A query that allows to execute a query, and if the hit matches a provided filter (ordered),
        /// use either a boost or a script associated with it to compute the score.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/custom-filters-score-query.html
        /// </summary>
        public Query<T> CustomFiltersScore(Func<CustomFiltersScoreQuery<T>, CustomFiltersScoreQuery<T>> customFiltersScoreQuery)
        {
            RegisterJsonPartExpression(customFiltersScoreQuery);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'query': {0}".AltQuoteF(body);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
    }
}