using System.Collections.Generic;
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
        public dynamic SetWHOISPrivacyProtection(string name) {
            Require.Argument("name", name);

            var request = new RestRequest(Method.POST) {
                RequestFormat = DataFormat.Json,
                Resource = "domains/{name}/whois_privacy"
            };
            request.AddUrlSegment("name", name);

            return Execute<dynamic>(request);
        }

        public dynamic SetWHOISPrivacyProtection(int id) {
            Require.Argument("id", id);

            return SetWHOISPrivacyProtection(id.ToString());
        }

        /// <summary>
        /// Turn off WHOIS Privacy Protection. 
        /// If the privacy protection has not expired it can always be turned back on with no additional charge.
        /// Makes a DELETE request a Domains WHOIS resource.
        /// </summary>
        /// <param name="name">The name of the domain.</param>
        public dynamic RemoveWHOISPrivacyProtection(string name) {
            Require.Argument("name", name);

            var request = new RestRequest(Method.DELETE) {
                Resource = "domains/{name}/whois_privacy"
            };
            request.AddUrlSegment("name", name);

            return Execute<dynamic>(request);
        }

        public dynamic RemoveWHOISPrivacyProtection(int id) {
            Require.Argument("id", id);

            return RemoveWHOISPrivacyProtection(id.ToString());
        }

	}
}