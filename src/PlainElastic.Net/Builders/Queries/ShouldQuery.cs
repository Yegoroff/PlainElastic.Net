namespace PlainElastic.Net.Queries
{
    public class ShouldQuery<T> : Query<T>
    {

        protected override string QueryTemplate
        {
            get { return " 'should': [ {0} ]"; }
        }

    }
}