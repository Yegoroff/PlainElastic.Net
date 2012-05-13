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
        public Query<T> Text(Func<TextQuery<T>, TextQuery<T>> textQuery)
        {
            RegisterJsonPartExpression(textQuery);
            return this;
        }

        /// <summary>
        /// Analyzes the text and creates a phrase query out of the analyzed text.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
        /// </summary>
        public Query<T> TextPhrase(Func<TextPhraseQuery<T>, TextQuery<T>> textPhraseQuery)
        {
            RegisterJsonPartExpression(textPhraseQuery);
            return this;
        }

        /// <summary>
        /// Analyzes the text and creates a phrase query out of the analyzed text and
        /// allows for prefix matches on the last term in the text.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/text-query.html
        /// </summary>
        public Query<T> TextPhrasePrefix(Func<TextPhrasePrefixQuery<T>, TextQuery<T>> textPhrasePrefixQuery)
        {
            RegisterJsonPartExpression(textPhrasePrefixQuery);
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
        public Query<T> CustomScore(Func<CustomScoreQuery<T>, CustomScoreQuery<T>> customScoreQuery)
        {
            RegisterJsonPartExpression(customScoreQuery);
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