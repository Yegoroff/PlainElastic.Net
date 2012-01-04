using System;

namespace PlainElastic.Net.QueryBuilder
{
    internal class AndFilter<T> : Filter<T>
    {

        #region Query Templates

        private const string filterTemplate = @"
    ""and"": [ 
{0}
    ]";

        #endregion


        public override string QueryTemplate
        {
            get { return filterTemplate; }
        }

    }
}