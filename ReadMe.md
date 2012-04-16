PlainElastic.Net
=======

The really plain Elastic Search .Net client.

### Idea 

Usually clients built using `Black Box` principle: *there is a client interface and some unknown magic behind it*.<br/>
*(call of the client method internally generate some commands and queries to external system, get responses and somehow process them and then retrieve result to user)*<br/>
As the result user hardly can debug connectivity issues or extend client functional with missed features. 

The main Idea of PlainElastic.Net is to be a `Glass Box`. e.g. provide a full control over connectivity process to user.


### How Its works

1 The only thing you need to connect to ES is a HTTP connection.

  ```csharp
  var connection  = new ElasticConnection();
  ```

2 Than you can write stings with ES command 
  
```csharp
  string command = "http://localhost:9200/twitter/user/test";
```

3 And JSON string with data

```csharp
	string jsonData = "{ \"name\": \"Some Name\" }";
```

4 And pass them using connection to ES.

```csharp
	string response = connection.Put(command, jsonData);
```

5 Get JSON string response and analyze it.

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



### License

PlainElastic.Net is free software distributed under the terms of MIT License (see LICENSE.txt) these terms doesn’t apply to other 3rd party tools, utilities or code which may be used to develop this application.

