using System.Collections.Generic;

namespace PlainElastic.Net.Serialization
{
    public class StatusResult
    {
        public ShardsResult _shards;
        public Dictionary<string, IndexStatus> indices;

    }

    public class IndexStatus
    {
        public IndexStats index;
        public TranslogStats translog;
        public DocsStats docs;
        public MergesStats merges;
        public RefreshStats refresh;
        public FlushStats flush;
        public Dictionary<int, ShardsStats[]> shards;
    }

    public class ShardsStats
    {
        public RoutingStats routing;
        public string state;
        public IndexStats index;
        public TranslogStats translog;
        public DocsStats docs;
        public MergesStats merges;
        public RefreshStats refresh;
        public FlushStats flush;
        public GatewayRecoveryStats gateway_recovery;
        public GatewaySnapshotStats gateway_snapshot;
    }

    public class GatewaySnapshotStats
    {
        public string stage;
        public long start_time_in_millis;
        public string time;
        public string time_in_millis;
        public SnapshotIndexStats index;
        public SnapshotTranslogStats translog;
    }

    public class SnapshotTranslogStats
    {
        public int expected_operations;
    }

    public class SnapshotIndexStats
    {
        public string size;
        public long size_in_bytes;
    }

    public class GatewayRecoveryStats
    {
        public string stage;
        public long start_time_in_millis;
        public string time;
        public string time_in_millis;
        public RecoveryIndexStats index;
        public RecoveryTranslogStats translog;
    }

    public class RecoveryTranslogStats
    {
        public int recovered;
    }

    public class RecoveryIndexStats
    {
        public int progress;
        public string size;
        public long size_in_bytes;
        public string reused_size;
        public long reused_size_in_bytes;
        public string expected_recovered_size;
        public long expected_recovered_size_in_bytes;
        public string recovered_size;
        public long recovered_size_in_bytes;
    }

    public class RoutingStats
    {
        public string state;
        public bool primary;
        public string node;
        public string relocating_node;
        public int shard;
        public string index;
    }

    public class FlushStats
    {
        public int total;
        public string total_time;
        public string total_time_in_millis;
    }

    public class RefreshStats
    {
        public int total;
        public string total_time;
        public string total_time_in_millis;
    }

    public class MergesStats
    {
        public int current;
        public int current_docs;
        public string current_size;
        public long current_size_in_bytes;
        public int total;
        public string total_time;
        public int total_time_in_millis;
        public int total_docs;
        public string total_size;
        public long total_size_in_bytes;
    }

    public class DocsStats
    {
        public int num_docs;
        public int max_doc;
        public int deleted_docs;
    }

    public class TranslogStats
    {
        public string id;
        public int operations;
    }

    public class IndexStats
    {
        public string primary_size;
        public long primary_size_in_bytes;
        public string size;
        public long size_in_bytes;
    }
}
