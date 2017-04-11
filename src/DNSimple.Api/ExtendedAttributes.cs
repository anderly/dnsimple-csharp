using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Retrieve the extended attributes required for a specific top level domain.
		/// Makes a GET request to the Extended Attributes resource.
		/// </summary>
		/// <param name="tld">The tld to retrieve the extended attributes for</param>
		public dynamic GetExtendedAttributes(string tld) {
			Require.Argument(nameof(tld), tld);

			var request = new RestRequest {
				Resource = "extended_attributes/{tld}"
			};
			request.AddUrlSegment("tld", tld);

			return Execute<dynamic>(request);
		}
	}
}