using System.Collections.Generic;
using System.Linq;

namespace PlainElastic.Net.Utils
{
    public static class JsonHelper
    {

        public static string BuildJsonStringsProperty(string name, IEnumerable<string> values)
        {
            if (values == null)
                return null;

            var valuesJson = values.Where(v => !v.IsNullOrEmpty()).Quotate().JoinWithComma();
            return "{0}: [ {1} ]".F(name.Quotate(), valuesJson);
        }

    }
}
