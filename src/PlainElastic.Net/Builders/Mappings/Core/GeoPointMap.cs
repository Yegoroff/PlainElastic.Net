using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Mappings
{
    /// <summary>
    /// Represents geo based points
    /// see http://www.elasticsearch.org/guide/en/elasticsearch/reference/0.90/mapping-geo-point-type.html
    /// </summary>
    public class GeoPointMap<T> : PropertyBase<T, GeoPointMap<T>>
    {
        /// <summary>
        /// Set to true to also index the .lat and .lon as fields. Defaults to false.
        /// </summary>
        public GeoPointMap<T> IndexLatLon(bool value = false)
        {
            RegisterCustomJsonMap("'lat_lon': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to also index the .geohash as a field. Defaults to false.
        /// </summary>
        public GeoPointMap<T> IndexGeoHash(bool value = false)
        {
            RegisterCustomJsonMap("'geohash': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to reject geo points with invalid latitude or longitude (default is false) Note: Validation only works when normalization has been disabled.
        /// </summary>
        public GeoPointMap<T> Validate(bool value = false)
        {
            RegisterCustomJsonMap("'validate': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to reject geo points with an invalid latitude
        /// </summary>
        public GeoPointMap<T> ValidateLat(bool value = false)
        {
            RegisterCustomJsonMap("'validate_lat': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to reject geo points with an invalid longitude
        /// </summary>
        public GeoPointMap<T> ValidateLon(bool value = false)
        {
            RegisterCustomJsonMap("'validate_lon': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to normalize latitude and longitude (default is true)
        /// </summary>
        public GeoPointMap<T> Normalize(bool value = true)
        {
            RegisterCustomJsonMap("'normalize': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to normalize latitude
        /// </summary>
        public GeoPointMap<T> NormalizeLat(bool value = true)
        {
            RegisterCustomJsonMap("'normalize_lat': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Set to true to normalize longitude
        /// </summary>
        public GeoPointMap<T> NormalizeLon(bool value = true)
        {
            RegisterCustomJsonMap("'normalize_lon': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// If this option is set to true, not only the geohash but also all its parent cells (true prefixes) will be indexed as well. The number of terms that will be indexed depends on the geohash_precision. Defaults to false. Note: This option implicitly enables geohash.
        /// </summary>
        public GeoPointMap<T> GeoHashPrefix(bool value = false)
        {
            RegisterCustomJsonMap("'geohash_prefix': {0}", value.AsString());
            return this;
        }

        /// <summary>
        /// Sets the geohash precision. It can be set to an absolute geohash length or a distance value (eg 1km, 1m, 1ml) defining the size of the smallest cell. Defaults to an absolute length of 12.
        /// </summary>
        public GeoPointMap<T> GeoHashPrecision(int precision)
        {
            RegisterCustomJsonMap("'geohash_precision': '{0}'", precision.AsString());
            return this;
        }

        /// <summary>
        /// Sets the geohash precision. It can be set to an absolute geohash length or a distance value (eg 1km, 1m, 1ml) defining the size of the smallest cell. Defaults to an absolute length of 12.
        /// </summary>
        public GeoPointMap<T> GeoHashPrecision(string precision)
        {
            RegisterCustomJsonMap("'geohash_precision': '{0}'", precision);
            return this;
        }
        
        protected override string GetElasticFieldType(Type fieldType)
        {
            return "geo_point";
        }
    }
}