using System;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    public enum GetPrefernce {_primary, _local, custom };


    public class GetCommandBuilder : CommandBuilder<GetCommandBuilder>
    {
        public string Index { get; private set; }

        public string Type { get; private set; }

        public string Id { get; private set; }


        public GetCommandBuilder(string index = null, string type = null, string id = null)
        {
            Index = index;
            Type = type;
            Id = id;
        }


        #region Query Parameters

        public GetCommandBuilder Fields(string fields)
        {
            Parameters.Add("fields", fields);
            return this;
        }

        public GetCommandBuilder Fields<T>(params Expression<Func<T, object>>[] properties)
        {
            string fields = properties.Select(prop => prop.GePropertyName()).JoinWithComma();
            Parameters.Add("fields", fields);
            return this;
        }

        public GetCommandBuilder Preference(GetPrefernce prefernce, string customPreference = null)
        {
            string value = prefernce.ToString();
            if (prefernce == GetPrefernce.custom)
                value = customPreference;

            if (!value.IsNullOrEmpty())
                Parameters.Add("preference", value);

            return this;
        }

        public GetCommandBuilder Realtime(bool realtime)
        {
            Parameters.Add("realtime", realtime.AsString());
            return this;
        }

        public GetCommandBuilder Refresh(bool refresh)
        {
            Parameters.Add("refresh", refresh.AsString());
            return this;
        }

        public GetCommandBuilder Routing(string routing)
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