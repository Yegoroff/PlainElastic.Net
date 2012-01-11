using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainElastic.Net
{
    public class UrlBuilder
    {

        public static string BuildUrlPath(params string[] urlParts)
        {
            string path = urlParts.Where(p => !p.IsNullOrEmpty()).JoinWithSeparator("/");
            return path;
        }

        public static string AddParameter(string url, string paramName, string paramValue)
        {
             if (url.Contains('?'))
                 return "{0}&{1}={2}".F(url, paramName, paramValue);

             return "{0}?{1}={2}".F(url, paramName, paramValue);           
        }

    }
}
