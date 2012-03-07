using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to change specific index level settings in real time.
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-update-settings.html
    /// </summary>
    public class UpdateSettingsCommand: CommandBuilder<UpdateSettingsCommand>
    {
        public string Index { get; private set; }


        public UpdateSettingsCommand(string index = null)
        {
            Index = index;
        }


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_settings");
        }
    }
}
