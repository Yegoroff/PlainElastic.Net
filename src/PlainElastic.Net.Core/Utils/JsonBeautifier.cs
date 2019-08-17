using System.Text;

namespace PlainElastic.Net
{
    public class JsonBeautifier
    {
        private const int IndentCount = 4;

        public static string Beautify(string str)
        {
            var indent = 0;
            var quoted = false;            
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            indent++;
                            sb.Append(' ', IndentCount * indent);
                        }
                        break;
                    
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            indent--;
                            sb.Append(' ', IndentCount * indent);
                        }
                        sb.Append(ch);
                        break;

                    case '"':
                        sb.Append(ch);
                        
                        bool escaped = false;
                        var index = i;

                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;

                        break;

                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            sb.Append(' ', IndentCount * indent);
                        }
                        break;

                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;

                    // Ignore spaces inside JSON
                    case ' ':
                    case '\r':
                    case '\n':
                    case '\t':
                        if (indent <= 0 || quoted )
                            sb.Append(ch);
                        break;

                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString(); ;
        }
    }
}
