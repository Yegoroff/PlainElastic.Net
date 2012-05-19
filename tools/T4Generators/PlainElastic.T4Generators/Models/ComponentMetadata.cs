using System.Collections.Generic;

namespace PlainElastic.T4Generators.Models
{
    public class ComponentMetadata
    {
        public string ElasticType { get; set; }
        public string BaseClass { get; set; }
        public string JsonPartFuncReturnClass { get; set; }
        public string Description { get; set; }
        public string ReferenceUrl { get; set; }
        public IEnumerable<ComponentMetadataProperty> Properties { get; set; }
    }

    public class ComponentMetadataProperty
    {
        public bool IsTestOnly { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public string DefaultCode { get; set; }
        public bool AddStringOverload { get; set; }
        public string TestValue { get; set; }
        public string Description { get; set; }
    }
}