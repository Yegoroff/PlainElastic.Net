namespace PlainElastic.Net.Serialization
{
    public class IndexResult : BaseResult

    {
        public bool ok;

        public string _index;
        
        public string _type;

        public string _id;

        public long _version;
    }
}
