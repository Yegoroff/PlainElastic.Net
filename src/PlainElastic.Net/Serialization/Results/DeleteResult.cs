namespace PlainElastic.Net.Serialization
{
    public class DeleteResult : BaseResult
    {
        public bool acknowledged;

        public string _index;
        
        public string _type;
        
        public string _id;

        public int _version;

        public bool found;
    }
}
