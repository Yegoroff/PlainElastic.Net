using System.Collections.Generic;

namespace PlainElastic.Net.Serialization
{
    public enum BulkOperationType { Index, Create, Delete, Unknown }

    public class BulkResult
    {
        public int took;

        public List<Operation> items;

        public class Operation
        {
            public OperationResult Result
            {
                get
                {
                    return index ?? create ?? delete;
                }
            }

            public BulkOperationType ResultType
            {
                get
                {
                    if (index != null)
                        return BulkOperationType.Index;
                    if (create != null)
                        return BulkOperationType.Create;
                    if (delete != null)
                        return BulkOperationType.Delete;
                    return BulkOperationType.Unknown;
                }
            }

            public OperationResult index;
            public OperationResult create;
            public OperationResult delete;
        }

        public class OperationResult
        {
            public string _index;
            public string _type;
            public string _id;
            public int _version;
            public int status;
            public bool? found;
            public string error;
        }

    }
}
