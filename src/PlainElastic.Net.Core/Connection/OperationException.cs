using System;

namespace PlainElastic.Net
{
    public class OperationException : Exception
    {
        public OperationException(string message, int httpStatusCode, Exception innerException): base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }

        public int HttpStatusCode { get; private set; }
    }
}
