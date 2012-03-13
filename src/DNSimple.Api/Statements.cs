using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Retrieve the statements for this account.
		/// Makes a GET request to the Statements resource.
		/// </summary>
		public dynamic GetStatements() {
			var request = new RestRequest {
				Resource = "statements"
			};

			return Execute<dynamic>(request);
		}
	}
}