namespace PlainElastic.Net.Mappings
{
    public enum TermVector { no, yes, with_offsets, with_positions, with_positions_offsets }

    public enum IndexState { analyzed, not_analyzed, no }

    public enum NumberMappingType { Float, Double, Integer, Long, Short, Byte };


    /// <summary>
    /// Analyzers that can be used in order to both break indexed (analyzed) fields when a document is indexed and process query strings.
    /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public enum DefaultAnalizers
    {
        standard,
        simple,
        whitespace,
        stop,
        reyword,
        pattern,
        language,
        snowball
    }
}