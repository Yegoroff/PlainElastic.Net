using System.Linq;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    public class BulkOperationOptions
    {
        /// <summary>
        /// Allows to enable external versioning.
        /// By default internal versioning used, to supplemented version number with an external value
        /// (for example, if maintained in a database), version_type should be set to external
        /// </summary>
        public string VersionType;

        /// <summary>
        /// Allows to specify document version that will be used to 
        /// provide optimistic concurrency control.
        /// </summary>
        public long? Version;

        /// <summary>
        /// Allows explicit control over the value fed into the hash function used by the router.
        /// </summary>
        public string Routing;

        /// <summary>
        /// Allows to filter percolator queries that will be executed.
        /// Use the query string syntax to the percolate parameter.
        /// </summary>
        public string Percolate;

        /// <summary>
        /// Allows to specify parent document ID.
        /// </summary>
        public string Parent;
        
        /// <summary>
        /// Allows to specify a timestamp associated with document.
        /// </summary>
        public string Timestamp;

        /// <summary>
        /// Allows to specify ttl (time to live) associated with document.
        /// </summary>
        public string Ttl;


        public override string ToString()
        {
            var result = new[] {
                                   VersionType.IsNullOrEmpty() ? "" : "\"_version_type\": " + VersionType.Quotate(),
                                   Version == null             ? "" : "\"_version\": " + Version.AsString(),
                                   Routing.IsNullOrEmpty()     ? "" : "\"_routing\": " + Routing.Quotate(),
                                   Percolate.IsNullOrEmpty()   ? "" : "\"_percolate\": " + Percolate.Quotate(),
                                   Parent.IsNullOrEmpty()      ? "" : "\"_parent\": " + Parent.Quotate(),
                                   Timestamp.IsNullOrEmpty()   ? "" : "\"_timestamp\": " + Timestamp.Quotate(),
                                   Ttl.IsNullOrEmpty()         ? "" : "\"_ttl\": " + Ttl.Quotate(),
                               };

            return result.Where(s => !s.IsNullOrEmpty()).JoinWithComma();
        }
    }
}