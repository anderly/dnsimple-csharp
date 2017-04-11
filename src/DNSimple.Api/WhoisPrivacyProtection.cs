﻿using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{

		/// <summary>
		/// Turn on WHOIS Privacy Protection.
		/// If WHOIS Privacy Protection has not yet been purchased then invoking this will purchase the service and enable it. 
		/// If the privacy protection is currently disabled then it will be enabled.
		/// Makes a POST request to the Domains WHOIS resource.
		/// </summary>
		/// <param name="name">The name of the domain.</param>
		public dynamic AddWhoisPrivacyProtection(string name)
		{
			Require.Argument(nameof(name), name);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{name}/whois_privacy"
			};
			request.AddUrlSegment("name", name);

			return Execute<dynamic>(request);
		}

		public dynamic AddWhoisPrivacyProtection(int id)
		{
			Require.Argument(nameof(id), id);

			return AddWhoisPrivacyProtection(id.ToString());
		}

		/// <summary>
		/// Turn off WHOIS Privacy Protection. 
		/// If the privacy protection has not expired it can always be turned back on with no additional charge.
		/// Makes a DELETE request a Domains WHOIS resource.
		/// </summary>
		/// <param name="name">The name of the domain.</param>
		public dynamic RemoveWhoisPrivacyProtection(string name)
		{
			Require.Argument(nameof(name), name);

			var request = new RestRequest(Method.DELETE)
			{
				Resource = "domains/{name}/whois_privacy"
			};
			request.AddUrlSegment("name", name);

			return Execute<dynamic>(request);
		}

		public dynamic RemoveWhoisPrivacyProtection(int id)
		{
			Require.Argument(nameof(id), id);

			return RemoveWhoisPrivacyProtection(id.ToString());
		}

	}
}