using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlainElastic.Net.Utils
{
    public static class StringExtensions
    {
        private static readonly Regex splitBySpaceAndCommaRegex = new Regex("(?:^|,|\\s)(\"(?:[^\"]+|\"\")*\"|[^,\\s]*)", RegexOptions.Compiled);


        public static string F(this string format, params object[] args)
        {
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


        public static bool IsNullOrEmpty(this string source)
        {
            return String.IsNullOrEmpty(source);
        }


        public static string ToCamelCase(this string value)
        {
            if (!Char.IsUpper(value, 0))
                return value;
            return Char.ToLower(value[0]) + value.Substring(1);
        }



        public static string Quotate(this string value)
        {
            return "\"" + value + "\"";
        }

        public static string LowerAndQuotate(this string value)
        {
            return value.ToLower().Quotate();
        }

        public static IEnumerable<string> Quotate(this IEnumerable<string> values)
        {
            return values.Select(v => v.Quotate());
        }




        public static string[] SplitByCommaAndSpaces(this string text)
        {
            // Split text by commas and spaces unless it quoted.
            var textsToSearch = from Match m in splitBySpaceAndCommaRegex.Matches(text)
                                where !(m.Value.Trim(' ', ',', '"').IsNullOrEmpty()) // skip empty matches..
                                select m.Value.Trim(' ', ',', '"');

            return textsToSearch.ToArray();
        }

        public static string JoinWithSeparator(this IEnumerable<string> list, string separator)
        {
            return list == null ? "" : String.Join(separator, list);
        }

        public static string JoinWithComma(this IEnumerable<string> list)
        {
            return list == null ? "" : String.Join(",", list);
        }



        public static string ButifyJson(this string json)
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
