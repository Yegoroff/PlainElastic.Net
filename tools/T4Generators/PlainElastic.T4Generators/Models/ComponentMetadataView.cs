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
            ClassName = ElasticType.ToCamelCase() + settings.ClassNameSuffix;
            ComponentType = settings.ComponentTypeEnum + "." + ElasticType;
            Description = metadata.Description;
            Properties = metadata.Properties.Select(p => new ComponentMetadataPropertyView(p)).ToList();
        }

        public string ElasticType { get; private set; }
        public string ClassName { get; private set; }
        public string ComponentType { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<ComponentMetadataPropertyView> Properties { get; private set; }
    }

    public class ComponentMetadataPropertyView
    {
        public ComponentMetadataPropertyView(ComponentMetadataProperty property)
        {
            ElasticName = property.Name;
            NetName = property.Name.ToCamelCase();
            NetType = property.Type;
            Description = property.Description;
            EnumTestValue = property.EnumTestValue;

            if (!string.IsNullOrEmpty(property.DefaultCode))
            {
                DefaultCode = property.DefaultCode;
            }
            else if (!string.IsNullOrEmpty(property.DefaultValue))
            {
                DefaultCode = NetType.GetNetTypeCategory() == NetTypeCategory.String
                                ? '"' + property.DefaultValue + '"'
                                : property.DefaultValue;
            }
        }

        public string ElasticName { get; private set; }
        public string NetName { get; private set; }
        public string NetType { get; private set; }
        public string DefaultCode { get; private set; }
        public string Description { get; private set; }
        public string EnumTestValue { get; set; }
    }
}