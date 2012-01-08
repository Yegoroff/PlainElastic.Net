namespace PlainElastic.Net
{
    public class SearchCommand : Command<SearchCommand>
    {

        protected override SearchCommand Instance
        {
            get { return this; }
        }
    }
}