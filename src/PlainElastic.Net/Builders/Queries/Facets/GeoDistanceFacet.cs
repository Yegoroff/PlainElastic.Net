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
    public class GeoDistanceFacet<T> : FacetBase<GeoDistanceFacet<T>, T>
    {
        private bool hasPoint;
        private bool hasDistance;
        private string geoPointFieldName;


        /// <summary>
        /// The field to execute Geo Distance Facet against.
        /// </summary>
        public GeoDistanceFacet<T> Field(string fieldName)
        {
            geoPointFieldName = fieldName.Quotate();
            return this;
        }

        /// <summary>
        /// The field to execute Geo Distance Facet against.
        /// </summary>
        public GeoDistanceFacet<T> Field(Expression<Func<T, object>> field)
        {
            return Field(field.GetPropertyPath());
        }

        /// <summary>
        /// The field to execute Geo Distance Facet against.
        /// </summary>
        public GeoDistanceFacet<T> FieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> field)
        {
            var collectionProperty = collectionField.GetPropertyPath();
           var fieldName = collectionProperty + "." + field.GetPropertyPath();

            return Field(fieldName);
        }

        /// <summary>
        /// Defines the geo_point to calculate distances from.
        /// </summary>
        public GeoDistanceFacet<T> GeoPoint(double? lat, double? lon)
        {
            if (!(lat.HasValue && lon.HasValue))
                return this;

            RegisterJsonPart("{0}: {{ 'lat': {1},'lon': {2} }}", geoPointFieldName, lat.AsString(), lon.AsString());

            hasPoint = true;

            return this;
        }

        /// <summary>
        /// Defines the geohash to calculate distances from.
        /// </summary>
        public GeoDistanceFacet<T> Geohash(string geohash)
        {
            if (geohash.IsNullOrEmpty())
                return this;

            RegisterJsonPart("{0}: '{1}'", geoPointFieldName, geohash);

            hasPoint = true;

            return this;
        }

        /// <summary>
        /// The ranges of values to aggregate against, in format (from, to)
        /// </summary>
        public GeoDistanceFacet<T> Ranges(Func<RangeFromTo, RangeFromTo> ranges)
        {
            hasDistance = !RegisterJsonPartExpression(ranges).GetIsEmpty();
            return this;
        }

        /// <summary>
        /// The unit the ranges are provided in. Defaults to km. Can also be mi, miles, in, inch, yd, yards, kilometers, mm, millimeters, cm, centimeters, m or meters.
        /// </summary>
        public GeoDistanceFacet<T> Unit(DistanceUnit unit = Queries.DistanceUnit.km)
        {
            RegisterJsonPart("'unit': {0}", unit.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// How to compute the distance. Can either be arc (better precision) or plane (faster). Defaults to arc.
        /// </summary>
        public GeoDistanceFacet<T> DistanceType(DistanceType type = Queries.DistanceType.sloppy_arc)
        {
            RegisterJsonPart("'distance_type': {0}", type.AsString().Quotate());
            return this;
        }

        /// <summary>
        /// The field to compute aggregated data per range.
        /// </summary>
        public GeoDistanceFacet<T> ValueField(string fieldName)
        {
            RegisterJsonPart("'value_field': {0}", fieldName.Quotate());
            return this;
        }

        /// <summary>
        /// The field to compute aggregated data per range.
        /// </summary>
        public GeoDistanceFacet<T> ValueField(Expression<Func<T, object>> valueField)
        {
            return ValueField(valueField.GetPropertyPath());
        }

        /// <summary>
        /// The field to compute aggregated data per range.
        /// </summary>
        public GeoDistanceFacet<T> ValueFieldOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, Expression<Func<TProp, object>> valueField)
        {
            var collectionProperty = collectionField.GetPropertyPath();
            var fieldName = collectionProperty + "." + valueField.GetPropertyPath();

            return ValueField(fieldName);
        }

        /// <summary>
        /// The script to get value to compute aggregated data per range.
        /// </summary>
        public GeoDistanceFacet<T> ValueScript(string valueScript)
        {
            RegisterJsonPart("'value_script': {0}", valueScript.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public GeoDistanceFacet<T> Lang(string lang)
        {
            RegisterJsonPart("'lang': {0}", lang.Quotate());
            return this;
        }

        /// <summary>
        /// Sets a scripting language used for scripts.
        /// By default used mvel language.
        /// see: http://www.elasticsearch.org/guide/reference/modules/scripting.html
        /// </summary>
        public GeoDistanceFacet<T> Lang(ScriptLangs lang)
        {
            return Lang(lang.AsString());
        }

        /// <summary>
        /// Sets parameters used for scripts.
        /// </summary>
        public GeoDistanceFacet<T> Params(string paramsBody)
        {
            RegisterJsonPart("'params': {0}", paramsBody);
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasDistance && hasPoint;
        }

        protected override string ApplyFacetBodyJsonTemplate(string body)
        {
            return "'geo_distance': {{ {0} }}".AltQuoteF(body);
        }
    }
}
