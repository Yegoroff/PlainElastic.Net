using System.Collections.Generic;

namespace PlainElastic.Net.Serialization
{
    public class FacetResult
    {
        public string _type;
        public int total;
        public int missing;
        public int other;

        public T As<T>() where T: FacetResult
        {
            return this as T;
        }
    }


    public class TermsFacetResult : FacetResult
    {
        public List<Term> terms;

        public class Term
        {
            public string term;
            public int count;
        }
    }
}
