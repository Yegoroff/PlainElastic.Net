using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Builders.Queries
{
    public class Partial<T> : QueryBase<Partial<T>>
    {
        private string _partialName;

        public Partial<T> PartialName(string name)
        {
            _partialName = name.Quotate();

            return this;
        }

        public Partial<T> IncludeFields(params string[] fields)
        {
            RegisterFields("include", fields);

            return this;
        }

        public Partial<T> IncludeFields(params Expression<Func<T, object>>[] fields)
        {
            IncludeFields(fields.Select(x => x.GetQuotatedPropertyPath()).ToArray());

            return this;
        }

        public Partial<T> IncludeFieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyPath();

            IncludeFields(fields.Select(f => collectionProperty + "." + f.GetPropertyPath()).ToArray());

            return this;
        }

        public Partial<T> ExcludeFields(params string[] fields)
        {            
            RegisterFields("exclude", fields);

            return this;
        }

        public Partial<T> ExcludeFields(params Expression<Func<T, object>>[] fields)
        {
            ExcludeFields(fields.Select(x => x.GetPropertyPath()).ToArray());

            return this;
        }

        public Partial<T> ExcludeFieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyPath();

            ExcludeFields(fields.Select(f => collectionProperty + "." + f.GetPropertyPath()).ToArray());

            return this;
        }

        private void RegisterFields(string operation, params string[] fields)
        {
            var fieldsString = fields.Select(f => f.Quotate()).JoinWithComma();
            RegisterJsonPart("'{0}': [ {1} ]", operation, fieldsString);
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{0}: {{ {1} }}".AltQuoteF(_partialName, body);
        }
    }
}