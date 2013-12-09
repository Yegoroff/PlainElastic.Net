using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// The geo_distance facet is a facet providing information for ranges of distances from a provided geo_point including count of the number of hits that fall within each range, and aggregation information (like total).
    /// http://www.elasticsearch.org/guide/en/elasticsearch/reference/current/search-facets-geo-distance-facet.html
    /// </summary>
    public class GeoDistanceRangeFacet<T> : FacetBase<GeoDistanceRangeFacet<T>, T>
    {
        private bool hasValue;

        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return "'geo_distance': {{ {0} }}".AltQuoteF(body);

        }

        /// <summary>
        /// The ranges of values to aggregate against, in format (from, to)
        /// </summary>
        public GeoDistanceRangeFacet<T> Ranges(Func<RangeFacet<T>.RangeFromTo, RangeFacet<T>.RangeFromTo> ranges)
        {
            hasValue = !RegisterJsonPartExpression(ranges).GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The unit the ranges are provided in. Defaults to km. Can also be mi, miles, in, inch, yd, yards, kilometers, mm, millimeters, cm, centimeters, m or meters.
        /// </summary>
        public GeoDistanceRangeFacet<T> DistanceUnit(DistanceUnit unit = Queries.DistanceUnit.km)
        {
            RegisterJsonPart("'unit': {0}", unit.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// How to compute the distance. Can either be arc (better precision) or plane (faster). Defaults to arc.
        /// </summary>
        public GeoDistanceRangeFacet<T> DistanceType(DistanceType type = Queries.DistanceType.arc)
        {
            RegisterJsonPart("'distance_type': {0}", type.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// The field to execute range facet against.
        /// </summary>
        public GeoDistanceRangeFacet<T> Field(string fieldName, double? lat = 0, double? lon = 0)
        {
            RegisterJsonPart("{0}: {{ 'lat': {1}, 'lon': {2} }}", fieldName.Quotate(), lat.GetValueOrDefault(0).AsString(), lon.GetValueOrDefault(0).AsString());
            return this;
        }

        /// <summary>
        /// The field to execute range facet against.
        /// </summary>
        public GeoDistanceRangeFacet<T> Field(Expression<Func<T, object>> field, double? lat = 0, double? lon = 0)
        {
            return Field(field.GetPropertyPath(), lat, lon);
        }

        /// <summary>
        /// The field to execute range facet against.
        /// </summary>
        public GeoDistanceRangeFacet<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field, double? lat = 0, double? lon = 0)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName, lat, lon);
        }

    }
}
