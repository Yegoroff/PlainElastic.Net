using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlainSample
{
	partial class ElasticClient<T>
	{
		public IAsyncResult BeginGet(GetCommand getCommand, AsyncCallback cb, object state)
		{
			return connection.BeginRequest(RequestMethodEnum.GET, getCommand, null, cb,state);
		}

		public GetResult<T> EndGet(IAsyncResult res)
		{
			var result = connection.EndRequest(res);

			return Serializer.ToGetResult<T>(result);
		}

		public IAsyncResult BeginSearch(SearchCommand searchCommand, QueryBuilder<T> query, AsyncCallback cb, object state)
		{
			var jsonQuery = query.Build();
			return connection.BeginRequest(RequestMethodEnum.POST, searchCommand, jsonQuery, cb, state);
		}

		public SearchResult<T> EndSearch(IAsyncResult res)
		{
			var result = connection.EndRequest(res);
			return Serializer.ToSearchResult<T>(result);
		}

	}
}
