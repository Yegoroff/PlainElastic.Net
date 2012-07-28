using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
	/// <summary>
	/// Builds a command that allows to get a comprehensive status information of one or more indices.
	/// http://www.elasticsearch.org/guide/reference/api/admin-indices-status.html
	/// </summary>
	public class StatusCommand : CommandBuilder<StatusCommand>
	{
		public string Index { get; private set; }

		public StatusCommand(string index = null)
		{
			Index = index;
		}

		protected override string BuildUrlPath()
		{
			return UrlBuilder.BuildUrlPath(Index, "_status");
		}
	}


}