using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Get a list of all services supported.
		/// Makes a GET request to the Services List resource.
		/// </summary>
		public dynamic ListServices()
		{
			var request = new RestRequest
			{
				Resource = "services"
			};

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Retrieve the details for a specific Service Instance.
		/// Makes a GET request to an Service Instance resource.
		/// </summary>
		/// <param name="id">The ID of the service to retrieve</param>
		public dynamic GetService(int id)
		{
			Require.Argument("id", id);

			var request = new RestRequest
			{
				Resource = "services/{id}"
			};
			request.AddUrlSegment("id", id.ToString());

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// List services already applied to a domain.
		/// Makes a GET request to an Domain Applied Services List resource.
		/// </summary>
		/// <param name="domain">The name of the domain for which to retrieve the applied services</param>
		public dynamic ListAppliedServices(string domain)
		{
			Require.Argument("domain", domain);

			var request = new RestRequest
			{
				Resource = "domains/{domain}/applied_services"
			};
			request.AddUrlSegment("domain", domain);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// List services already applied to a domain.
		/// Makes a GET request to an Domain Applied Services List resource.
		/// </summary>
		/// <param name="id">The ID the domain for which to retrieve the applied services</param>
		public dynamic ListAppliedServices(int id)
		{
			Require.Argument("id", id);

			return ListAppliedServices(id.ToString());
		}

		/// <summary>
		/// List services available for a domain.
		/// Makes a GET request to an Domain Available Services List resource.
		/// </summary>
		/// <param name="domain">The name of the domain for which to retrieve the available services</param>
		public dynamic ListAvailableServices(string domain)
		{
			Require.Argument("domain", domain);

			var request = new RestRequest
			{
				Resource = "domains/{domain}/available_services"
			};
			request.AddUrlSegment("domain", domain);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// List services available for to a domain.
		/// Makes a GET request to an Domain Available Services List resource.
		/// </summary>
		/// <param name="id">The ID the domain for which to retrieve the available services</param>
		public dynamic ListAvailableServices(int id)
		{
			Require.Argument("id", id);

			return ListAppliedServices(id.ToString());
		}

		/// <summary>
		/// Add a service to a domain.
		/// Makes a POST request to the Domain Applied Services List resource.
		/// </summary>
		/// <param name="domain">The name of the domain</param>
		/// <param name="service_id">The ID of service to add to the domain</param>
		public dynamic AddService(string domain, int service_id)
		{
			Require.Argument("domain", domain);
			Require.Argument("service_id", service_id);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/applied_services"
			};
			request.AddUrlSegment("domain", domain);

			dynamic payload = new ExpandoObject();
			payload.service = new { id = service_id };
			request.AddBody(payload);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Add a service to a domain.
		/// Makes a POST request to the Domain Applied Services List resource.
		/// </summary>
		/// <param name="id">The ID of the domain</param>
		/// <param name="service_id">The ID of service to add to the domain</param>
		public dynamic AddService(int id, int service_id)
		{
			Require.Argument("id", id);
			Require.Argument("service_id", service_id);

			return AddService(id.ToString(), service_id);
		}

		/// <summary>
		/// Remove a service from a domain.
		/// Makes a DELETE request to the Domain Applied Services Instance resource.
		/// </summary>
		/// <param name="domain">The name of the domain</param>
		/// <param name="service_id">The ID of service to remove from the domain</param>
		public dynamic DeleteService(string domain, int service_id)
		{
			Require.Argument("domain", domain);
			Require.Argument("service_id", service_id);

			var request = new RestRequest(Method.DELETE)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/applied_services/{id}"
			};
			request.AddUrlSegment("domain", domain);
			request.AddUrlSegment("id", service_id.ToString());

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Remove a service from a domain.
		/// Makes a DELETE request to the Domain Applied Services Instance resource.
		/// </summary>
		/// <param name="id">The ID of the domain</param>
		/// <param name="service_id">The ID of service to remove from the domain</param>
		public dynamic DeleteService(int id, int service_id)
		{
			Require.Argument("id", id);
			Require.Argument("service_id", service_id);

			return DeleteService(id.ToString(), service_id);
		}
	}
}