namespace PlainElastic.Net
{
    public enum GetPrefernce { _primary, _local, custom };

    public enum IndexOperation { create };

    public enum PercolateMode { All, Color }

    public enum WriteConsistency { one, quorum, all }

    public enum DocumentReplication { sync, async }

    public enum SortDirection { @default, asc, desc }

    public enum SearchType { query_and_fetch, query_then_fetch, dfs_query_and_fetch, dfs_query_then_fetch, count, scan }

    public enum VersionType { @internal, external }

    public enum IgnoreIndicesOption { none, missing }

}