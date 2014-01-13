namespace PlainElastic.Net.Queries
{
    public class ScoreFunction<T> : ScoreFunctionBase<ScoreFunction<T>, T>
    {

        protected override string ApplyJsonTemplate(string body)
        {
            return body;
        }

        protected override bool HasRequiredParts()
        {
            return true;
        }
        
    }
}