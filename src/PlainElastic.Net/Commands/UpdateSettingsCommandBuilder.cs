namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to change specific index level settings in real time.
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-update-settings.html
    /// </summary>
    public class UpdateSettingsCommandBuilder: CommandBuilder<UpdateSettingsCommandBuilder>
    {
        public string Index { get; private set; }


        public UpdateSettingsCommandBuilder(string index = null)
        {
            Index = index;
        }


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, "_settings");
        }
    }
}
