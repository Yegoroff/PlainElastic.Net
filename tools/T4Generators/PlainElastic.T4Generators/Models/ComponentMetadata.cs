using System.Collections.Generic;

namespace PlainElastic.T4Generators.Models
{
    public class ComponentMetadata
    {
        public string ElasticType { get; set; }
        public string Description { get; set; }
        public IEnumerable<ComponentMetadataProperty> Properties { get; set; }
    }

    public class ComponentMetadataDto
    {
        public string Description { get; set; }
        public IDictionary<string, ComponentMetadataProperty> Properties { get; set; }
    }

    public class ComponentMetadataProperty
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public string DefaultCode { get; set; }
        public string Description { get; set; }
        public string EnumTestValue { get; set; }
    }
}