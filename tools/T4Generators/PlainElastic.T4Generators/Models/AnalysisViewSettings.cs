using PlainElastic.T4Generators.Utils;

namespace PlainElastic.T4Generators.Models
{
    public class AnalysisViewSettings
    {
        public AnalysisViewSettings()
        {
        }

        public AnalysisViewSettings(string elasticSectionName)
        {
            ElasticSectionName = elasticSectionName;
            ClassNameSuffix = elasticSectionName.ToCamelCase();
            SettingsClassName = ClassNameSuffix + "Settings";
            ComponentTypeEnum = "Default" + ClassNameSuffix + "s";
        }

        public string ElasticSectionName { get; set; }
        public string SettingsClassName { get; set; }
        public string ClassNameSuffix { get; set; }
        public string ComponentTypeEnum { get; set; }
    }
}