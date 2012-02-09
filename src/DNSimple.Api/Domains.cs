using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Retrieve the details for a specific Domain Instance.
		/// Makes a GET request to an Domain Instance resource.
		/// </summary>
		/// <param name="name">The Name of the domain to retrieve</param>
		public dynamic GetDomain(string name)
		{
			Require.Argument("name", name);

			var request = new RestRequest
			              	{
			              		Resource = "domains/{Name}"
			              	};
			request.AddUrlSegment("Name", name);

			return Execute<dynamic>(request);
		}

		public dynamic GetDomain(int id)
		{
			Require.Argument("id", id);

			return GetDomain(id.ToString());
		}

		/// <summary>
		/// Returns a list of Domains. 
		/// The list includes paging information.
		/// Makes a GET request to the Domains List resource.
		/// </summary>
		public dynamic ListDomains()
		{
			var request = new RestRequest
			              	{
			              		Resource = "domains"
			              	};

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Create a single domain in your DNSimple account.
		/// Makes a POST request to the Domains List resource.
		/// </summary>
		/// <param name="name">The name of the domain.</param>
		public dynamic AddDomain(string name)
		{
			Require.Argument("name", name);

			var request = new RestRequest(Method.POST)
			              	{
								RequestFormat = DataFormat.Json,
			              		Resource = "domains"
			              	};
			request.AddBody(new { domain = new { name }});

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Delete a single domain in your DNSimple account.
		/// Makes a DELETE request a Domain Instance resource.
		/// </summary>
		/// <param name="name">The name of the domain.</param>
		public dynamic DeleteDomain(string name)
		{
			Require.Argument("name", name);

			var request = new RestRequest(Method.DELETE)
			{
				Resource = "domains/{Name}"
			};
			request.AddUrlSegment("Name", name);

			return Execute<dynamic>(request);
		}

		public dynamic DeleteDomain(int id)
		{
			Require.Argument("id", id);

			return GetDomain(id.ToString());
		}
	}
}