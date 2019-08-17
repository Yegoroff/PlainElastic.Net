﻿using PlainElastic.Net.Utils;

namespace PlainElastic.Net
{
    /// <summary>
    /// Builds a command that allows to retrieve mapping definition of index or index/type.
    /// To get mappings for all indices you can use _all for "index"
    /// http://www.elasticsearch.org/guide/reference/api/admin-indices-get-mapping.html
    /// </summary>
    public class GetMappingCommand: CommandBuilder<GetMappingCommand>
    {
        public string Indexes { get; private set; }

        public string Types { get; private set; }


        public GetMappingCommand(string index = null, string type = null)
        {
            Indexes = index;
            Types = type;
        }

        public GetMappingCommand(string[] indexes, string[] types = null)
        {
            Indexes = indexes.JoinWithComma();
            Types = types.JoinWithComma();
        }


        protected override string BuildUrlPath()
        {
            return UrlBuilder.BuildUrlPath(Indexes, Types, "_mapping");
        }
    }
}
