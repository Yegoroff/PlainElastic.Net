using System;

namespace PlainElastic.Net.QueryBuilder
{
    internal class Filter<T> : AbstractQuery<T>
    {

        #region Query Templates

        private const string filterTemplate = @"
    ""filter"": {{
{0}
    }}";

        #endregion


        public override string QueryTemplate
        {
            get { return filterTemplate; }
        }


        public Filter<T> And (Func<AndFilter<T>, Filter<T>> andFilter)
        {
            ExecuteAndRegisterQuery(andFilter);
            return this;
        }

        public Filter<T> Term(Func<TermFilter<T>, TermFilter<T>> termFilter)
        {
            ExecuteAndRegisterQuery(termFilter);
            return this;
        }

        public Filter<T> Exists(Func<ExistsFilter<T>, ExistsFilter<T>> existsFilter)
        {
            ExecuteAndRegisterQuery(existsFilter);
            return this;
        }

    }
}