﻿using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// The index analysis module acts as a configurable registry of Analyzers
    /// that can be used in order to both break indexed (analyzed) fields when a document is indexed and process query strings.
    /// It maps to the Lucene Analyzer.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/
    /// </summary>
    public class Analysis : AnalysisBase<Analysis>
    {
        /// <summary>
        /// Allows to configure standard/custom analyzers to be used in mapping API.
        /// </summary>
        public Analysis Analyzer(Func<Analyzer, Analyzer> analyzer)
        {
            RegisterJsonPartExpression(analyzer);
            return this;
        }


        protected override string ApplyJsonTemplate(string body)
        {
            return "'analysis': {{ {0} }}".AltQuoteF(body);
        }
    }
}