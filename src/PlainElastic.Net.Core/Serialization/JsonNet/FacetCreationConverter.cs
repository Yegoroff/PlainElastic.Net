using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PlainElastic.Net.Serialization
{
    public class FacetCreationConverter: JsonConverter
    {
        private readonly Dictionary<string, Type> facetRegistration = new Dictionary<string, Type>
        {
            {"terms", typeof(TermsFacetResult)},
            {"range", typeof(RangeFacetResult)},
            {"filter", typeof(FilterFacetResult)},
            {"statistical", typeof(StatisticalFacetResult)},
            {"terms_stats", typeof(TermsStatsFacetResult)},
            {"geo_distance", typeof(GeoDistanceFacetResult)},
            {"histogram", typeof(HistogramFacetResult)},
            {"date_histogram", typeof(DateHistogramFacetResult)}
        };


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jFacet = JObject.Load(reader);

            var type = (string)jFacet.Property("_type");
            Type facetType;
            if (!facetRegistration.TryGetValue(type, out facetType))
                facetType = typeof(FacetResult);

            var facet = Activator.CreateInstance(facetType);
            serializer.Populate(new JTokenReader(jFacet), facet);

            return facet;
        }


        public override bool CanConvert(Type objectType)
        {
            return typeof(FacetResult).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}