namespace PlainElastic.Net.Serialization
{
    public class IndexResult : BaseResult
    {
        public string _index;
        
        public string _type;

        public string _id;

        public long _version;

        public bool created;
    }
}
