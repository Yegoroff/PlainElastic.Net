using System;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to allows to optimize one or more indices through an API. 
    /// The optimize process basically optimizes the index for faster search operations 
    /// (and relates to the number of segments a lucene index within each shard).
    /// The optimize operation allows to optimize the number of segments to optimize to.
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-optimize.html
    /// </summary>
    public class OptimizeCommand : CommandBuilder<OptimizeCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }


        public OptimizeCommand(string index = null, string type = null)
        {
            Index = index;
            Type = type;
        }

        public OptimizeCommand(string[] indexes, string[] types)
        {
            Index = indexes.JoinWithComma();
            Type = types.JoinWithComma();
        }


        #region Query Parameters

        /// <summary>
        /// The number of segments to optimize to.
        /// To fully optimize the index, set it to 1.
        /// Defaults to simply checking if a merge needs to execute, and if so, executes it.
        /// </summary>
        public OptimizeCommand MaxNumSegments(int maxNumSegments)
        {
            Parameters.Add("max_num_segments", maxNumSegments.AsString());
            return this;
        }

        /// <summary>
        /// Should the optimize process only expunge segments with deletes in it.
        ///  In Lucene, a document is not deleted from a segment, just marked as deleted.
        ///  During a merge process of segments, a new segment is created that does have those deletes.
        ///  This flag allow to only merge segments that have deletes. Defaults to false.
        /// </summary>
        public OptimizeCommand OnlyExpungeDeletes(bool onlyExpungeDeletes)
        {
            Parameters.Add("only_expunge_deletes", onlyExpungeDeletes.AsString());
            return this;
        }


        /// <summary>
        /// Should a refresh be performed after the optimize. Defaults to true.
        /// </summary>
        public OptimizeCommand Refresh(bool refresh = true)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        /// <summary>
        /// Should a flush be performed after the optimize. Defaults to true.
        /// </summary>
        public OptimizeCommand Flush(bool flush = true)
        {
            Parameters.Add("flush", flush.AsString());
            return this;
        }

        /// <summary>
        /// Should the request wait for the merge to end. Defaults to true.
        /// Note, a merge can potentially be a very heavy operation,
        /// so it might make sense to run it set to false.
        /// </summary>
        public OptimizeCommand WaitForMerge(bool waitForMerge = true)
        {
            Parameters.Add("wait_for_merge", waitForMerge.AsString());
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, "_optimize");
        }
    }
}