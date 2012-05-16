using System;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to get a typed JSON document from the index based on its id.
    /// http://www.elasticsearch.org/guide/reference/api/get.html
    /// </summary>
    public class GetCommand : CommandBuilder<GetCommand>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }

        public string Id { get; private set; }


        public GetCommand(string index = null, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        public GetCommand Fields(string fields)
        {
            Parameters.Add("fields", fields);
            return this;
        }

        public GetCommand Fields<T>(params Expression<Func<T, object>>[] properties)
        {
            string fields = properties.Select(prop => prop.GetPropertyPath()).JoinWithComma();
            Parameters.Add("fields", fields);
            return this;
        }

        public GetCommand Preference(GetPrefernce prefernce, string customPreference = null)
        {
            string value = prefernce.AsString();
            if (prefernce == GetPrefernce.custom)
                value = customPreference;

            if (!value.IsNullOrEmpty())
                Parameters.Add("preference", value);

            return this;
        }

        public GetCommand Realtime(bool realtime = true)
        {
            Parameters.Add("realtime", realtime.AsString());
            return this;
        }

        public GetCommand Refresh(bool refresh = true)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        public GetCommand Routing(string routing)
        {
            Parameters.Add("routing", routing);
            return this;
        }

        #endregion


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Index, Type, Id);
        }

    }
}