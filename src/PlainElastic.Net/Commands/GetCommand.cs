using System;

namespace PlainElastic.Net
{
    public class GetCommand : Command<GetCommand>
    {

        protected override GetCommand Instance
        {
            get { return this; }
        }

    }
}