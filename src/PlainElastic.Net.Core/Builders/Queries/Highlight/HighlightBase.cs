using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// A base class for Match and Text queries.
    /// </summary>
    public abstract class HighlightBase<T, THighlight> : QueryBase<THighlight> where THighlight : HighlightBase<T, THighlight>
    {

        /// <summary>
        /// Set the post tags that will be used for highlighting.
        /// By default, the highlighting will wrap highlighted text in <em> and </em>.
        /// There can be a single tag or more, and the “importance” is ordered.
        /// </summary>
        public THighlight PreTags(params string[] preTags)
        {
            RegisterJsonPart("'pre_tags': [{0}]", preTags.Quotate().JoinWithComma());

            return (THighlight)this;
        }

        /// <summary>
        /// Set the post tags that will be used for highlighting.
        /// By default, the highlighting will wrap highlighted text in <em> and </em>
        /// There can be a single tag or more, and the “importance” is ordered.
        /// </summary>
        public THighlight PostTags(params string[] postTags)
        {
            RegisterJsonPart("'post_tags': [{0}]", postTags.Quotate().JoinWithComma());

            return (THighlight)this;
        }

        /// <summary>
        /// Set a tag scheme that encapsulates a built in pre and post tags. 
        /// </summary>
        public THighlight TagsSchema(HighlightTagsSchema tagsSchema)
        {
            RegisterJsonPart("'tags_schema': {0}", tagsSchema.AsString().Quotate());

            return (THighlight)this;
        }

        /// <summary>
        /// The order of fragments per field. By default, ordered by the order in the
        /// highlighted text. Can be "score", which then it will be ordered
        /// by score of the fragments.
        /// </summary>
        public THighlight Order(HighlightOrder order)
        {
            RegisterJsonPart("'order': {0}", order.AsString().Quotate());

            return (THighlight)this;
        }

        public THighlight HighlightFilter(bool highlightFilter)
        {
            RegisterJsonPart("'highlight_filter': {0}", highlightFilter.AsString());

            return (THighlight)this;
        }

        /// <summary>
        /// The size of the highlighted fragment in characters.
        /// Defaults to 100.
        /// </summary>
        public THighlight FragmentSize(int fragmentSize)
        {
            RegisterJsonPart("'fragment_size': {0}", fragmentSize.AsString());

            return (THighlight)this;
        }

        /// <summary>
        /// The maximum number of fragments to return.
        /// Defaults to 5.
        /// </summary>
        public THighlight NumberOfFragments(int numberOfFragments)
        {
            RegisterJsonPart("'number_of_fragments': {0}", numberOfFragments.AsString());

            return (THighlight)this;
        }

        /// <summary>
        /// Defines how highlighted text will be encoded.
        /// It can be either default (no encoding) or html (will escape html, if you use html highlighting tags).
        /// </summary>
        public THighlight Encoder(HighlightEncoder encoder)
        {
            RegisterJsonPart("'encoder': {0}", encoder.AsString().Quotate());

            return (THighlight)this;
        }

        /// <summary>
        /// Controls whether field to be highlighted only if a query matched that field.
        /// False means that terms are highlighted on all requested fields regardless if the query matches specifically on them.
        /// Defaults to false.
        /// </summary>
        public THighlight RequireFieldMatch(bool requireFieldMatch)
        {
            RegisterJsonPart("'require_field_match': {0}", requireFieldMatch.AsString());

            return (THighlight)this;
        }

        /// <summary>
        /// Allows to control how far to look for boundary characters.
        /// Defaults to 20
        /// </summary>
        public THighlight BoundaryMaxScan(int boundaryMaxScan)
        {
            RegisterJsonPart("'boundary_max_scan': {0}", boundaryMaxScan.AsString());

            return (THighlight)this;
        }

        /// <summary>
        /// Defines what constitutes a boundary for highlighting. 
        /// It’s a single string with each boundary character defined in it.
        /// Defaults to ".,!? t\n".
        /// </summary>
        public THighlight BoundaryChars(string boundaryChars)
        {
            RegisterJsonPart("'boundary_chars': {0}", boundaryChars.Quotate());

            return (THighlight)this;
        }

        /// <summary>
        /// Set type of highlighter to use. Supported types
        /// are "highlighter"(plain)  and "fast-vector-highlighter"(fvh).
        /// </summary>
        public THighlight Type(HighlighterType highlighterType)
        {
            RegisterJsonPart("'type': {0}", highlighterType.AsString().Quotate());

            return (THighlight)this;
        }

        /// <summary>
        /// Sets what fragmenter to use to break up text that is eligible for highlighting.
        /// This option is only applicable when using plain / normal highlighter.
        /// </summary>
        public THighlight Fragmenter(HighlightFragmenter fragmenter)
        {
            RegisterJsonPart("'fragmenter': {0}", fragmenter.AsString().Quotate());

            return (THighlight)this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

    }
}