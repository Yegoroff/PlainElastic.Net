using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainElastic.Net
{
    public class IndexCommandBuilder: CommandBuilder<IndexCommandBuilder>
    {
        protected override string BuildUrlPath()
        {
            throw new NotImplementedException();
        }
    }
}
