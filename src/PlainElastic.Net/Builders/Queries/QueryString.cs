using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    public enum Rewrite { ConstantScoreDefault, ScoringBoolean, ConstantScoreBoolean, ConstantScoreFilter, TopTermsN, TopTermsBoostN }


    public class QueryString<T> : IJsonConvertible
    {

        private readonly List<string> queryFields = new List<string>();

        private readonly List<string> queryParts = new List<string>();

        private string queryValue;



        public QueryString<T> DefaultField(Expression<Func<T, object>> field)
        {
            var defaultField = field.GetQuotatedPropertyName();
            var defaultPart = " 'default_field': {0}".SmartQuoteF(defaultField);

            queryParts.Add(defaultPart);

            return this;
        }

        public QueryString<T> Fields(params Expression<Func<T, object>> [] fields)
        {
            foreach (var field in fields)
                queryFields.Add(field.GetQuotatedPropertyName());

            return this;
        }

        public QueryString<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyName();

            foreach (var field in fields)
            {
                var fieldName = collectionProperty + "." + field.GetPropertyName();
                fieldName = fieldName.Quotate();
                queryFields.Add(fieldName);
            }

            return this;
        }

        public QueryString<T> Query(string value, bool wrapInWildcard = false)
        {
            if (value.IsNullOrEmpty())
                return this;

            var values = value.SplitByCommaAndSpaces();

            if (wrapInWildcard)
                values = values.Select(v => "*" + v + "*").ToArray();

            var fullTextQuery = values.JoinWithSeparator(" ").LowerAndQuotate();

            queryValue = " 'query': {0}".SmartQuoteF(fullTextQuery);

            queryParts.Add(queryValue);

            return this;
        }

        public QueryString<T> Boost(double boost)
        {
            var boostPart = " 'boost': {0}".SmartQuoteF(boost.AsString());
            queryParts.Add(boostPart);

            return this;
        }

        public QueryString<T> Rewrite(Rewrite rewrite, int n = 0)
        {
            var rewriteValue = GetRewriteValue(rewrite, n).Quotate();
            var rewritePart = " 'rewrite': {0}".SmartQuoteF(rewriteValue);

            queryParts.Add(rewritePart);

            return this;
        }


        private static string GetRewriteValue(Rewrite rewrite, int n)
        {            
            switch(rewrite)
            {
                case Queries.Rewrite.ConstantScoreDefault:
                    return "constant_score_default";

                case Queries.Rewrite.ConstantScoreBoolean:
                    return "constant_score_boolean";

                case Queries.Rewrite.ConstantScoreFilter:
                    return "constant_score_filter";

                case Queries.Rewrite.ScoringBoolean:
                    return "scoring_boolean";

                case Queries.Rewrite.TopTermsBoostN:
                    return "top_terms_boost_" + n;

                case Queries.Rewrite.TopTermsN:
                    return "top_terms_" + n;
            }
            return "";
        }


        private string GenerateFieldsQueryPart()
        {
            var fields = queryFields.JoinWithComma();
            var fieldPart = " 'fields': [{0}]".SmartQuoteF(fields);
            return fieldPart;
        }


        string IJsonConvertible.ToJson()
        {
            if (queryValue.IsNullOrEmpty())
                return "";

            queryParts.Insert(0, GenerateFieldsQueryPart());

            var body = queryParts.JoinWithSeparator(", ");
            var result = "{{ 'query_string': {{ {0} }} }}".SmartQuoteF(body);

            return result;
        }
    }
}