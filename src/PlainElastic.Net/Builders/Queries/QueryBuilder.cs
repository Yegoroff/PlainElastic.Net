using System;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Provides sophisticated interface to construct ElasicSearch queries.
    /// For details about ES querying see: http://www.elasticsearch.org/guide/reference/api/search/request-body.html ,
    /// http://www.elasticsearch.org/guide/reference/query-dsl/ and http://www.elasticsearch.org/guide/reference/api/search/    
    /// </summary>
    public class QueryBuilder<T> : QueryBase<QueryBuilder<T>>
    {
        /// <summary>
        /// The query element within the search request body allows to define a query using the Query DSL.
        /// see http://www.elasticsearch.org/guide/reference/api/search/query.html
        /// </summary>
        public QueryBuilder<T> Query(Func<Query<T>, Query<T>> query)
        {
            RegisterJsonPartExpression(query);
            return this;
        }

        /// <summary>
        /// Allows to filter result hits without changing facet results.
        /// see http://www.elasticsearch.org/guide/reference/api/search/filter.html
        /// </summary>
        public QueryBuilder<T> Filter(Func<Filter<T>, Filter<T>> filter)
        {
            RegisterJsonPartExpression(filter);
            return this;
        }

        /// <summary>
        /// Allows to collect aggregated data based on a search query. 
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/
        /// </summary>
        [Obsolete("Facets are deprecated and will be removed in a future release. You are encouraged to migrate to aggregations instead.")]
        public QueryBuilder<T> Facets(Func<Facets<T>, Facets<T>> facets)
        {
            RegisterJsonPartExpression(facets);
            return this;
        }

		/// <summary>
		/// Allows to collect aggregated data based on a search query. 
		/// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-aggregations.html
		/// </summary>
		public QueryBuilder<T> Aggregations(Func<Aggregations<T>, Aggregations<T>> aggregations)
		{
			RegisterJsonPartExpression(aggregations);
			return this;
		}

        /// <summary>
        /// The starting from index of the hits to return. Defaults to 0.
        /// </summary>
        public QueryBuilder<T> From (int from = 0 )
        {
            RegisterJsonPart("'from': {0}", from.AsString());
            return this;
        }

        /// <summary>
        /// The number of hits to return. Defaults to 10.
        /// </summary>
        public QueryBuilder<T> Size(int size = 10)
        {            
            RegisterJsonPart("'size': {0}", size.AsString());
            return this;
        }

        /// <summary>
        /// When sorting on a field, scores are not computed. 
        /// By setting track_scores to true, scores will still be computed and tracked.
        /// see http://www.elasticsearch.org/guide/reference/api/search/sort.html
        /// </summary>
        public QueryBuilder<T> TrackScores(bool trackScores = false)
        {            
            RegisterJsonPart("'track_scores': {0}", trackScores.AsString());
            return this;
        }

        /// <summary>
        /// Allows to add one or more sort on specific fields. Each sort can be reversed as well. 
        /// The sort is defined on a per field level, with special field name for _score to sort by score.
        /// see http://www.elasticsearch.org/guide/reference/api/search/sort.html
        /// </summary>
        public QueryBuilder<T> Sort(Func<Sort<T>, Sort<T>> sort)
        {
            RegisterJsonPartExpression(sort);
            return this;
        }


        /// <summary>
        /// Enables explanation for each hit on how its score was computed.
        /// see http://www.elasticsearch.org/guide/reference/api/search/explain.html
        /// </summary>
        public QueryBuilder<T> Explain(bool explain = true)
        {
            RegisterJsonPart("'explain': {0}", explain.AsString());
            return this;
        }

        /// <summary>
        /// Returns a version for each search hit.
        /// see http://www.elasticsearch.org/guide/reference/api/search/version.html
        /// </summary>
        public QueryBuilder<T> Version(bool returnVersions = true)
        {
            RegisterJsonPart("'version': {0}", returnVersions.AsString());
            return this;
        }

        /// <summary>
        /// Allows to filter out documents based on a minimum score.
        /// see http://www.elasticsearch.org/guide/reference/api/search/min-score.html
        /// </summary>
        public QueryBuilder<T> MinScore(double minScore)
        {
            RegisterJsonPart("'min_score': {0}", minScore.AsString());
            return this;
        }

        /// <summary>
        /// Allows to highlight search results on one or more fields.
        /// see http://www.elasticsearch.org/guide/reference/api/search/highlighting.html
        /// </summary>
        public QueryBuilder<T> Highlight(Func<Highlight<T>, Highlight<T>> highlight)
        {
            RegisterJsonPartExpression(highlight);
            return this;
        }


        // A search timeout, bounding the search request to be executed within the specified time value and bail with the hits accumulated up to that point when expired. Defaults to no timeout.
        //TODO: timeout

        // Allows to selectively load specific fields for each document represented by a search hit. Defaults to load the internal _source field.
        // see  http://www.elasticsearch.org/guide/reference/api/search/fields.html
        //TODO: fields

        // Allows to return a script evaluation (based on different fields) for each hit.
        // see http://www.elasticsearch.org/guide/reference/api/search/script-fields.html
        //TODO: script_fields

        // Controls a preference of which shard replicas to execute the search request on. By default, the operation is randomized between the each shard replicas.
        // see http://www.elasticsearch.org/guide/reference/api/search/preference.html
        //TODO: preference 



        // Allows to configure different boost level per index when searching across more than one indices.
        // http://www.elasticsearch.org/guide/reference/api/search/index-boost.html
        //TODO: indices_boost



        /// <summary>
        /// Builds JSON query.
        /// </summary>
        public string Build()
        {
            return (this as IJsonConvertible).ToJson();
        }


        /// <summary>
        /// Builds beatified JSON query.
        /// </summary>
        public string BuildBeautified()
        {
            return Build().BeautifyJson();
        }


        /// <summary>
        /// Returns a <see cref="System.String"/> that represents beautified JSON query.
        /// </summary>
        public override string ToString()
        {
            return BuildBeautified();
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ {0} }}".AltQuoteF(body);
        }
    }
}