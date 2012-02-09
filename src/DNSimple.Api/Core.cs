using System.Reflection;
using DNSimple.Api.Infrastructure;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DNSimple
{
	/// <summary>
	/// REST API wrapper.
	/// </summary>
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// DNSimple API version to use when making requests
		/// </summary>
		public string ApiVersion { get; set; }
		/// <summary>
		/// Base URL of API (defaults to https://dnsimple.com/)
		/// </summary>
		public string BaseUrl { get; set; }
		private string AccountId { get; set; }
		private string ApiKey { get; set; }

		private RestClient _client;

		/// <summary>
		/// Initializes a new client with the specified credentials.
		/// </summary>
		/// <param name="accountId">The AccountId to authenticate with</param>
		/// <param name="apiKey">The ApiKey to authenticate with</param>
		public DNSimpleRestClient(string accountId, string apiKey)
		{
			// Typically this would be something like "v1" or "2012-01-01", so we'll just stub it out empty 
			// for now to allow for future support
			ApiVersion = "";
			BaseUrl = "https://dnsimple.com/";
			AccountId = accountId;
			ApiKey = apiKey;

			// silverlight friendly way to get current version
			var assembly = Assembly.GetExecutingAssembly();
			var assemblyName = new AssemblyName(assembly.FullName);
			var version = assemblyName.Version;

			_client = new RestClient
			          	{
			          		UserAgent = "dnsimple-sdk-csharp/" + version,
			          		Authenticator = new HttpBasicAuthenticator(AccountId, ApiKey),
			          		BaseUrl = string.Format("{0}{1}", BaseUrl, ApiVersion)
			          	};
			_client.AddHandler("application/json", new JsonFxDeserializer());
		}

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public T Execute<T>(RestRequest request) where T : new()
		{
			request.AddHeader("Accept", "application/json");
			request.OnBeforeDeserialization = (resp) =>
			{
				// for individual resources when there's an error to make
				// sure that RestException props are populated
				if (((int)resp.StatusCode) >= 400)
				{
					request.RootElement = "";
				}
			};

			request.DateFormat = "yyyy-MM-ddTHH:mm:ssZ";

			var response = _client.Execute<T>(request);
			return response.Data;
		}

		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public RestResponse Execute(RestRequest request)
		{
			return _client.Execute(request);
		}
#endif

	}
}
