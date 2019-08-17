using System.Linq;

namespace PlainElastic.Net.Utils
{
    public static class UrlBuilder
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
