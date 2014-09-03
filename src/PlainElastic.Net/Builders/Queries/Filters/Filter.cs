using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Allows to filter result hits without changing facet results.
    /// see http://www.elasticsearch.org/guide/reference/api/search/filter.html
    /// </summary>
    public class Filter<T> : QueryBase<Filter<T>>
    {

        /// <summary>
        /// A filter that matches documents using AND boolean operator on other queries.
        /// This filter is more performant then bool filter. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/and-filter.html
        /// </summary>
        public Filter<T> And(Func<AndFilter<T>, Filter<T>> andFilter)
        {
            RegisterJsonPartExpression(andFilter);
            return this;
        }

        /// <summary>
        /// A filter that matches documents using OR boolean operator on other queries. 
        /// This filter is more performant then bool filter. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/or-filter.html
        /// </summary>
        public Filter<T> Or(Func<OrFilter<T>, Filter<T>> orFilter)
        {
            RegisterJsonPartExpression(orFilter);
            return this;
        }

        /// <summary>
        /// A filter that filters out matched documents using a query.
        /// This filter is more performant then bool filter. Can be placed within queries that accept a filter
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/not-filter.html
        /// </summary>
        public Filter<T> Not(Func<NotFilter<T>, NotFilter<T>> notFilter)
        {
            RegisterJsonPartExpression(notFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields that contain a term (not analyzed).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/term-filter.html
        /// </summary>
        public Filter<T> Term(Func<TermFilter<T>, TermFilter<T>> termFilter)
        {
            RegisterJsonPartExpression(termFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields that match any of the provided terms (not analyzed).
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/terms-filter.html
        /// </summary>
        public Filter<T> Terms(Func<TermsFilter<T>, TermsFilter<T>> termsFilter)
        {
            RegisterJsonPartExpression(termsFilter);
            return this;
        }
        
        /// <summary>
        /// Filters documents where a specific field has a value in them.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/exists-filter.html
        /// </summary>
        public Filter<T> Exists(Func<ExistsFilter<T>, ExistsFilter<T>> existsFilter)
        {
            RegisterJsonPartExpression(existsFilter);
            return this;
        }

        /// <summary>
        /// Filters documents where a specific field has no value in them.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/missing-filter.html
        /// </summary>
        public Filter<T> Missing(Func<MissingFilter<T>, MissingFilter<T>> missingFilter)
        {
            RegisterJsonPartExpression(missingFilter);
            return this;
        }

        /// <summary>
        /// A filter that filters documents that only have the provided ids. 
        /// Note, this filter does not require the _id field to be indexed since it works using the _uid field.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/ids-query.html
        /// </summary>
        public Filter<T> Ids(Func<IdsFilter<T>, IdsFilter<T>> idsFilter)
        {
            RegisterJsonPartExpression(idsFilter);
            return this;
        }

        /// <summary>
        /// A filter that allows to filter nested objects / docs.
        /// The filter is executed against the nested objects / docs as if they were indexed 
        /// as separate docs (they are, internally) and resulting in the root parent doc (or parent nested mapping)
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/nested-filter.html
        /// </summary>
        public Filter<T> Nested(Func<NestedFilter<T>, NestedFilter<T>> nestedFilter)
        {
            RegisterJsonPartExpression(nestedFilter);
            return this;
        }

        /// <summary>
        /// The has_child filter accepts a query and the child type to run against,
        /// and results in parent documents that have child docs matching the query.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-child-filter.html
        /// </summary>
        public Filter<T> HasChild<TChild>(Func<HasChildFilter<T, TChild>, HasChildFilter<T, TChild>> hasChildFilter)
        {
            RegisterJsonPartExpression(hasChildFilter);
            return this;
        }

        /// <summary>
        /// The has_parent filter accepts a query or filterand the parent type to run against,
        /// The filter is executed in the parent document space, which is specified by the parent type. 
        /// This filer return child documents which associated parents have matched.
        /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-parent-filter/
        /// </summary>
        public Filter<T> HasParent<TParent>(Func<HasParentFilter<T, TParent>, HasParentFilter<T, TParent>> hasParentFilter)
        {
            RegisterJsonPartExpression(hasParentFilter);
            return this;
        }


        /// <summary>
        /// Filters documents with fields that have terms within a certain range.
        /// Similar to range query, except that it acts as a filter
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/range-filter.html
        /// </summary>
        public Filter<T> Range(Func<RangeFilter<T>, RangeFilter<T>> rangeFilter)
        {
            RegisterJsonPartExpression(rangeFilter);
            return this;
        }

        /// <summary>
        /// Filters documents with fields that have values within a certain numeric range.
        /// Similar to range filter, except that it works only with numeric values, and the filter execution works differently.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/numeric-range-filter.html
        /// </summary>
        public Filter<T> NumericRange(Func<NumericRangeFilter<T>, RangeFilter<T>> numericRangeFilter)
        {
            RegisterJsonPartExpression(numericRangeFilter);
            return this;
        }

        /// <summary>
        /// A filter that matches documents matching boolean combinations of other queries.
        /// Similar in concept to Boolean query, except that the clauses are other filters. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/bool-filter.html
        /// </summary>
        public Filter<T> Bool(Func<BoolFilter<T>, BoolFilter<T>> boolFilter)
        {
            RegisterJsonPartExpression(boolFilter);
            return this;
        }

        /// <summary>
        /// A limit filter limits the number of documents (per shard) to execute on.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/limit-filter.html
        /// </summary>
        public Filter<T> Limit(Func<LimitFilter<T>, LimitFilter<T>> limitFilter)
        {
            RegisterJsonPartExpression(limitFilter);
            return this;
        }

        /// <summary>
        /// Filters documents matching the provided document / mapping type. 
        /// Note, this filter can work even when the _type field is not indexed (using the _uid field)
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/type-filter.html
        /// </summary>
        public Filter<T> Type(Func<TypeFilter<T>, TypeFilter<T>> typeFilter)
        {
            RegisterJsonPartExpression(typeFilter);
            return this;
        }

        /// <summary>
        /// Wraps any query to be used as a filter. Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/query-filter.html
        /// </summary>
        public Filter<T> Query(Func<QueryFilter<T>, Query<T>> queryFilter)
        {
            RegisterJsonPartExpression(queryFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that have fields containing terms with a specified prefix (not analyzed). 
        /// Similar to phrase query, except that it acts as a filter. 
        /// Can be placed within queries that accept a filter.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/prefix-filter.html
        /// </summary>
        public Filter<T> Prefix(Func<PrefixFilter<T>, PrefixFilter<T>> prefixFilter)
        {
            RegisterJsonPartExpression(prefixFilter);
            return this;
        }

        /// <summary>
        /// A filter that matches on all documents.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/match-all-filter.html
        /// </summary>    
        public Filter<T> MatchAll()
        {
            Func<MatchAllFilter<T>, MatchAllFilter<T>> matchFilter = m => m;
            RegisterJsonPartExpression(matchFilter);
            return this;
        }

        /// <summary>
        /// A filter that will execute the wrapped filter only for the specified indices, and "match_all" when it does not match those indices (by default).
        /// </summary>
        public Filter<T> Indices(Func<IndicesFilter<T>, IndicesFilter<T>> indicesFilter)
        {
            RegisterJsonPartExpression(indicesFilter);
            return this;
        }

        /// <summary>
        /// A filter allowing to define scripts as filters
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/script-filter.html
        /// </summary>
        public Filter<T> Script(Func<ScriptFilter<T>, ScriptFilter<T>> scriptFilter)
        {
            RegisterJsonPartExpression(scriptFilter);
            return this;
        }

        /// <summary>
        /// Filters documents that include only hits that exists within a specific distance from a geo point.
        /// see http://www.elasticsearch.org/guide/reference/query-dsl/geo-distance-filter.html
        /// </summary>
        public Filter<T> GeoDistance(Func<GeoDistanceFilter<T>, GeoDistanceFilter<T>> geoDistanceFilter)
        {
            RegisterJsonPartExpression(geoDistanceFilter);
            return this;
        }

		/// <summary>
		/// The regexp filter is similar to the regexp query, except that it is cacheable and can speedup performance in case you are reusing this filter in your queries.
		/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/query-dsl-regexp-filter.html
		/// </summary>
		public Filter<T> RegExp(Func<RegExpFilter<T>, RegExpFilter<T>> regExpFilter)
		{
			RegisterJsonPartExpression(regExpFilter);
			return this;
		}

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'filter': {0}".AltQuoteF(body);
        }
    }
}