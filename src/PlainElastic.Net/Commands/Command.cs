namespace PlainElastic.Net
{
    public abstract class Command<T> where T: Command<T>
    {
        protected abstract T Instance { get; }



        public T FromIndex(string index)
        {

            return Instance;
        }

        public Command<T> OfType(string typeName)
        {
            return Instance;
        }

        public Command<T> OfType<TIndexType>()
        {
            return Instance;
        }

        public Command<T> Id(string id)
        {

            return Instance;
        }

        public static implicit operator string (Command<T> command)
        {
            return "";
        }
    }
}
