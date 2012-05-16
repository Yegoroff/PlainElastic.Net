﻿namespace PlainElastic.Net.IndexSettings
{
    /// <summary>
    /// A tokenizer of type nGram that builds N-characters substrings from text.
    /// see http://www.elasticsearch.org/guide/reference/index-modules/analysis/edgengram-tokenizer.html
    /// </summary>
    public class NGramTokenizer : NGramComponentBase<NGramTokenizer>
    {
        protected override string GetComponentType()
        {
            return DefaultTokenizers.nGram.ToString();
        }
    }
}