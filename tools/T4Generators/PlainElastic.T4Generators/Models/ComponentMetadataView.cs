using System.Collections.Generic;
using System.Linq;
using PlainElastic.T4Generators.Utils;

namespace PlainElastic.T4Generators.Models
{
    public class ComponentMetadataView
    {
        public ComponentMetadataView(ComponentMetadata metadata, AnalysisViewSettings settings)
        {
            OriginalMetadata = metadata;

            ElasticType = metadata.ElasticType;
            BaseClassTemplate = metadata.BaseClass;
            JsonPartFuncReturnClass = metadata.JsonPartFuncReturnClass;
            CamelCaseType = ElasticType.ToCamelCase();
            ClassName = CamelCaseType + settings.ClassNameSuffix;
            ComponentType = settings.ComponentTypeEnum + "." + ElasticType;
            Description = metadata.Description + "\nsee " + metadata.ReferenceUrl;

            Properties = (metadata.Properties ?? Enumerable.Empty<ComponentMetadataProperty>())
                            .Select(p => new ComponentMetadataPropertyView(p)).ToList();
        }

        public ComponentMetadata OriginalMetadata { get; private set; }
        public string ElasticType { get; private set; }
        public string BaseClassTemplate { get; private set; }
        public string JsonPartFuncReturnClass { get; set; }
        public string CamelCaseType { get; private set; }
        public string ClassName { get; private set; }
        public string ComponentType { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<ComponentMetadataPropertyView> Properties { get; set; }
    }

    public class ComponentMetadataPropertyView
    {
        public ComponentMetadataPropertyView(ComponentMetadataProperty property)
        {
            OriginalProperty = property;

            IsTestOnly = property.IsTestOnly;
            ElasticName = property.Name;
            ClrName = ElasticName.ToCamelCase();
            ClrType = property.Type;
            AddStringOverload = property.AddStringOverload;
            TestValue = property.TestValue;
            Description = property.Description;

            if (!string.IsNullOrEmpty(property.DefaultCode))
            {
                DefaultCode = property.DefaultCode;
            }
            else if (!string.IsNullOrEmpty(property.DefaultValue))
            {
                DefaultCode = ClrType.ClrTypeCategory() == ClrTypeCategory.String
                                ? '"' + property.DefaultValue + '"'
                                : property.DefaultValue;
            }
        }

        public ComponentMetadataProperty OriginalProperty { get; private set; }
        public bool IsTestOnly { get; private set; }
        public string ElasticName { get; private set; }
        public string ClrName { get; private set; }
        public string ClrType { get; private set; }
        public string DefaultCode { get; private set; }
        public bool AddStringOverload { get; private set; }
        public string TestValue { get; private set; }
        public string Description { get; private set; }
    }
}