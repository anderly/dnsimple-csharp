using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public enum ServerSource
	{
		DNSimple,
		External
	}

	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Enable vanity name servers for the given domain.
		/// Makes a POST request to the Vanity Name Servers resource (domains/{id_or_name}/vanity_name_servers).
		/// </summary>
		/// <remarks>
		/// You may use up to 4 external name servers (ns1 through ns4)
		/// </remarks>
		/// <param name="domain">The domain for which to set the name servers</param>
		/// <param name="server_source">ServerSource ["dnsimple" or "external"]</param>
		/// <param name="name_servers">List of name servers (up to 4) to set for the domain</param>
		public dynamic SetVanityNameServers(string domain, ServerSource server_source, params string[] name_servers)
		{
			Require.Argument("domain", domain);
			if (server_source == ServerSource.External)
			{
				Validate.IsBetween(name_servers.Length, 1, 4);
			}

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/vanity_name_servers"
			};
			request.AddUrlSegment("domain", domain);

			dynamic payload = new ExpandoObject();
			payload.vanity_nameserver_configuration = new ExpandoObject();
			payload.vanity_nameserver_configuration.server_source = server_source.ToString().ToLower();
			if (server_source == ServerSource.External)
			{
				var ns = payload.vanity_nameserver_configuration as IDictionary<string, object>;
				for (var i = 0; i < name_servers.Length; i++)
				{
					ns.Add("ns" + (i + 1), name_servers[i]);
				}
			}

			request.AddBody(payload);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Disable vanity name servers for the given domain.
		/// Makes a DELETE request to the Vanity Name Servers resource (domains/{id_or_name}/vanity_name_servers).
		/// </summary>
		/// <param name="domain">The domain for which to remove the vanity name servers</param>
		public dynamic RemoveVanityNameServers(string domain)
		{
			Require.Argument("domain", domain);

			var request = new RestRequest(Method.DELETE)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/vanity_name_servers"
			};
			request.AddUrlSegment("domain", domain);

			return Execute<dynamic>(request);
		}
	}
}