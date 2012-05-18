using System.Collections.Generic;
using System.Linq;
using PlainElastic.T4Generators.Utils;

namespace PlainElastic.T4Generators.Models
{
    public class ComponentMetadataView
    {
        public ComponentMetadataView(ComponentMetadata metadata, AnalysisViewSettings settings)
        {
            ElasticType = metadata.ElasticType;
            BaseClassTemplate = metadata.BaseClass;
            CamelCaseType = ElasticType.ToCamelCase();
            ClassName = CamelCaseType + settings.ClassNameSuffix;
            ComponentType = settings.ComponentTypeEnum + "." + ElasticType;
            Description = metadata.Description;

            Properties = (metadata.Properties ?? Enumerable.Empty<ComponentMetadataProperty>())
                            .Select(p => new ComponentMetadataPropertyView(p)).ToList();
        }

        public string ElasticType { get; private set; }
        public string BaseClassTemplate { get; private set; }
        public string CamelCaseType { get; private set; }
        public string ClassName { get; private set; }
        public string ComponentType { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<ComponentMetadataPropertyView> Properties { get; private set; }
    }

    public class ComponentMetadataPropertyView
    {
        public ComponentMetadataPropertyView(ComponentMetadataProperty property)
        {
            IsTestOnly = property.IsTestOnly;
            ElasticName = property.Name;
            ClrName = ElasticName.ToCamelCase();
            ClrType = property.Type;
            Description = property.Description;
            TestValue = property.TestValue;

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

        public bool IsTestOnly { get; set; }
        public string ElasticName { get; private set; }
        public string ClrName { get; private set; }
        public string ClrType { get; private set; }
        public string DefaultCode { get; private set; }
        public string TestValue { get; set; }
        public string Description { get; private set; }
    }
}