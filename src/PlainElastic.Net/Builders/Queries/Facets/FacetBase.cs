using System;
using System.Collections.Generic;
using PlainElastic.Net.Builders;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    public abstract class FacetBase<TFacet, T> : QueryBase<TFacet> where TFacet : FacetBase<TFacet, T>
    {
        private string facetName;
        private readonly List<string> facetParts = new List<string>();


        /// <summary>
        /// The name of the facet used to identify facets results.
        /// </summary>
        public TFacet FacetName(string name)
        {
            this.facetName = name.Quotate();

            return (TFacet)this;
        }


        /// <summary>
        /// All facets can be configured with an additional filter, which will reduce the documents they use for computing results.
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/index.html
        /// </summary>
        public TFacet FacetFilter(Func<FacetFilter<T>, Filter<T>> facetFilter)
        {
            var configuredFacetFilter = facetFilter(new FacetFilter<T>());
            var filterJson = ((IJsonConvertible) configuredFacetFilter).ToJson();

            if (!filterJson.IsNullOrEmpty())
            {
                facetParts.Add(filterJson);
            }

            return (TFacet)this;
        }


        /// <summary>
        /// Allows to specify a scope that facet computation will be restricted to.
        /// </summary>
        public TFacet Scope(string scope)
        {
            facetParts.Add("'scope': {0}".AltQuoteF(scope.Quotate()));
            return (TFacet)this;
        }

        /// <summary>
        /// Controls whether facet computed within the global scope. 
        /// In this case it will return values computed across all documents in the index.
        /// </summary>
        public TFacet Global(bool isGlobalScope)
        {
            facetParts.Add("'global': {0}".AltQuoteF(isGlobalScope.AsString()));
            return (TFacet)this;
        }


        /// <summary>
        /// Allows to run the facet on all the nested documents 
        /// matching the root objects that the main query will end up producing.
        /// </summary>
        public TFacet Nested(string nestedDocumentPath)
        {
            facetParts.Add("'nested': {0}".AltQuoteF(nestedDocumentPath.Quotate()));
            return (TFacet)this;
        }


        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected sealed override string ApplyJsonTemplate(string body)
        {
            var facetBodyJson = ApplyFacetBodyJsonTemplate(body);
            facetParts.Insert(0, facetBodyJson);

            var completeBody = facetParts.JoinWithComma();

            return "{0}: {{ {1} }}".AltQuoteF(facetName, completeBody);
        }


        protected abstract string ApplyFacetBodyJsonTemplate(string body);

    }
}