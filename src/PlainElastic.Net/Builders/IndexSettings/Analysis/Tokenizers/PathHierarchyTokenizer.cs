using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The path_hierarchy tokenizer takes something like "/something/something/else"
    /// and produces tokens "/something", "/something/something", "/something/something/else".
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/pathhierarchy-tokenizer.html
    /// </summary>
    public class PathHierarchyTokenizer : NamedComponentBase<PathHierarchyTokenizer>
    {

        /// <summary>
        /// Sets the character delimiter to use.
        /// Defaults to '/'.
        /// </summary>
        public PathHierarchyTokenizer Delimiter(char delimiter = '/')
        {
            RegisterJsonPart("'delimiter': {0}", delimiter.ToString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets an optional replacement character to use.
        /// Defaults to the delimiter.
        /// </summary>
        public PathHierarchyTokenizer Replacement(char replacement)
        {
            RegisterJsonPart("'replacement': {0}", replacement.ToString().Quotate());
            return this;
        }

        /// <summary>
        /// Sets the buffer size to use.
        /// Defaults to 1024.
        /// </summary>
        public PathHierarchyTokenizer BufferSize(int bufferSize = 1024)
        {
            RegisterJsonPart("'buffer_size': {0}", bufferSize.AsString());
            return this;
        }

        /// <summary>
        /// Sets flag controlling tokens generation in reverse order.
        /// Defaults to false.
        /// </summary>
        public PathHierarchyTokenizer Reverse(bool reverse = false)
        {
            RegisterJsonPart("'reverse': {0}", reverse.AsString());
            return this;
        }

        /// <summary>
        /// Sets number of initial tokens to skip.
        /// Defaults to 0.
        /// </summary>
        public PathHierarchyTokenizer Skip(int skip = 0)
        {
            RegisterJsonPart("'skip': {0}", skip.AsString());
            return this;
        }


        protected override string GetComponentType()
        {
            return DefaultTokenizers.path_hierarchy.AsString();
        }
    }
}