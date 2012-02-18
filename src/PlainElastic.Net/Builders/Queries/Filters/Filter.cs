using System;
using PlainElastic.Net.Queries;

namespace PlainElastic.Net.Queries
{
    public class Filter<T> : AbstractCompositeQuery<T>
    {

        protected override string QueryTemplate
        {
            get { return " 'filter': {{ {0} }}"; }
        }


        public Filter<T> And (Func<AndFilter<T>, Filter<T>> andFilter)
        {
            RegisterQueryAsJson(andFilter);
            return this;
        }

        public Filter<T> Term(Func<TermFilter<T>, TermFilter<T>> termFilter)
        {
            RegisterQueryAsJson(termFilter);
            return this;
        }

        public Filter<T> Exists(Func<ExistsFilter<T>, ExistsFilter<T>> existsFilter)
        {
            RegisterQueryAsJson(existsFilter);
            return this;
        }

    }
}