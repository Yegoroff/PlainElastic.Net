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

    public class RangeFacetResult : FacetResult
    {
        public List<Range> ranges;

        public class Range
        {
            public double? from;
            public double? to;
            public int? count;
            public double? min;
            public double? max;
            public int? total_count;
            public double? total;
            public double? mean;
        }
    }

    public class FilterFacetResult : FacetResult
    {
        public int count;
    }
}
