using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Filters documents that include only hits that exists within a specific distance from a geo point.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/geo-distance-filter.html
    /// </summary>
    public class GeoDistanceFilter<T> : FieldQueryBase<T, GeoDistanceFilter<T>>
    {
        private bool hasDistance;
        private bool hasPoint;


        /// <summary>
        /// The distance to include hits in the filter.
        /// </summary>
        public GeoDistanceFilter<T> Distance(double? distance, DistanceUnit distanceUnit)
        {
            if (!distance.HasValue)
                return this;

            return Distance(distance.AsString() + distanceUnit.AsString());
        }

        /// <summary>
        /// The distance to include hits in the filter.
        /// Single string with the unit (either mi/miles or km) e.g. 20mi.
        /// Kilometers by default.
        /// </summary>
        public GeoDistanceFilter<T> Distance(string distance)
        {
            if (distance.IsNullOrEmpty())
                return this;

            RegisterJsonPart("'distance': {0}", distance.Quotate());

            hasDistance = true;

            return this;
        }

        public GeoDistanceFilter<T> GeoPoint(double? lat, double? lon)
        {
            if (!(lat.HasValue && lon.HasValue))
                return this;

            RegisterJsonPart("{0}: {{ 'lat': {1},'lon': {2} }}", RegisteredField, lat.AsString(), lon.AsString());

            hasPoint = true;

            return this;
        }

        public GeoDistanceFilter<T> Geohash(string geohash)
        {
            if (geohash.IsNullOrEmpty())
                return this;

            RegisterJsonPart("'{0}': '{1}'", RawFieldName, geohash);

            hasPoint = true;

            return this;
        }

        /// <summary>
        /// How to compute the distance.
        /// Can either be arc (better precision) or plane (faster). Defaults to arc.
        /// </summary>
        public GeoDistanceFilter<T> DistanceType(DistanceType distanceType)
        {
            RegisterJsonPart("'distance_type': {0}", distanceType.ToString().Quotate());
            return this;
        }

        /// <summary>
        /// Controls whether an optimization of using first a bounding box check will be used.
        /// </summary>
        public GeoDistanceFilter<T> OptimizeBoundingBox(OptimizeBoundingBox optimizeBoundingBox)
        {
            RegisterJsonPart("'optimize_bbox': {0}", optimizeBoundingBox.ToString().Quotate());
            return this;
        }


        /// <summary>
        /// Allows to name filter, so the search response will include for each hit the matched_filters 
        /// it matched on (note, this feature make sense for or / bool filters).
        /// http://www.elasticsearch.org/guide/reference/api/search/named-filters.html 
        /// </summary>
        public GeoDistanceFilter<T> Name(string filterName)
        {
            RegisterJsonPart("'_name': {0}", filterName.Quotate());
            return this;
        }

        /// <summary>
        /// Allows to specify Cache Key that will be used as the caching key for that filter.
        /// </summary>
        public GeoDistanceFilter<T> CacheKey(string cacheKey)
        {
            RegisterJsonPart("'_cache_key': {0}", cacheKey.Quotate());
            return this;
        }

        /// <summary>
        /// Controls whether the filter will be cached.
        /// </summary>
        public GeoDistanceFilter<T> Cache(bool cache)
        {
            RegisterJsonPart("'_cache': {0}", cache.AsString());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasDistance && hasPoint;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'geo_distance': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}