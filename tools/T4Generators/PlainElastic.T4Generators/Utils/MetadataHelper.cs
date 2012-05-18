using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PlainElastic.T4Generators.Models;

namespace PlainElastic.T4Generators.Utils
{
    public static class MetadataHelper
    {
        public static IEnumerable<ComponentMetadata> LoadComponentsMetadata(string folderPath)
        {
            var metadataFiles = Directory.EnumerateFiles(folderPath);
            foreach (var metadataFilePath in metadataFiles)
            {
                var metadataDto = JsonConvert.DeserializeObject<ComponentMetadataDto>(File.ReadAllText(metadataFilePath));

                var properties = (metadataDto.Properties ?? Enumerable.Empty<KeyValuePair<string, ComponentMetadataProperty>>())
                                    .OrderBy(p => p.Key)
                                    .Select(p => new ComponentMetadataProperty
                                                    {
                                                        Name = p.Key,
                                                        Type = p.Value.Type,
                                                        DefaultValue = p.Value.DefaultValue,
                                                        DefaultCode = p.Value.DefaultCode,
                                                        Description = p.Value.Description,
                                                        EnumTestValue = p.Value.EnumTestValue
                                                    }).ToList();

                yield return new ComponentMetadata
                                 {
                                     ElasticType = Path.GetFileNameWithoutExtension(metadataFilePath),
                                     Description = metadataDto.Description,
                                     Properties = properties
                                 };
            }
        }
    }
}