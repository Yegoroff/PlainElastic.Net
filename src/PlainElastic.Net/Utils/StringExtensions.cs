using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace PlainElastic.Net.Utils
{
    public static class StringExtensions
    {
        public static string F(this string format, params object[] args)
        {
            if (args == null || !args.Any())
                return format;

            return String.Format(format, args);
        }

        /// <summary>
        /// Provide string formatting alongside with replacing ' by " quotation sign.
        /// </summary>
        public static string AltQuoteF(this string format, params object[] args)
        {
            if (format.IsNullOrEmpty())
                return null;

            format = format.AltQuote();

            if (args == null || args.Length == 0)
                return format;

            return String.Format(format, args);
        }

        /// <summary>
        /// Replaces ' by " quotation sign.
        /// </summary>
        public static string AltQuote(this string quotedString)
        {
            return quotedString.Replace('\'', '\"');
        }

        public static string Quotate(this string value)
        {
            if (value.IsNullOrEmpty())
                return "";

            return JsonConvert.ToString(value);
        }

        public static IEnumerable<string> Quotate(this IEnumerable<string> values)
        {
            return values.Select(v => v.Quotate());
        }


        public static bool IsNullOrEmpty(this string source)
        {
            return String.IsNullOrEmpty(source);
        }


        public static string Join(this IEnumerable<string> list)
        {
            return list == null ? "" : String.Join("", list);
        }


        public static string JoinWithSeparator(this IEnumerable<string> list, string separator)
        {
            return list == null ? "" : String.Join(separator, list);
        }

        public static string JoinWithComma(this IEnumerable<string> list)
        {
            return list == null ? "" : String.Join(",", list);
        }

        public static IEnumerable<string> JoinInBatches(this IEnumerable<string> list, int batchSize)
        {
            if (list == null)
                yield break;

            StringBuilder batch = new StringBuilder(batchSize * 30);
            int i = 0;
            foreach (var value in list)
            {
                batch.Append(value);
                i++;

                if (i == batchSize)
                {
                    yield return batch.ToString();
                    i = 0;
                    batch.Clear();
                }
            }

            yield return batch.ToString();
        }

        public static string BeautifyJson(this string json)
        {
            return JsonBeautifier.Beautify(json);
        }


        public static string AsString(this bool value)
        {
            return value.ToString(CultureInfo.InvariantCulture).ToLower();
        }

        public static string AsString(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static string AsString(this int value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public static string AsString(this long value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }


        public static string AsString(this bool? value)
        {
            return value.HasValue ? value.Value.AsString(): null;
        }

        public static string AsString(this double? value)
        {
            return value.HasValue ? value.Value.AsString() : null;
        }

        public static string AsString(this int? value)
        {
            return value.HasValue ? value.Value.AsString() : null;
        }

        public static string AsString(this long? value)
        {
            return value.HasValue ? value.Value.AsString() : null;
        }


    }
}
