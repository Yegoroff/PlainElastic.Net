using System;

namespace PlainElastic.Net
{
    public class OperationExeception : Exception
    {
        public OperationExeception(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}
