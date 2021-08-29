namespace PlainElastic.Net.Serialization
{
    public class ShardFailure
    {
        public string index;
        public int shard;
        public int status;
        public string reason;
    }
}