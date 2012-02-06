using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.QueryBuilder
{
    public enum Rewrite { ConstantScoreDefault, ScoringBoolean, ConstantScoreBoolean, ConstantScoreFilter, TopTermsN, TopTermsBoostN }


    public class QueryString<T> : IJsonConvertible
    {

        #region Query Templates

        private const string mainTemplate =         "{{ \"query_string\": {{ {0} }} }}";

        private const string defaultFieldTemplate = " \"default_field\": {0}";
        private const string boostTemplate =        " \"boost\": {0}";
        private const string rewriteTemplate =      " \"rewrite\": {0}";
        private const string queryTemplate =        " \"query\": {0}";
        private const string fieldsTemplate =       " \"fields\": [{0}]";

        #endregion


        private readonly List<string> queryFields = new List<string>();

        private readonly List<string> queryParts = new List<string>();

        private string queryValue;



        public QueryString<T> DefaultField(Expression<Func<T, object>> field)
        {
            var defaultField = field.GetQuotatedPropertyName();
            var defaultPart = defaultFieldTemplate.F(defaultField);

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

            queryValue = queryTemplate.F(fullTextQuery);

            queryParts.Add(queryValue);

            return this;
        }

        public QueryString<T> Boost(double boost)
        {
            var boostPart = boostTemplate.F(boost.ToString());
            queryParts.Add(boostPart);

            return this;
        }

        public QueryString<T> Rewrite(Rewrite rewrite, int n = 0)
        {
            var rewriteValue = GetRewriteValue(rewrite, n).Quotate();
            var rewritePart = rewriteTemplate.F(rewriteValue);

            queryParts.Add(rewritePart);

            return this;
        }




        private static string GetRewriteValue(Rewrite rewrite, int n)
        {            
            switch(rewrite)
            {
                case QueryBuilder.Rewrite.ConstantScoreDefault:
                    return "constant_score_default";

                case QueryBuilder.Rewrite.ConstantScoreBoolean:
                    return "constant_score_boolean";

                case QueryBuilder.Rewrite.ConstantScoreFilter:
                    return "constant_score_filter";

                case QueryBuilder.Rewrite.ScoringBoolean:
                    return "scoring_boolean";

                case QueryBuilder.Rewrite.TopTermsBoostN:
                    return "top_terms_boost_" + n;

                case QueryBuilder.Rewrite.TopTermsN:
                    return "top_terms_" + n;
            }
            return "";
        }


        private string GenerateFieldsQueryPart()
        {
            var fields = queryFields.JoinWithComma();
            var fieldPart = fieldsTemplate.F(fields);
            return fieldPart;
        }


        string IJsonConvertible.ToJson()
        {
            if (queryValue.IsNullOrEmpty())
                return "";

            queryParts.Insert(0, GenerateFieldsQueryPart());

            var body = queryParts.JoinWithSeparator(", ");
            var result = mainTemplate.F(body);

            return result;
        }
    }
}