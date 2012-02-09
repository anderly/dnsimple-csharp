using System.Collections.Generic;
using System.Dynamic;
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
			              		Resource = "domains/{name}"
			              	};
			request.AddUrlSegment("name", name);

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
			dynamic payload = new ExpandoObject();
			payload.domain = new { name = name };
			request.AddBody(payload);

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
				Resource = "domains/{name}"
			};
			request.AddUrlSegment("name", name);

			return Execute<dynamic>(request);
		}

		public dynamic DeleteDomain(int id)
		{
			Require.Argument("id", id);

			return GetDomain(id.ToString());
		}

		/// <summary>
		/// Check if the specified domain is available for registration.
		/// Makes a GET request the Domains Check resource (/domains/{name}/check).
		/// </summary>
		/// <param name="name">The Name of the domain to check</param>
		public dynamic CheckDomain(string name)
		{
			Require.Argument("name", name);

			var request = new RestRequest
			{
				Resource = "domains/{name}/check"
			};
			request.AddUrlSegment("name", name);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Register a domain name with DNSimple and the appropriate domain registry.
		/// Makes a POST request to the Domain Registrations resource (domain_registrations).
		/// </summary>
		/// <remarks>
		/// Your account must already be active for this command to complete successfully. 
		/// You will be automatically charged the 1 year registration fee upon successful registration, so please be careful with this command.
		/// </remarks>
		/// <param name="name">The domain name to register</param>
		/// <param name="registrant_id">ID for an existing account contact</param>
		public dynamic RegisterDomain(string name, int registrant_id)
		{
			Require.Argument("name", name);
			Require.Argument("registrant_id", registrant_id);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domain_registrations"
			};

			dynamic payload = new ExpandoObject();
			payload.domain = new
			{
				name = name,
				registrant_id = registrant_id
			};

			request.AddBody(payload);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Transfer a domain name from another domain registrar into DNSimple.
		/// Makes a POST request the Domain Transfer resource (domain_transfers).
		/// </summary>
		/// <remarks>
		/// Your account must already be active for this command to complete successfully. 
		/// You will be automatically charged the 1 year transfer fee upon successful transfer of the domain, which may take anywhere from a few minutes up to 7 days.
		/// 
		/// Only domains that do not require extended attributes may be transferred through the API at this time. 
		/// For example, domains ending in .com and .net may be transferred through the API, however domains ending in .us and .ca may not.
		/// </remarks>
		/// <param name="name">The domain name to transfer</param>
		/// <param name="registrant_id">ID for an existing contact</param>
		public dynamic TransferDomain(string name, int registrant_id, string authinfo = null)
		{
			Require.Argument("name", name);
			Require.Argument("registrant_id", registrant_id);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domain_transfers"
			};

			dynamic payload = new ExpandoObject();
			payload.domain = new
			                 	{
			                 		name = name,
			                 		registrant_id = registrant_id
			                 	};
			if (!string.IsNullOrWhiteSpace(authinfo))
			{
				payload.transfer_order = new { authinfo = authinfo };
			}

			request.AddBody(payload);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Renew a domain name in your account.
		/// Makes a POST request the Domain Renewal resource (domain_renewal).
		/// </summary>
		/// <remarks>
		/// This will renew the domain for 1 year.
		/// </remarks>
		/// <param name="name">The domain name to renew</param>
		/// <param name="renew_whois_privacy">Whether to renew the Whois Privacy Service</param>
		public dynamic RenewDomain(string name, bool renew_whois_privacy = false)
		{
			Require.Argument("name", name);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domain_renewal"
			};

			dynamic payload = new ExpandoObject();
			payload.domain = new
			{
				name = name,
				renew_whois_privacy = renew_whois_privacy
			};

			request.AddBody(payload);

			return Execute<dynamic>(request);
		}		
	}
}