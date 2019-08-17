namespace PlainElastic.Net
{
    /// <summary>
    ///  Allows to scroll search request's hits.
    ///  http://www.elasticsearch.org/guide/reference/api/search/scroll
    /// </summary>
    public class SearchScrollCommand: CommandBuilder<SearchScrollCommand>
    {
        public string ScrollId { get; private set; }


        public SearchScrollCommand(string scrollId)
        {
             WithParameter("scroll_id", scrollId);
        }


        /// <summary>
        /// The scroll parameter is a time value parameter (for example: scroll=5m), 
        /// indicating for how long the nodes that participate in the search will maintain relevant resources in order to continue and support it.
        /// see http://www.elasticsearch.org/guide/reference/api/search/scroll.html
        /// </summary>
        public SearchScrollCommand Scroll(string scrollActiveTime)
        {
            WithParameter("scroll", scrollActiveTime);
            return this;
        }


        protected override string BuildUrlPath()
        {
            return "_search/scroll";
        }
    }
}
