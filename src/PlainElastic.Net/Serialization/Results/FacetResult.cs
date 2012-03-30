using System.Collections.Generic;

namespace PlainElastic.Net.Serialization
{
    public class FacetResult
    {
        public string _type;


        public T As<T>() where T: FacetResult
        {
            return this as T;
        }
    }


    public class TermsFacetResult : FacetResult
    {
        public int total;
        public int missing;
        public int other;
        public List<Term> terms;

        public class Term
        {
            public string term;
            public int count;
        }
    }

    public class FilterFacetResult : FacetResult
    {
        public int count;
    }


}
