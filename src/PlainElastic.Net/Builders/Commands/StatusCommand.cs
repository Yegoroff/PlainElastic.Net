using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
	/// <summary>
	/// Builds a command that allows to get a comprehensive status information of one or more indices.
	/// http://www.elasticsearch.org/guide/reference/api/admin-indices-status.html
	/// </summary>
	public class StatusCommand : CommandBuilder<StatusCommand>
	{
        public string Indexes { get; private set; }

		public StatusCommand(string index = null)
		{
			Indexes = index;
		}

        public StatusCommand(string[] indexes)
        {
            Indexes = indexes.JoinWithComma();
        }

        #region Query Parameters

        /// <summary>
        /// Used to control whether the recovery status of shard should be included to status results.
        /// </summary>
        public StatusCommand Recovery(bool recoveryStatus)
        {
            Parameters.Add("recovery", recoveryStatus.AsString());
            return this;
        }

        /// <summary>
        /// Used to control whether the snapshot status of shard should be included to status results.
        /// </summary>
        public StatusCommand Snapshot(bool snapshotStatus)
        {
            Parameters.Add("snapshot", snapshotStatus.AsString());
            return this;
        }

        #endregion


		protected override string BuildUrlPath()
		{
			return UrlBuilder.BuildUrlPath(Indexes, "_status");
		}
	}


}