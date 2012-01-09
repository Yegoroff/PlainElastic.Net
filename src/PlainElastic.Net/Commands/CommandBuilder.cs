using System.Linq;
using System.Collections.Generic;

namespace PlainElastic.Net
{
    public abstract class CommandBuilder<T> where T: CommandBuilder<T>
    {

        public readonly Dictionary<string, string> Parameters = new Dictionary<string, string>();


        public string Index { get; private set; }

        public string Type { get; private set; }



        public T ForIndex(string index)
        {
            Index = index;
            return (T)this;
        }

        public T OfType(string typeName)
        {
            Type = typeName;
            return (T)this;
        }

        public T OfType<TIndexType>()
        {
            Type = typeof(TIndexType).Name.ToLower();
            return (T)this;
        }

        public T AllTypes()
        {
            Type = "_all";
            return (T)this;            
        }

        public T WithParameter(string name, string value)
        {
            Parameters[name] = value;
            return (T)this;
        }


        public string BuildCommand()
        {
            string path = BuildPath().ToLower();
            string queryParams = Parameters.Select(param => param.Key + "=" + param.Value).JoinWithSeparator("&");
            
            if (!queryParams.IsNullOrEmpty())
                return path + "?" + queryParams;

            return path;
        }


        protected virtual string BuildPath()
        {
            if (!Index.IsNullOrEmpty())
            {
                if (!Type.IsNullOrEmpty())
                    return "/{0}/{1}".F(Index, Type);

                return "/"+ Index;
            }
            return "";
        }


        public static implicit operator string (CommandBuilder<T> command)
        {
            return command.BuildCommand();
        }
    }
}
