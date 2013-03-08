using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/geo-distance-filter.html
    /// </summary>
    public class GeoDistanceFilter<T> : FieldQueryBase<T, GeoDistanceFilter<T>>
    {
        private bool hasDistance;
        private bool hasPoint;

        protected override bool HasRequiredParts()
        {
            return hasDistance && hasPoint;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (!HasRequiredParts())
            {
                return string.Empty;
            }

            return "{{ 'geo_distance': {{ {0} }} }}".AltQuoteF(body);
        }

        public GeoDistanceFilter<T> Distance(string distance)
        {
            if (distance.IsNullOrEmpty())
            {
                return this;
            }

            RegisterJsonPart("'distance': {0}", distance.Quotate());

            hasDistance = true;

            return this;
        }

        public GeoDistanceFilter<T> Point(double lat, double lon)
        {
            RegisterJsonPart(" {0}: {{ 'lat': {1}, 'lon': {2} }}", RegisteredField, lat.AsString(), lon.AsString());

            hasPoint = true;

            return this;
        }
    }
}