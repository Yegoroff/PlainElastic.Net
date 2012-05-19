using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PlainElastic.T4Generators.Models;

namespace PlainElastic.T4Generators.Utils
{
    public static class MetadataHelper
    {
        public static IEnumerable<ComponentMetadata> ReadComponentsMetadata(string folderPath)
        {
            var metadataFiles = Directory.EnumerateFiles(folderPath);
            foreach (var metadataFilePath in metadataFiles)
            {
                var metadata = JsonConvert.DeserializeObject<ComponentMetadata>(File.ReadAllText(metadataFilePath));
                metadata.ElasticType = Path.GetFileNameWithoutExtension(metadataFilePath);
                yield return metadata;
            }
        }
    }
}