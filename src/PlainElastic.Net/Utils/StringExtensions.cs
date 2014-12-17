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
        /// Provide string formatting alongside 
        /// with replacing ' by " quotation sign in passed format.
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
        /// Replaces ' by " quotation sign and ` by '.
        /// Useful for JSON declarations.
        /// </summary>
        public static string AltQuote(this string quotedString)
        {
            return quotedString.Replace('\'', '\"').Replace("`", "\'");
        }

        /// <summary>
        /// Quotates the specified value and escapes special JSON chars.
        /// </summary>
        public static string Quotate(this string value)
        {
            return ToEscapedJson(value);
        }

        /// <summary>
        /// Quotates the specified values and escapes special JSON chars.
        /// </summary>
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

            if (batch.Length > 0)
                yield return batch.ToString();
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

        public static string AsString(this Enum value)
        {
            return value.ToString("F").Replace(", ", "|");;
        }

        public static string AsString(this DateTime date)
        {
            return date.ToString("s");
        }

        public static string AsString(this DateTime? date)
        {
            return date.HasValue ? date.Value.AsString() : null;
        }

        public static string AsString(this Guid guid)
        {
            return guid.ToString();
        }

        public static string AsString(this Guid? guid)
        {
            return guid.HasValue ? guid.Value.AsString() : null;
        }

        public static IEnumerable<string> AsStrings(this IEnumerable<Guid> source)
        {
            return (source ?? Enumerable.Empty<Guid>()).Select(AsString);
        }

        public static IEnumerable<string> AsStrings(this IEnumerable<long> source)
        {
            return (source ?? Enumerable.Empty<long>()).Select(x => x.AsString());
        }

        public static string BeautifyJson(this string json)
        {
            return JsonBeautifier.Beautify(json);
        }

        public static string ToEscapedJson(this string json)
        {
            if (json.IsNullOrEmpty() || !HasAnyJsonEscapeChars(json))
                return "\"" + json + "\"";

            int length = json.Length;
            var builder = new StringBuilder(length + 10);
            builder.Append("\"");

            var hex = new[] { '\\', 'u', '0', '0', '0', '0' };

            for (int i = 0; i < length; i++)
            {
                var symbol = json[i];

                if (symbol >= 32 && symbol < 128 && symbol != '\\' && symbol != '"')
                {
                    builder.Append(symbol);
                    continue;
                }

                switch (symbol)
                {
                    case '\t':
                        builder.Append(@"\t");
                        continue;
                    case '\n':
                        builder.Append(@"\n");
                        continue;
                    case '\r':
                        builder.Append(@"\r");
                        continue;
                    case '\f':
                        builder.Append(@"\f");
                        continue;
                    case '\b':
                        builder.Append(@"\b");
                        continue;
                    case '\\':
                        builder.Append(@"\\");
                        continue;
                    case '\u0085': // Next Line
                        builder.Append(@"\u0085");
                        continue;
                    case '\u2028': // Line Separator
                        builder.Append(@"\u2028");
                        continue;
                    case '\u2029': // Paragraph Separator
                        builder.Append(@"\u2029");
                        continue;
                    case '"':
                        builder.Append("\\\"");
                        continue;
                    default:
                        if (symbol <= '\u001f')
                        {
                            CharToUniHex(symbol, hex);
                            builder.Append(hex);
                        }
                        else
                            builder.Append(symbol);
                        break;
                }
            }

            builder.Append("\"");
            return builder.ToString();
        }

        private static bool HasAnyJsonEscapeChars(string value)
        {
            var length = value.Length;
            for (int i = 0; i < length; i++)
            {
                var symbol = value[i];
                if(symbol <= '\u001f')
                    return true;

                switch (symbol)
                {
                    case '\n':
                    case '\r':
                    case '\t':
                    case '\\':
                    case '\f':
                    case '\b':
                    case '"':
                    case '\u0085':
                    case '\u2028':
                    case '\u2029':
                        return true;
                }
            }
            return false;
        }


        private static void CharToUniHex(int intSymbol, char[] hex)
        {
            for (int i = 0; i < 2; i++)
            {
                int digit = intSymbol & 0x0f;
                if (digit < 10)
                    hex[5 - i] = (char)('0' + digit);
                else
                    hex[5 - i] = (char)('a' + (digit - 10));

                intSymbol >>= 4;
            }
        }




    }
}
