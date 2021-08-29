using System;
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

    public class StatisticalFacetResult : FacetResult
    {
        public int count;
        public double? total;
        public double? min;
        public double? max;
        public double? mean;
        public double? sum_of_squares;
        public double? variance;
        public double? std_deviation;
    }

    public class TermsStatsFacetResult: FacetResult
    {
        public int missing;
        public List<Term> terms;

        public class Term
        {
            public string term;
            public int count;
            public int total_count;
            public double? min;
            public double? max;
            public double? total;
            public double? mean;
        }
    }

    public class GeoDistanceFacetResult: RangeFacetResult
    { }

    public class HistogramFacetResult: FacetResult
    {
        public List<Histogram> entries;

        public class Histogram
        {
            public long key;
            public long count;
        }
    }

    public class DateHistogramFacetResult: FacetResult
    {
        public List<DateHistogram> entries;

        public class DateHistogram
        {
            public long time;
            public long count;

            public DateTime UtcTime()
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return epoch.AddMilliseconds(time);
            }
        }
    }

}
