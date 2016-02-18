using System;
using System.Reflection;
using DNSimple.Infrastructure;
using RestSharp;

namespace DNSimple
{
	/// <summary>
	/// REST API wrapper.
	/// </summary>
	public partial class DNSimpleRestClient
	{
	    private DNSimpleRestClient()
	    {
	        var version = new AssemblyName(Assembly.GetExecutingAssembly().FullName).Version;
            ApiVersion = "v1";
            BaseUrl = "https://api.dnsimple.com/";

            _client = new RestClient
            {
                UserAgent = "dnsimple-sdk-csharp/" + version,
                BaseUrl = new Uri(string.Format("{0}{1}", BaseUrl, ApiVersion)),
            };
			_client.AddHandler("application/json", new JsonNetDeserializer());
        }

	    /// <summary>
		/// DNSimple API version to use when making requests (defaults to v1)
		/// </summary>
		public string ApiVersion { get; set; }
		/// <summary>
		/// Base URL of API (defaults to https://api.dnsimple.com/)
		/// </summary>
		public string BaseUrl { get; set; }

	    private readonly RestClient _client;

	    /// <summary>
	    /// Initializes a new client with the specified credentials.
	    /// </summary>
	    /// <param name="username">The username to authenticate with</param>
	    /// <param name="password">The password to authenticate with</param>
	    /// <param name="token">API token</param>
	    public DNSimpleRestClient(string username, string password = null, string token = null) : this()
		{
	        if (!String.IsNullOrEmpty(token))
	        {
                _client.AddDefaultHeader("X-DNSimple-Token", String.Format("{0}:{1}", username, token));
	        }
	        else
	        {
	            _client.Authenticator = new HttpBasicAuthenticator(username, password);
	        }
		}

#if FRAMEWORK
		/// <summary>
		/// Execute a manual REST request
		/// </summary>
		/// <typeparam name="T">The type of object to create and populate with the returned data.</typeparam>
		/// <param name="request">The RestRequest to execute (will use client credentials)</param>
		public T Execute<T>(IRestRequest request) where T : new()
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
		public IRestResponse Execute(IRestRequest request)
		{
			return _client.Execute(request);
		}
#endif

	}
}
