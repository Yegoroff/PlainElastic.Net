using System;

namespace PlainElastic.Net
{
    public class OperationExeception : Exception
    {
        public OperationExeception(string message, int httpStatusCode, Exception innerException): base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }

        public int HttpStatusCode { get; private set; }
    }
}
