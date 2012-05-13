namespace PlainElastic.Net.Mappings
{
    public enum TermVector { no, yes, with_offsets, with_positions, with_positions_offsets }

    public enum IndexState { analyzed, not_analyzed, no }

    public enum NumberMappingType { Float, Double, Integer, Long, Short, Byte };
}