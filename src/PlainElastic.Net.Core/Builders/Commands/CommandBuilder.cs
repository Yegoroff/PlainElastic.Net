using System.Linq;
using System.Collections.Generic;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    public abstract class CommandBuilder<T> where T: CommandBuilder<T>
    {

        public readonly List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();


        public T WithParameter(string name, string value)
        {
            Parameters.Add(new KeyValuePair<string, string>(name, value));
            return (T)this;
        }

        public T Pretty()
        {
            this.WithParameter("pretty", "true");
            return (T)this;
        }


        public string BuildCommand()
        {
            string path = BuildUrlPath().ToLower();
            string queryParams = Parameters.Select(param => param.Key + "=" + param.Value).JoinWithSeparator("&");
            
            if (!queryParams.IsNullOrEmpty())
                return path + "?" + queryParams;

            return path;
        }


        protected abstract string BuildUrlPath();



        public override string ToString()
        {
            return BuildCommand();
        }

        public static implicit operator string (CommandBuilder<T> command)
        {
            return command.BuildCommand();
        }
    }
}
