using System;
using System.Collections.Generic;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class QueryBase<TPart> : IJsonConvertible where TPart : QueryBase<TPart>
    {

        private readonly List<string> jsonParts = new List<string>();


        public IEnumerable<string> JsonParts { get { return jsonParts; } }

        protected bool HasCustomPatrs { get; private set; }


        /// <summary>
        /// Adds a custom part to Query or Filter.
        /// </summary>
        public TPart Custom(string partFormat, params string[] args)
        {
            if (partFormat.IsNullOrEmpty())
                return (TPart)this;

            var json = partFormat.F(args);
            AddJsonPart(json);

            HasCustomPatrs = true;
            return (TPart)this;
        }



        protected void RegisterJsonPart(string jsonPart, params string[] args)
        {
            if (jsonPart.IsNullOrEmpty())
                return;

            var json = jsonPart.AltQuoteF(args);
            AddJsonPart(json);
        }

        protected TResultJsonPart RegisterJsonPartExpression<TJsonPart, TResultJsonPart>(Func<TJsonPart, TResultJsonPart> partExpression)
            where TJsonPart : new()
            where TResultJsonPart : IJsonConvertible
        {
            var jsonBuilderInstance = new TJsonPart();
            var resultPart = partExpression.Invoke(jsonBuilderInstance);
           
            var json = resultPart.ToJson();

            AddJsonPart(json);

            return resultPart;
        }

        /// <summary>
        /// Determines whether JSON should be build despite empty content.
        /// </summary>
        protected virtual bool ForceJsonBuild()
        {
            return false;
        }

        /// <summary>
        /// Determines whether this query/filter should generate any JSON.
        /// e.g. in case of "Term" query, if Value parameter not defined or empty -
        /// Term query will not be generated to JSON, 
        /// and empty string will be returned from ToJson/ToString call.
        /// Note: This check is not performed if there are no JSON parts registered.
        /// </summary>
        protected abstract bool HasRequiredParts();

        protected abstract string ApplyJsonTemplate(string body);


        public bool GetIsEmpty()
        {
            return ((IJsonConvertible) this).ToJson().IsNullOrEmpty();
        }


        private void AddJsonPart(string json)
        {
            if (json.IsNullOrEmpty())
                return;
            jsonParts.Add(json);
        }


        string IJsonConvertible.ToJson()
        {
            if (!ForceJsonBuild() && 
                (jsonParts.Count == 0 || (!HasCustomPatrs && !HasRequiredParts())))
                return "";

            var body = JsonParts.JoinWithComma();
            return ApplyJsonTemplate(body);
        }


        public override string ToString()
        {
            return ((IJsonConvertible) this).ToJson();
        }
        
    }
}