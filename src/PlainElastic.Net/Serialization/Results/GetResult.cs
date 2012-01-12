namespace PlainElastic.Net.Serialization
{
    public class GetResult<T> : BaseResult

    {
        public string _index;
        
        public string _type;

        public string _id;

        public long _version;

        public bool exists;

        public T _source;
    }
}
