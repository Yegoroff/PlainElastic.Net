using System;

namespace PlainElastic.Net.QueryBuilder
{
    public class Filter<T> : AbstractCompositeQuery<T>
    {

        private const string filterTemplate = " \"filter\": {{ {0} }}";


        protected override string QueryTemplate
        {
            get { return filterTemplate; }
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