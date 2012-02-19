namespace PlainElastic.Net.Queries
{
    public class DisMaxQueries<T>: Query<T>
    {
        protected override string QueryTemplate
        {
            get { return " 'queries': [ {0} ]"; }
        }
    }
}