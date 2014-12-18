namespace PlainElastic.Net.Serialization
{
    public class GetResult<T> : BaseResult

    {
        public string _index;
        
        public string _type;

        public string _id;

        public long _version;

        public bool found;

        public T _source;

        public T Document { get { return _source; } }
    }
}
