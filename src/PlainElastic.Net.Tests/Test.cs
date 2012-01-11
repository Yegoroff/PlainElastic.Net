using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlainElastic.Net.Serialization;

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
            IElasticConnection connection = new ElasticConnection { DefaultHost = "http://localhost", DefaultPort = 9200 };


            IJsonSerializer serializer = new JsonNetSerializer();

            Customer customer = new Customer();
            
            var fullQueryResult =
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

            var customerResult = connection.Get("http://localhost:9200/twitter/tweet/1");

            Customer gotCustomer = serializer.ToGetResult<Customer>(customerResult);


            // connection.Get(ElasticCommands.Get().ForIndex("twitter").OfType("tweet").WithId("1")).As<Customer>();

            connection.Get(ElasticCommands.Get(index: "twitter", type: "tweet", id: "1")).As<Customer>();
            connection.Get(ElasticCommands.Get(index: "twitter", type: typeof(Customer), id: "1")).As<Customer>();


            connection.Get(ElasticCommands.Get(index:"customers", type:"customer", id: "1")
                               .Realtime(false)
                               .Fields("field1,field2")
                               .Routing("route")
                               .Preference(GetPrefernce.custom, "preference")
                               .Refresh(true)
                );



            //connection.Put(ElasticCommands.Index(index: "twitter", type: "customer", id: "1") ).As<Customer>();



            //connection.Put(ElasticCommands.Index(index: "twitter", type: typeof(Customer), id: "1" ), 
            //    customer.ToJson()
            //    ).As<Customer>();
            

            string query = "";


            //customerResult = connection.Post(command: ElasticCommands.Search().ForIndex("customers").OfType<Customer>(),
            //                                 jsonData: query)
            //                                 .As<Customer>();

            //customerResult = connection.Post(command: ElasticCommands.Search("customers", "customer"), 
            //                                 jsonData: query)
            //                                 .As<Customer>();

            //customerResult = connection.Post(command: ElasticCommands.Search(index: "customers", type: typeof(Customer)), 
            //                                 jsonData: query)
            //                                 .As<Customer>();

            // CommandBuilder.Select("customers","customer")


            //customerResult = connection.Post(new SearchCommand().ForIndex("customer").OfType<Customer>(), query ).As<Customer>();

            //customerResult = connection.Post(command, query).As<Customer>();







//            connection.Get(ElasticCommands.Get(index: "twitter", type: "tweet", id: "1"));





            //connection.Get(new GetCommand().ForIndex("twitter").OfType("tweet").Id("1"));
            //connection.Get(() => new GetCommand(index: "twitter", type: "tweet", id: "1"));
        }

        public void TestMapping()
        {
            
        }


        public void TestQuery()
        {

        }

    }



    public class Customer
    {
        public string ToJson()
        {
            return "";
        }
    }
}
