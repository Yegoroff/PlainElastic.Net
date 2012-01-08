using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainElastic.Net
{
    public class IndexCommand: Command<IndexCommand>
    {
        protected override IndexCommand Instance
        {
            get { return this; }
        }

    }
}
