using System;
using PlainElastic.Net.Utils;


namespace PlainElastic.Net.Queries
{

    /// <summary>
    /// The has_parent query accepts a query and the parent type to run against,
    /// The query is executed in the parent document space, which is specified by the parent type. 
    /// This query return child documents which associated parents have matched.
    /// see: http://www.elasticsearch.org/guide/reference/query-dsl/has-parent-query/
    /// </summary>
    public class HasParentQuery<T, TParent> : QueryBase<HasParentQuery<T, TParent>>
    {
        private bool hasValues;

        /// <summary>
        /// The parent type to query against. 
        /// The parent type to return is automatically detected based on the mappings.
        /// </summary>
        public HasParentQuery<T, TParent> ParentType(string parentType)
        {
            RegisterJsonPart("'parent_type': {0}", parentType.Quotate());
            return this;
        }

        /// <summary>
        /// The score type for the has_parent query.
        /// The supported score types are "score" or "none". The default is "none" and this ignores the score from the parent document. 
        /// The score is in this case equal to the boost on the has_parent query (Defaults to 1).
        /// If the score type is set to "score", then the score of the matching parent document is aggregated into the child documents belonging to the matching parent document.
        /// </summary>
        public HasParentQuery<T, TParent> ScoreType(HasParentScoreType scoreType)
        {
            RegisterJsonPart("'score_type': {0}", scoreType.AsString().Quotate());
            return this;
        }


        /// <summary>
        /// The query to run against parents documents.
        /// </summary>
        public HasParentQuery<T, TParent> Query(Func<Query<TParent>, Query<TParent>> query)
        {
            var result = RegisterJsonPartExpression(query);
            hasValues = hasValues || !result.GetIsEmpty();
            return this;
        }

        /// <summary>
        /// Sets the boost value of the query. Defaults to 1.0.
        /// </summary>
        public HasParentQuery<T, TParent> Boost(double boost = 1)
        {
            RegisterJsonPart("'boost': {0}", boost.AsString());

            return this;
        }


        protected override bool HasRequiredParts()
        {
            return hasValues;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "{{ 'has_parent': {{ {0} }} }}".AltQuoteF(body);
        }
    }
}