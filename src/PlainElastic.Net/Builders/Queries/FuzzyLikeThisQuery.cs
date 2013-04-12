using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Fuzzy like this query find documents that are “like” provided text by running it against one or more fields.
    /// see http://www.elasticsearch.org/guide/reference/query-dsl/flt-query.html
    /// </summary>
    public class FuzzyLikeThisQuery<T> : QueryBase<FuzzyLikeThisQuery<T>>
    {

        private readonly List<string> queryFields = new List<string>();

        private bool hasValue;


        /// <summary>
        /// A list of the fields to run the fuzzy like this query against.
        /// Defaults to the _all field.
        /// </summary>
        public FuzzyLikeThisQuery<T> Fields(params string[] fields)
        {
            queryFields.AddRange(fields);
            return this;
        }

        /// <summary>
        /// A list of the fields to run the fuzzy like this query against.
        /// Defaults to the _all field.
        /// </summary>
        public FuzzyLikeThisQuery<T> Fields(params Expression<Func<T, object>>[] fields)
        {
            foreach (var field in fields)
                queryFields.Add(field.GetPropertyPath());

            return this;
        }

        /// <summary>
        /// A list of the fields to run the fuzzy like this query against.
        /// Defaults to the _all field.
        /// </summary>
        public FuzzyLikeThisQuery<T> FieldsOfCollection<TProp>(Expression<Func<T, IEnumerable<TProp>>> collectionField, params Expression<Func<TProp, object>>[] fields)
        {
            var collectionProperty = collectionField.GetPropertyPath();

            foreach (var field in fields)
            {
                var fieldName = collectionProperty + "." + field.GetPropertyPath();
                queryFields.Add(fieldName);
            }
            return this;
        }

        /// <summary>
        /// The text to use in order to find documents that are "like" this.
        /// </summary>
        public FuzzyLikeThisQuery<T> LikeText(string likeText)
        {
            if (likeText.IsNullOrEmpty())
                return this;
             
            RegisterJsonPart("'like_text': {0}", likeText.Quotate());
            hasValue = true;
            return this;
        }

        /// <summary>
        /// Should term frequency be ignored. Defaults to false.
        /// </summary>
        public FuzzyLikeThisQuery<T> IgnoreTf(bool ignoreTf = false)
        {
            RegisterJsonPart("'ignore_tf': {0}", ignoreTf.AsString());
            return this;
        }

        /// <summary>
        /// The maximum number of query terms that will be included in any generated query.
        /// Defaults to 25.
        /// </summary>
        public FuzzyLikeThisQuery<T> MaxQueryTerms(int maxQueryTerms = 25)
        {
            RegisterJsonPart("'max_query_terms': {0}", maxQueryTerms.AsString());
            return this;
        }

        /// <summary>
        /// The minimum similarity of the term variants. Defaults to 0.5.
        /// </summary>
        public FuzzyLikeThisQuery<T> MinSimilarity(double minSimilarity = 0.5)
        {
            RegisterJsonPart("'min_similarity': {0}", minSimilarity.AsString());
            return this;
        }

        /// <summary>
        /// Length of required common prefix on variant terms. Defaults to 0.
        /// </summary>
        public FuzzyLikeThisQuery<T> PrefixLength(int prefixLength = 0)
        {
            RegisterJsonPart("'prefix_length': {0}", prefixLength.AsString());
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public FuzzyLikeThisQuery<T> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public FuzzyLikeThisQuery<T> Analyzer(string analyzer)
        {
            RegisterJsonPart("'analyzer': {0}", analyzer.Quotate());
            return this;
        }

        /// <summary>
        /// The analyzer that will be used to analyze the text. Defaults to the analyzer associated with the field.
        /// see: http://www.elasticsearch.org/guide/reference/index-modules/analysis/
        /// </summary>
        public FuzzyLikeThisQuery<T> Analyzer(DefaultAnalyzers analyzer)
        {
            return Analyzer(analyzer.AsString());
        }


        protected override bool HasRequiredParts()
        {
            return hasValue;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            if (queryFields.Count > 0)
            {
                string fields = JsonHelper.BuildJsonStringsProperty("fields", queryFields);
                body = new[] { fields, body }.JoinWithComma();
            }

            return "{{ 'fuzzy_like_this': {{ {0} }} }}".AltQuoteF(body);
        }

    }
}