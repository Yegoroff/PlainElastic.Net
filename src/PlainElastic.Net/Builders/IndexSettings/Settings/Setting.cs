using PlainElastic.Net.IndexSettings;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Builders.IndexSettings.Settings
{
    public class Setting : SettingsBase<Setting>
    {
        public Setting NumberOfShards(int number)
        {
            RegisterJsonPart("'number_of_shards': {0}", number.AsString());
            return this;
        }

        public Setting NumberOfReplicas(int number)
        {
            RegisterJsonPart("'number_of_replicas': {0}", number.AsString());
            return this;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return body.AltQuote();
        }
    }
}