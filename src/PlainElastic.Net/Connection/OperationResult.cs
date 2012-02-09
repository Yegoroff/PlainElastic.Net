namespace PlainElastic.Net
{
    // Actually result is string, so if everything ok - the result will be returned as command execution result, otherwise exception.
    // This type used mainly to distinguish operation result functionality from usual string.
    public class OperationResult
    {
        public OperationResult(string result)
        {
            Result = result;
        }

        public string Result { get; private set; }


        public static implicit operator string (OperationResult value)
        {
            return value.Result;
        }

        public override string ToString()
        {
            return Result;
        }
    }
}
