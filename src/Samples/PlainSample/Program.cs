using System;
using System.Collections.Generic;
using PlainElastic.Net;
using PlainElastic.Net.QueryBuilder;
using PlainElastic.Net.Serialization;

namespace PlainSample
{
    class Program
     {
        static void Main(string[] args)
        {
            var plainSample = new PlainSample();

            plainSample.Execute();


            var clientSample = new ClientSample();

            clientSample.Execute();
        }
     }
}
