using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainElastic.Net
{
    public class Test
    {

        /*
         $ curl -XPUT 'http://localhost:9200/twitter/tweet/1' -d '{
            "user" : "kimchy",
            "post_date" : "2009-11-15T14:12:12",
            "message" : "trying out Elastic Search"
        }'

        */

        public void TestConnection()
        {
            IElasticConnection connection = CreateConnection("http://localhost:9200");


            Customer customer = new Customer();
            
            var fullQueryResult  =
                connection.Put(
                "http://localhost:9200/twitter/tweet/1",
                customer.ToJson()
                );

            var relativeQueryResult = 
                connection.Put(
                "/twitter/tweet/1",
                customer.ToJson()
                );


            var plainQueryResult =
                connection.Put(
                "http://localhost:9200/twitter/tweet/1", 
                @"{
                    ""user"" : ""kimchy"",
                    ""post_date"" : ""2009-11-15T14:12:12"",
                    ""message"" : ""trying out Elastic Search""
                }"
                );



            Console.WriteLine(plainQueryResult);

            // curl -XGET 'http://localhost:9200/twitter/tweet/1'

            var customerResult = connection.Get("http://localhost:9200/twitter/tweet/1").As<Customer>();



            connection.Get(command: ElasticCommands.Get().FromIndex("twitter").OfType("tweet").Id("1")).As<Customer>();



            connection.Put(ElasticCommands.Index(index: "twitter", type: "customer", id: "1") ).As<Customer>();



            connection.Put(ElasticCommands.Index(index: "twitter", type: typeof(Customer), id: "1" ), 
                customer.ToJson()
                ).As<Customer>();


            string query = "";


            customerResult = connection.Post(command: Commands.Search()
                                                                     .Index("customers")
                                                                     .Type<Customer>(),
                                             jsonData: query)
                                             .As<Customer>();

            customerResult = connection.Post(command: ElasticCommands.Search("customers", "customer"), 
                                             jsonData: query)
                                             .As<Customer>();

            customerResult = connection.Post(command: ElasticCommands.Search(index: "customers", type: typeof(Customer)), 
                                             jsonData: query)
                                             .As<Customer>();

            // CommandBuilder.Select("customers","customer")


            customerResult = connection.Post(new SearchCommand().FromIndex("customer").OfType<Customer>().Id("1") ).As<Customer>();

            //customerResult = connection.Post(command, query).As<Customer>();







            connection.Get(ElasticCommands.Get(index: "twitter", type: "tweet", id: "1"));





            connection.Get(new GetCommand().FromIndex("twitter").OfType("tweet").Id("1"));
            connection.Get(() => new GetCommand(index: "twitter", type: "tweet", id: "1"));
        }



        private IElasticConnection CreateConnection(string url)
        {
            return null;
        }
    }

    public class Customer
    {
        public string ToJson()
        {
            


        }
    }
}
