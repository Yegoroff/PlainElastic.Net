using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public class Sort<T> : QueryBase<Sort<T>>
    {

        /// <summary>
        /// Sort result using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="order">The sort order. By default order depends on chosen field (descending for "_scope", ascending for others) and field analyzer.</param>
        /// <param name="missing">The missing value handling strategy. Use _last, _first or custom value.</param>
        /// <param name="ignoreUnmapped"> The ignore_unmapped option allows to ignore fields that have no mapping and not sort by them. </param>
        public Sort<T> Field(Expression<Func<T, object>> field, SortDirection order = SortDirection.@default, string missing = null, bool ignoreUnmapped = false)
        {
            var fieldName = field.GetPropertyPath();

            return Field(fieldName, order, missing, ignoreUnmapped);
        }

        /// <summary>
        /// Sort result using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field. Use _score to sort by score.</param>
        /// <param name="order">The sort order. By default order depends on chosen field (descending for "_scope", ascending for others) and field analyzer.</param>
        /// <param name="missing">The missing value handling strategy. Use _last, _first or custom value.</param>
        /// <param name="ignoreUnmapped"> The ignore_unmapped option allows to ignore fields that have no mapping and not sort by them. </param>
        public Sort<T> Field(string field, SortDirection order = SortDirection.@default, string missing = null, bool ignoreUnmapped = false)
        {
            var fieldParams = new List<string>();

            if (order != SortDirection.@default)
                fieldParams.Add("'order': {0}".AltQuoteF(order.AsString().Quotate()));

            if (!missing.IsNullOrEmpty())
                fieldParams.Add("'missing': {0}".AltQuoteF(missing.Quotate()));

            if (ignoreUnmapped)
                fieldParams.Add("'ignore_unmapped': true".AltQuote());

            if (fieldParams.Any())
                RegisterJsonPart("{{ {0}: {{ {1} }} }}", field.Quotate(), fieldParams.JoinWithComma());
            else
                RegisterJsonPart(field.Quotate());

            return this;
        }

        /// <summary>
        /// Sort result by geo distance using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="lat">The latitude.</param>
        /// <param name="lon">The longitude.</param>
        /// <param name="unit">The distance unit.</param>
        /// <param name="order">The sort order. By default results will be sorted ascending.</param>
        public Sort<T> GeoDistance(Expression<Func<T, object>> field, double lat, double lon, DistanceUnit unit, SortDirection order = SortDirection.@default)
        {
            var fieldName = field.GetPropertyPath();

            return GeoDistance(fieldName, lat, lon, unit, order);
        }

        /// <summary>
        /// Sort result by geo distance using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="lat">The latitude.</param>
        /// <param name="lon">The longitude.</param>
        /// <param name="unit">The distance unit.</param>
        /// <param name="order">The sort order. By default results will be sorted ascending.</param>
        public Sort<T> GeoDistance(string field, double lat, double lon, DistanceUnit unit, SortDirection order = SortDirection.@default)
        {
            string geoField = "'{0}': {{ 'lat': {1},'lon': {2} }}".AltQuoteF(field, lat.AsString(), lon.AsString());

            return AddGeoDistancePart(geoField, unit, order);
        }

        /// <summary>
        /// Sort result by geo distance using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="geohash">The geohash.</param>
        /// <param name="unit">The distance unit.</param>
        /// <param name="order">The sort order. By default results will be sorted ascending.</param>
        public Sort<T> GeoDistance(Expression<Func<T, object>> field, string geohash, DistanceUnit unit, SortDirection order = SortDirection.@default)
        {
            var fieldName = field.GetPropertyPath();

            return GeoDistance(fieldName, geohash, unit, order);
        }

        /// <summary>
        /// Sort result by geo distance using specified field.
        /// There can be several Sort parameters (order is important).
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="geohash">The geohash.</param>
        /// <param name="unit">The distance unit.</param>
        /// <param name="order">The sort order. By default results will be sorted ascending.</param>
        public Sort<T> GeoDistance(string field, string geohash, DistanceUnit unit, SortDirection order = SortDirection.@default)
        {
            string geoField = "'{0}.location': '{1}'".AltQuoteF(field, geohash);

            return AddGeoDistancePart(geoField, unit, order);
        }

        public Sort<T> Script(string script, string type, string @params, SortDirection order)
        {
            RegisterJsonPart("{{ '_script': {{ 'script': {0},'type': {1},'params': {2},'order': {3} }} }}", script.Quotate(), type.Quotate(), @params, order.AsString().Quotate());
            return this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'sort': [{0}]".AltQuoteF(body);

        }


        private Sort<T> AddGeoDistancePart(string geoField, DistanceUnit unit, SortDirection order = SortDirection.@default)
        {
            var fieldParams = new List<string>();

            fieldParams.Add("'unit': {0}".AltQuoteF(unit.AsString().Quotate()));

            if (order != SortDirection.@default)
                fieldParams.Add("'order': {0}".AltQuoteF(order.AsString().Quotate()));

            fieldParams.Add(geoField);

            RegisterJsonPart("{{ '_geo_distance': {{ {0} }} }}", fieldParams.JoinWithComma());

            return this;
        }

    }
}