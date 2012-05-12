using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    ///  Allows to explicitly refresh one or more index, making all operations performed since the last refresh available for search.
    ///  The (near) real-time capabilities depends on the index engine used. 
    ///  For example, the robin one requires refresh to be called, but by default a refresh is scheduled periodically.
    ///  http://www.elasticsearch.org/guide/reference/api/admin-indices-refresh.html
    /// </summary>
    public class RefreshCommand: CommandBuilder<RefreshCommand>
    {
        public string Indexes { get; private set; }



        public RefreshCommand(string index = null)
        {
            Indexes = index;
        }

        public RefreshCommand(string[] indexes)
        {
            Indexes = indexes.JoinWithComma();
        }


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Indexes, "_refresh");
        }
    }
}
