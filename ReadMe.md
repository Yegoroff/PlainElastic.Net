PlainElastic.Net
=======

The really plain Elastic Search .Net client.


* [Idea](#plain-idea)
* [Installation](#installation)
* [How its works](#how-its-works)
* [Concepts](#concepts)
* [Command building](#command-building)
* [Indexing](#indexing)
* [Bulk operations](#bulk-operations)
* [Queries](#queries)
* [Condition less queries](#condition-less-queries)
* [Facets](#facets)
* [Highlighting](#highlighting)
* [Scrolling](#scrolling)
* [Mapping](#mapping)
* [Index Settings](#index-settings)
* [If something is missed](#if-something-is-missed)
* [Samples](#samples)
* [License](#license)


### Plain Idea 

Usually connectivity clients built using **BLACK BOX** principle: **there is a client interface and some unknown magic behind it**.<br/>
*(call of the client method internally generate some commands and queries to external system, get responses, somehow process them and then retrieve result to user)*<br/>
As the result user hardly can debug connectivity issues or extend client functional with missed features.

The main Idea of PlainElastic.Net is to be a **GLASS BOX**. e.g. provide a **full control over connectivity process to user**.


### Installation

##### NuGet support
You can find **PlainElastic.Net** in NuGet Gallery or just install it using VS *NuGet Packages Manager*. <br/>
Or just type `Install-Package PlainElastic.Net` in Package Manager Console.

##### Building from Source
The easiest way to build PlainElastic.Net from source is to clone the git repository on GitHub and build the PlainElastic.Net solution.

`git clone git://github.com/Yegoroff/PlainElastic.Net.git`

The solution file `PlainElastic.Net.sln` is located in the root of the repo.


### How Its works

1) The only thing you need to connect to ES is a HTTP connection.

```csharp
  var connection  = new ElasticConnection();
```

2) Than you can declare sting with ES command

```csharp
  string command = "http://localhost:9200/twitter/user/test";
```

3) And JSON string with data

```csharp
  string jsonData = "{ \"name\": \"Some Name\" }";
```

4) And pass them using connection to ES.

```csharp
  string response = connection.Put(command, jsonData);
```

5) Get JSON string response and analyze it.

```csharp
  if(response.Contains("\"ok\":true")) {
   ... // do something useful
  }
```

#### So, how PlainElastic can help you here?

```csharp
  // 1. It provides ES HTTP connection
  var connection  = new ElasticConnection("localhost", 9200);
  
  // 2. And sophisticated ES command builders:
  string command = Commands.Index(index: "twitter", type: "user", id: test)
  
  // 3. And gives you the ability to serialize your objects to JSON:  
  var serializer = new JsonNetSerializer();
  var tweet = new Tweet { Name = "Some Name" };
  string jsonData = serializer.ToJson(tweet);
  
  // 4. Then you can use appropriate HTTP verb to execute ES command:
  string response = connection.Put(command, jsonData);
  
  // 5. And then you can deserialize operation response to typed object to easily analyze it:
  IndexResult indexResult = serializer.ToIndexResult(result);
  if(indexResult.ok) {
     ... // do something useful.
  }
  
  // 6. And even more: Typed mapping and condition-less query builders.
```

### Concepts

#### No addition abstraction upon native Elastic Search query and mapping syntax.

This eliminates requirements to read both ES and driver's manuals, 
and also it allows you not to guess how driver will generate actual ES query when you construct it using driver's Query DSL.<br/>
*So if you want to apply some ES query - all you need is to read [ES Query DSL documentation](http://www.elasticsearch.org/guide/reference/query-dsl/)*


#### All you need is strings.

Let's take some ES query sample in a format that you will see in ES documentation:

```
$ curl -XGET http://localhost:9200/twitter/tweet/_search -d '{
     "query" : {
         "term" : { "User": "somebody" }
     }
}'
```

In PlainElastic.Net this could be done using:

```csharp
var connection  = new ElasticConnection("localhost", 9200);
string command = new SearchCommand("twitter", "tweet"); // This will generate: twitter/tweet/_search
string query = new QueryBuilder<Tweet>()        // This will generate: 
          .Query(q => q                         // { "query": { "term": { "User": "somebody" } } }
            .Term(t => t
              .Field(tweet=> tweet.User).Value("somebody")
            )
          ).Build();
string result = connection.Get( command, query);

// Than we can convert search results to typed results
var serializer = new JsonNetSerializer();
var foundTweets = serializer.ToSearchResults<Tweet>(result);
foreach (Tweet tweet in  foundTweets.Documents)
{
  ...
}
```

As you can see *all parameters* passed to and returned from Get HTTP verb execution are just **strings**.<br/> 
This gives us complete control over generated commands and queries. You can copy/paste and debug them in any ES tool that allows to execute JSON queries (e.g. CURL or ElasticHead ).


### Command building

PlainElastic.Net commands represent URL part of ElasticSearch requests.<br/>
All commands have corresponding links to ES documentation in their XML comments, 
so you can use these links to access detailed command description.

Most of the commands have *Index* ,*Type* and *Id* constructor parameters, *(these parameters forms address part)*
all other options could be set using fluent builder interface.

```csharp
string indexCommand = new IndexCommand(index: "twitter", type: "tweet", id: "10")
               .Routing("route_value")
               .Refresh();
```

There is also a Commands class that represents a command registry and allows you to easily build commands,
without necessity to remember command class name.

```csharp
string searchCommand = Commands.Index(index: "twitter", type: "tweet", id: "10")
               .Routing("route_value")
               .Refresh();
```

### Indexing

*ES documentation:*  http://www.elasticsearch.org/guide/reference/api/index_.html

The easiest way to index document is to serialize your document object to JSON and pass it to PUT index command:

```csharp
var connection  = new ElasticConnection("localhost", 9200);
var serializer = new JsonNetSerializer();

var tweet = new Tweet { User = "testUser" };
string tweetJson = serializer.ToJson(tweet);

string result = connection.Put(new IndexCommand("twitter", "tweet", id: "10"), tweetJson);

// Convert result to typed index result object. 
var indexResult = serializer.ToIndexResult(result);
```

**Note:** You can specify additional indexing parameters such as Parent or Refresh in IndexCommand builder.

```csharp
string indexCommand = new IndexCommand("twitter", "tweet", id: "10").Parent("5").Refresh();
```

### Bulk Operations

*ES documentation:*  http://www.elasticsearch.org/guide/reference/api/bulk.html

There are two options to build Bulk operations JSONs.
First is to build all Bulk operations at once:

```csharp
IEnumerable<Tweet> tweets = new List<Tweet>();

string bulkCommand = new BulkCommand(index: "twitter", type: "tweet");

string bulkJson = 
    new BulkBuilder(serializer)
       .BuildCollection(tweets,
            (builder, tweet) => builder.Index(data: tweet,  id: tweet.Id)
                       // You can apply any custom logic here
                       // to generate Indexes, Creates or Deletes.
);

string result = connection.Post(bulkCommand, bulkJson);

//Parse bulk result;
BulkResult bulkResult = serializer.ToBulkResult(result);
...
```

Second allows you to build Bulk operations in batches of desired size.<br/> 
This will prevent from constructing huge in-memory strings, and allows to process input collection on-the-fly,
without enumerating them to the end.

```csharp
IEnumerable<Tweet> tweets = new List<Tweet>();

string bulkCommand = new BulkCommand(index: "twitter", type: "tweet");

IEnumerable<string> bulkJsons = 
    new BulkBuilder(serializer)
        .PipelineCollection(tweets,
            (builder, tweet) => builder.Index(data: tweet,  id: myObject.Id))
        .JoinInBatches(batchSize: 10); // returns deferred IEnumerable of JSONs  
                            // with at most 10 bulk operations in each element,
                            // this will allow to process input elements on-the-fly
                            // and not to generate all bulk JSON at once

foreach(string bulk in bulkJsons )
{
  // Send bulk batch.
  string result = connection.Post(bulkCommand, bulk);

  // Parse bulk batch result.
  BulkResult bulkResult = serializer.ToBulkResult(result);
  ...
}
```

**Note:** You can build not only *Index* Bulk operations but also *Create* and *Delete*.

```csharp
IEnumerable<string> bulkJsons = 
  new BulkBuilder(serializer)
     .PipelineCollection(tweets,
            (builder, tweet) => {
              switch (tweet.State) {
                case State.Added: 
                  builder.Create(data: tweet,  id: myObject.Id))
                case State.Updated: 
                  builder.Index(data: tweet,  id: myObject.Id))
                case State.Deleted:
                  builder.Delete(id: myObject.Id))
              }
            });
```

### Queries
*ES documentation:*  http://www.elasticsearch.org/guide/reference/query-dsl/

The main idea of QueryBuilder is to repeat JSON syntaxes of ES queries.<br/>
Besides this it provides *intellisense* with fluent builder interface <br/>
and *property references*:

for single property `.Field(tweet => tweet.Name)` <br/>
for collection type property `.FieldOfCollection(collection: user => user.Tweets, field: tweet => tweet.Name)`


So let’s see how it works.

We have *http://localhost:9200/twitter* index with type *user*.
Below we add sample "user" document to it:

```json
PUT http://localhost:9200/twitter/user/1
{
    "Id": 1,
    "Active": true,
    "Name": "John Smith",
    "Alias": "Johnnie"
}
```

Now let's create some synthetic JSON query to get this document:

```json
POST http://localhost:9200/twitter/user/_search
{
    "query": {
        "bool": {
            "must": [
                {
                   "query_string": {
                      "fields": ["Name","Alias"], "query" : "John" 
                    }
                },
                {
                   "prefix" : {
                      "Alias": { "prefix": "john" } 
                   }
                }
            ]
        }
    },
    "filter": {
        "term": { "Active": "true" }
    }
}
```

Assuming that we have defined class User:

```csharp
class User
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
}
```

This query could be constructed using:

```csharp
string query = new QueryBuilder<User>()
    .Query(q => q
        .Bool(b => b
           .Must(m => m
               .QueryString(qs => qs
                   .Fields(user => user.Name, user => user.Alias).Query("John")
               )
               .Prefix(p => p
                    .Field(user => user.Alias).Prefix("john")
               )
           )
        )
    )
    .Filter(f => f
        .Term(t => t 
            .Field(user=> user.Active).Value("true")
        )
    )
    .BuildBeautified();
```

And then to execute this query we can use the following code:
```csharp
var connection = new ElasticConnection("localhost", 9200);
var serializer = new JsonNetSerializer();

string result = connection.Post(Commands.Search("twitter", "user"), query);
User foundUser = serializer.ToSearchResult<User>(result).Documents.First();
```

See [Query Builder Gist](https://gist.github.com/2765230) for complete sample.


#### Condition-less Queries:

Its usual case when you have a bunch of UI filters to define full-text query, price range filter, category filter etc.<br/>
None of these filters are mandatory, so when you construct final query you should use only defined filters.
This brings ugly conditional logic to your query-building code.

So how PlainElastic.Net addresses this?

The idea behind is really simple:<br/> 
**If provided condition value is null or empty - the corresponding query or filter will not be generated.**

Expression 

```csharp
string query = new QueryBuilder<User>()
    .Query(q => q
        .QueryString(qs => qs
           .Fields(user => user.Name, user => user.Alias).Query("")
        )
    )
    .Filter(f => f
        .Term(t => t 
            .Field(user=> user.Active).Value(null)
        )
    )
    .Build();
```

will generate "{}" string that will return all documents from the index.

The real life usage sample: <br/>
Let's say we have criterion object that represents UI filters:

```csharp
class Criterion
{
    public string FullText { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
    public bool? Active { get; set; }
}
```

So our query builder could look like this: 

```csharp
public string BuildQuery(Criterion criterion)
{
    string query = new QueryBuilder<Item>()
        .Query(q => q
            .QueryString(qs => qs
                .Fields(item => item.Name, item => item.Description)
                .Query(criterion.FullText)
            )
        )
        .Filter(f => f
            .And(a => a
                .Range(r => r
                    .Field(item => item.Price)                           
                    // AsString extension allows to convert nullable values to string or null
                    .From(criterion.MinPrice.AsString())
                    .To(criterion.MaxPrice.AsString())
                )
                .Term(t => t
                    .Field(user => user.Active).Value(criterion.Active.AsString())
                )
            )
        ).BuildBeautified();
}
```

And that's all - no ugly ifs or switches.<br/>
You just write query builder using most complex scenario, and then it will build only defined criterions.

If we call this function with `BuildQuery( new Criterion { FullText = "text" })`
then it will generate:

```json
{
    "query": {
        "query_string": {
            "fields": ["Name", "Description"],
            "query": "text"
        }
    }
}
```

so it omits all not defined filters.

See [Condion-less Query Builder Gist](https://gist.github.com/2765335) for complete sample.


### Facets
*ES documentation:*  http://www.elasticsearch.org/guide/reference/api/search/facets/index.html

For now only *Terms* facet, *Terms Stats* facet, *Statistical* facet, *Range* facet and *Filter Facet* supported.

You can construct facet queries using the following syntax:

```csharp
public string BuildFacetQuery(Criterion criterion)
{
  return new QueryBuilder<Item>()
        .Query(q => q
            .QueryString(qs => qs
                .Fields(item => item.Name, item => item.Description)
                .Query(criterion.FullText)
            )
        )

        // Facets Part
        .Facets(facets => facets
            .Terms(t => t
                .FacetName("ItemsPerCategoryCount")
                .Field(item => item.Category)
                .Size(100)
                )
        )
        .BuildBeautified();
}
```

To read facets result you need to deserialize it to `SearchResults` and access its `.facet` property:

```csharp
  // Build faceted query with FullText criterion defined.
  string query = BuildFacetQuery(new Criterion { FullText = "text" });
  string result = connection.Post(Commands.Search("store", "item"), query);

  // Parse facets query result 
  var searchResults = serializer.ToSearchResult<Item>(result);
  var itemsPerCategoryTerms = searchResults.facets.Facet<TermsFacetResult>("ItemsPerCategoryCount").terms;

  foreach (var facetTerm in itemsPerCategoryTerms)
  {
      Console.WriteLine("Category: {0}  Items Count: {1}".F(facetTerm.term, facetTerm.count));
  }
```

See [Facet Query Builder Gist](https://gist.github.com/3093936) for complete sample.


### Highlighting

*ES documentation:*  http://www.elasticsearch.org/guide/reference/api/search/highlighting/

You can construct highlighted queries using the following syntax:

```csharp
string query = new QueryBuilder<Note>()
    .Query(q => q
        .QueryString(qs => qs
            .Fields(c => c.Caption)
            .Query("Note")
        )
     )
     .Highlight(h => h
        .PreTags("<b>")
        .PostTags("</b>")
        .Fields(
             f => f.FieldName(n => n.Caption).Order(HighlightOrder.score),
             f => f.FieldName("_all")
        )
     )
    .BuildBeautified();
```

To get highlighted fragments you need to deserialize results to `SearchResult<T>` and access `highlight` property of each hit:

```csharp
// Execute query and deserialize results.
string results = connection.Post(Commands.Search("notes", "note"), query);
var noteResults = serializer.ToSearchResult<Note>(results);

// Array of higlighted fragments for Caption field for the first hit.
var hit = noteResults.hits.hits[0];
string[] fragments = hit.highlight["Caption"];
```

See [Highlighting Gist](https://gist.github.com/Yegoroff/5569008) for complete sample.

### Scrolling

*ES documentation:*  http://www.elasticsearch.org/guide/reference/api/search/scroll/

You can construct scrolling search request by specifing scroll keep alive time in SearchCommand:

```csharp
string scrollingSearchCommand = new SearchCommand(index:"notes", type:"note")
                                      .Scroll("5m")
                                      .SearchType(SearchType.scan);

```

To scroll found documents you need to deserialize results to `SearchResult<T>` and get the `_scroll_id` field.
Then you should execute `SearchScrollCommand` with acquired `scroll_id`

```csharp
// Execute query and deserialize results.
string results = connection.Post(scrollingSearchCommand, queryJson);
var noteResults = serializer.ToSearchResult<Note>(results);

// Get the initial scroll ID
string scrollId = scrollResults._scroll_id;

// Execute SearchScroll request to scroll found documents.
results = connection.Get(Commands.SearchScroll(scrollId).Scroll("5m"));

```

See [Scrolling Gist](https://gist.github.com/Yegoroff/5888926) for complete sample.


### Mapping
*ES documentation:*  http://www.elasticsearch.org/guide/reference/mapping/

Mapping of core and object types could be performed in the following manner:

```csharp
private static string BuildCompanyMapping()
    {
        return new MapBuilder<Company>()
            .RootObject(typeName: "company",
                        map: r => r
                .All(a => a.Enabled(false))
                .Dynamic(false)
                .Properties(pr => pr
                    .String(company => company.Name, f => f.Analyzer(DefaultAnalyzers.standard).Boost(2))
                    .String(company => company.Description, f => f.Analyzer(DefaultAnalyzers.standard))
                    .String(company => company.Fax, f => f.Analyzer(DefaultAnalyzers.keyword))

                    .Object(company => company.Address, address => address
                        .Properties(ap => ap
                            .String(addr => addr.City)
                            .String(addr => addr.State)
                            .String(addr => addr.Country)
                        )
                    )

                    .NestedObject(company => company.Contacts, o => o
                        .Properties(p => p
                            .String(contact => contact.Name)
                            .String(contact => contact.Department)
                            .String(contact => contact.Email)

                            // It's unnecessary to specify opt.Type(NumberMappingType.Integer)
                            // cause it will be inferred from property type.
                            // Showed here only for educational purpose.
                            .Number(contact => contact.Age, opt => opt.Type(NumberMappingType.Integer))

                            .Object(ct => ct.Address, oa => oa
                                .Properties( pp => pp
                                    .String(a => a.City)
                                    .String(a => a.State)
                                    .String(a => a.Country)
                                )
                            )
                        )
                    )
                )
          )
          .BuildBeautified();
```

To apply mapping you need to use PutMappingCommand:

```csharp
var connection = new ElasticConnection("localhost", 9200);
string jsonMapping = BuildCompanyMapping();

connection.Put(new PutMappingCommand("store", "company"), jsonMapping);
```

See [Mapping Builder Gist](https://gist.github.com/3094283) for complete sample.


### Index Settings
*ES documentation:*  http://www.elasticsearch.org/guide/reference/api/admin-indices-update-settings.html

You can build index settings by using IndexSettinsBuilder:

```csharp
private static string BuildIndexSettings()
{
    return new IndexSettingsBuilder()
        .Analysis(als => als
            .Analyzer(a => a
                .Custom("lowerkey", custom => custom
                    .Tokenizer(DefaultTokenizers.keyword)
                    .Filter(DefaultTokenFilters.lowercase)
                )
                .Custom("fulltext", custom => custom
                    .CharFilter(DefaultCharFilters.html_strip)
                    .Tokenizer(DefaultTokenizers.standard)
                    .Filter(DefaultTokenFilters.word_delimiter,
                            DefaultTokenFilters.lowercase,
                            DefaultTokenFilters.stop,
                            DefaultTokenFilters.standard)
                )
            )
        )
        .BuildBeautified();
}
```

You can put index settings to index by UpdateSettingsCommand or by passing settings to index creation command:

```csharp
var connection = new ElasticConnection("localhost", 9200);

var settings = BuildIndexSettings();

if (IsIndexExists("store", connection))
{
    // We can't update settings on active index.
    // So we need to close it, then update settings and then open index back.
    connection.Post(new CloseCommand("store"));

    connection.Put(new UpdateSettingsCommand("store"), settings);

    connection.Post(new OpenCommand("store"));
}
else
{
    // Create Index with settings.
    connection.Put(Commands.Index("store").Refresh(), settings);
}
```

See [Index Settings Gist](https://gist.github.com/3094421) for complete sample.


*Special thanks to [devoyster (Andriy Kozachuk)](https://github.com/devoyster) for providing Index Settings support.*

### Samples
  
 -  [Date Histogram Facet sample](https://gist.github.com/Yegoroff/8424594)
 -  [Parent/Child sample](https://gist.github.com/Yegoroff/10422763)
 -  [Random Sort sample](https://gist.github.com/Yegoroff/7945379)
 -  [And Or filtering sample](https://gist.github.com/Yegoroff/7679120)
 -  [Query Scrolling sample](https://gist.github.com/Yegoroff/5888926)
 -  [ES Mapping and MongoDb river configuration](https://gist.github.com/Yegoroff/5735870)
 -  [Complex MoreLikeThis sample](https://gist.github.com/Yegoroff/5572590)
 -  [MoreLikeThis sample](https://gist.github.com/Yegoroff/5572496)
 -  [Highlighting sample](https://gist.github.com/Yegoroff/5569008)
 -  [Query builder using JSON query as pattern](https://gist.github.com/Yegoroff/5327726)
 -  [Index Settings sample](https://gist.github.com/Yegoroff/3094421)
 -  [Mapping sample](https://gist.github.com/Yegoroff/3094283)
 -  [Facet query builder sample](https://gist.github.com/Yegoroff/3093936)
 -  [Condition-less query builder sample](https://gist.github.com/Yegoroff/2765335)
 -  [Query builder sample](https://gist.github.com/Yegoroff/2765230)
 -  [Bulk sample](https://gist.github.com/Yegoroff/2235286)

### If something is missed

  In case you need ElasticSearch feature that not yet covered by PlainElastic.Net, just remember that everything passed to ES connection is a string,
  so you can add missed functionality using `.Custom(string)` function, that exists in every builder.
  
```csharp  
return new QueryBuilder<Item>()
    .Query(q => q
        .Term(t => t
              .Field(user => user.Active)
              .Value(true.ToString())

              // Custom string representing boost part.
              .Custom("\"boost\": 3")
          )
    )
    .BuildBeautified();
```
  or even more - just pass you string with JSON to ES connection.

  Also don't forget to add an issue to PlainElastic.Net github repository [PlainElastic Issues](https://github.com/Yegoroff/PlainElastic.Net/issues) 
  so I can add this functionality to the future builds.


### License

PlainElastic.Net is free software distributed under the terms of MIT License (see LICENSE.txt) these terms don’t apply to other 3rd party tools, utilities or code which may be used to develop this application.
