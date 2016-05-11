using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainElastic.Net.Builders.Queries
{
    using System.Linq.Expressions;

    using PlainElastic.Net.Queries;
    using PlainElastic.Net.Utils;

    public class SourceQuery<T> : QueryBase<SourceQuery<T>>
    {
        /// <summary>
        /// Specified field to limit source to.
        /// </summary>
        /// <param name="field">The field.</param>
        public SourceQuery<T> Field(string field)
        {
            RegisterJsonPart(field.Quotate());
            return this;
        }

        /// <summary>
        /// Specified fields to limit source to.
        /// </summary>
        /// <param name="fields">The field.</param>
        public SourceQuery<T> Fields(string[] fields)
        {
            RegisterJsonPart("[ {0} ]", fields.Quotate().JoinWithComma());
            return this;
        }

        /// <summary>
        /// Specified fields to exclude from source.
        /// </summary>
        /// <param name="fields">The field.</param>
        public SourceQuery<T> Exclude(string[] fields)
        {
            RegisterJsonPart("{{ 'exclude': [ {0} ]}}", fields.Quotate().JoinWithComma());
            return this;
        }

        /// <summary>
        /// Specified field to exclude from source.
        /// </summary>
        /// <param name="fields">The field.</param>
        public SourceQuery<T> Exclude(string field)
        {
            RegisterJsonPart("{{ 'exclude': [ {0} ]}}", field.Quotate());
            return this;
        }

        /// <summary>
        /// Specified field to exclude from source.
        /// </summary>
        /// <param name="fields">The field.</param>
        public SourceQuery<T> Exclude(Expression<Func<T, object>> field)
        {
            var fieldName = field.GetPropertyPath();
            return Include(fieldName);
        }

        /// <summary>
        /// Specified fields to include to source.
        /// </summary>
        /// <param name="fields">The field.</param>
        public SourceQuery<T> Include(string[] fields)
        {
            RegisterJsonPart("{{ 'include': [ {0} ]}}", fields.Quotate().JoinWithComma());
            return this;
        }

        /// <summary>
        /// Specified field to include to source.
        /// </summary>
        /// <param name="field">The field.</param>
        public SourceQuery<T> Include(string field)
        {
            RegisterJsonPart("{{ 'include': [ {0} ]}}", field.Quotate());
            return this;
        }

        /// <summary>
        /// Specified field to include to source.
        /// </summary>
        /// <param name="field">The field.</param>
        public SourceQuery<T> Include(Expression<Func<T, object>> field)
        {
            var fieldName = field.GetPropertyPath();
            return Include(fieldName);
        }

        /// <summary>
        /// Determines whether this query/filter should generate any JSON.
        /// e.g. in case of "Term" query, if Value parameter not defined or empty -
        /// Term query will not be generated to JSON, 
        /// and empty string will be returned from ToJson/ToString call.
        /// Note: This check is not performed if there are no JSON parts registered.
        /// </summary>
        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'_source': {0} ".AltQuoteF(body);
        }
    }
}
