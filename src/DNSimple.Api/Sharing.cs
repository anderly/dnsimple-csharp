using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// List all of the current members for a domain.
		/// Domain members have the privilege of managing a domain's records and templates. 
		/// Makes a GET request to the Domain Memberships List resource.
		/// </summary>
		/// <param name="domain">The domain for which to retrieve the members</param>
		public dynamic ListMembers(string domain)
		{
			var request = new RestRequest
			{
				Resource = "domains/{domain}/memberships"
			};
			request.AddUrlSegment("domain", domain);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// List all of the current members for a domain.
		/// Domain members have the privilege of managing a domain's records and templates. 
		/// Makes a GET request to the Domain Memberships List resource.
		/// </summary>
		/// <param name="domainId">The ID of the domain for which to retrieve the members</param>
		public dynamic ListMembers(int domainId)
		{
			return ListMembers(domainId.ToString());
		}

		/// <summary>
		/// Add another DNSimple customer to a domain's memberships.
		/// Domain members have the privilege of managing a domain's records and templates. 
		/// Makes a POST request to the Domain Memberships List resource.
		/// </summary>
		/// <remarks>
		/// You must provide an email address for the person to add. If the person already exists
		/// in DNSimple as a customer then they will immediately be added to the domain's membership list.
		/// If the person does not yet have a DNSimple account then they will receive an invitation to join via email.
		/// </remarks>
		/// <param name="domain">The domain for which to retrieve the members</param>
		/// <param name="email">The email for the user to add as a member to this domain</param>
		public dynamic AddMember(string domain, string email)
		{
			Require.Argument(nameof(domain), domain);
			Require.Argument(nameof(email), email);

			var request = new RestRequest(Method.POST)
			{
				Resource = "domains/{domain}/memberships"
			};
			request.AddUrlSegment("domain", domain);

			dynamic payload = new ExpandoObject();
			payload.membership = new { email = email };

			request.AddBody(payload);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Add another DNSimple customer to a domain's memberships.
		/// Domain members have the privilege of managing a domain's records and templates. 
		/// Makes a POST request to the Domain Memberships List resource.
		/// </summary>
		/// <remarks>
		/// You must provide an email address for the person to add. If the person already exists
		/// in DNSimple as a customer then they will immediately be added to the domain's membership list.
		/// If the person does not yet have a DNSimple account then they will receive an invitation to join via email.
		/// </remarks>
		/// <param name="domainId">The ID of the domain for which to retrieve the members</param>
		/// <param name="email">The email for the user to add as a member to this domain</param>
		public dynamic AddMember(int domainId, string email)
		{
			return AddMember(domainId.ToString(), email);
		}

		/// <summary>
		/// Remove a DNSimple customer from the membership list for a domain.
		/// Makes a DELETE request to the Domain Membership Instance resource.
		/// </summary>
		/// <remarks>
		/// The customer will no longer be able to manage the domain.
		/// </remarks>
		/// <param name="domain">The domain for which to retrieve the members</param>
		/// <param name="email">The email for the user to add as a member to this domain</param>
		public dynamic RemoveMember(string domain, string email)
		{
			Require.Argument(nameof(domain), domain);
			Require.Argument(nameof(email), email);

			var request = new RestRequest(Method.DELETE)
			{
				Resource = "domains/{domain}/memberships/{email}"
			};
			request.AddUrlSegment("domain", domain);
			request.AddUrlSegment("email", email);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Remove a DNSimple customer from the membership list for a domain.
		/// Makes a DELETE request to the Domain Membership Instance resource.
		/// </summary>
		/// <remarks>
		/// The customer will no longer be able to manage the domain.
		/// </remarks>
		/// <param name="domainId">The ID of the domain for which to retrieve the members</param>
		/// <param name="email">The email for the user to add as a member to this domain</param>
		public dynamic RemoveMember(int domainId, string email)
		{
			return RemoveMember(domainId.ToString(), email);
		}
	}
}