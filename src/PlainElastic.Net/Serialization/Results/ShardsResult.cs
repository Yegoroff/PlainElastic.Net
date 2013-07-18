namespace PlainElastic.Net.Serialization
{
    public class ShardsResult
    {
        public int total;
        public int successful;
        public int failed;
        public ShardFailure[] failures;
    }
}