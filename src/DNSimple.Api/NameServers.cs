using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Change the name servers either to external name servers or back to DNSimple's name servers.
		/// Makes a POST request the Name Servers resource (domains/{id_or_name}/name_servers).
		/// </summary>
		/// <remarks>
		/// This API accepts up to 6 name servers.
		/// </remarks>
		/// <param name="name">The domain for which to set the name servers</param>
		/// <param name="name_servers">List of name servers (up to 6) to set for the domain</param>
		public dynamic SetNameServers(string name, params string[] name_servers)
		{
			Require.Argument("name", name);
			Validate.IsBetween(name_servers.Length, 1, 6);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{name}/name_servers"
			};
			request.AddUrlSegment("name", name);

			dynamic payload = new ExpandoObject();
			var ns = new Dictionary<string, string>();
			for (var i = 0; i < name_servers.Length; i++)
			{
				ns.Add("ns" + (i + 1), name_servers[i]);
			}
			payload.name_servers = ns;

			request.AddBody(payload);

			return Execute<dynamic>(request);
		}
	}
}