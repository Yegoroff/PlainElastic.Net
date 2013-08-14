using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Builders.Queries.Filters
{
    public class GeoBoundingBoxFilter<T> : FieldQueryBase<T, GeoBoundingBoxFilter<T>>
    {
        private bool _hasTopLeftPoint;
        private bool _hasBottomRightPoint;

        public GeoBoundingBoxFilter<T> TopLeft(double latitude, double longitude)
        {
            _hasTopLeftPoint = true;
            RegisterJsonPart("'top_left': {{ 'lat': {0},'lon': {1} }}", latitude.ToString(), longitude.ToString());
            return this;
        }

        public GeoBoundingBoxFilter<T> BottomRight(double latitude, double longitude)
        {
            _hasBottomRightPoint = true;
            RegisterJsonPart("'bottom_right': {{ 'lat': {0},'lon': {1} }}", latitude.ToString(), longitude.ToString());
            return this;
        }

        protected override bool HasRequiredParts()
        {
            return _hasTopLeftPoint && _hasBottomRightPoint;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            if (string.IsNullOrWhiteSpace(RegisteredField))
                return "{{ 'geo_bounding_box': {0} }}".AltQuoteF(body);

            return "{{ 'geo_bounding_box': {{ {0}: {{ {1} }} }} }}".AltQuoteF(RegisteredField, body);
        }
    }
}