using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace DNSimple
{
	public partial class DNSimpleRestClient
	{
		/// <summary>
		/// Get the list of DNS records for the specific domain.
		/// Makes a GET request to an Domain DNS Records List resource.
		/// </summary>
		/// <param name="domain">The name of the domain for which to retrieve the DNS records</param>
		public dynamic ListRecords(string domain)
		{
			Require.Argument(nameof(domain), domain);

			var request = new RestRequest
			{
				Resource = "domains/{domain}/records"
			};
			request.AddUrlSegment("domain", domain);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Get the list of DNS records for the specific domain.
		/// Makes a GET request to an Domain DNS Records List resource.
		/// </summary>
		/// <param name="id">The ID of the domain for which to retrieve the DNS records</param>
		public dynamic ListRecords(int id)
		{
			Require.Argument(nameof(id), id);

			return ListRecords(id.ToString());
		}

		/// <summary>
		/// Retrieve the details for a specific Domain DNS Record Instance.
		/// Makes a GET request to an DNS Record Instance resource.
		/// </summary>
		/// <param name="domain">The name of the domain for which to retrieve the DNS record</param>
		/// <param name="record_id">The ID of the DNS record to retrieve</param>
		public dynamic GetRecord(string domain, int record_id)
		{
			Require.Argument(nameof(domain), domain);
			Require.Argument(nameof(record_id), record_id);

			var request = new RestRequest
			{
				Resource = "domains/{domain}/records/{record_id}"
			};
			request.AddUrlSegment("domain", domain);
			request.AddUrlSegment("record_id", record_id.ToString());

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Retrieve the details for a specific Domain DNS Record Instance.
		/// Makes a GET request to an DNS Record Instance resource.
		/// </summary>
		/// <param name="domainId">The ID of the domain for which to retrieve the DNS record</param>
		/// <param name="record_id">The ID of the DNS record to retrieve</param>
		public dynamic GetRecord(int domainId, int record_id)
		{
			Require.Argument(nameof(domainId), domainId);
			Require.Argument(nameof(record_id), record_id);

			return GetRecord(domainId.ToString(), record_id);
		}

		/// <summary>
		/// Create a record for the given domain.
		/// Makes a POST request to the Domain Records List resource.
		/// </summary>
		/// <param name="domain">The name of the domain</param>
		/// <param name="name">The name of the DNS record</param>
		/// <param name="record_type">The type of the DNS record (A, CNAME, MX, etc.)</param>
		/// <param name="content">The value of the DNS record</param>
		/// <param name="ttl">The optional TTL (Time-To-Live) for this DNS record</param>
		/// <param name="priority">The optional priority for this DNS record</param>
		public dynamic AddRecord(string domain, string name, string record_type, string content, int? ttl = null, int? priority = null)
		{
			Require.Argument(nameof(domain), domain);
			Require.Argument(nameof(name), name);

			var request = new RestRequest(Method.POST)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/records"
			};
			request.AddUrlSegment("domain", domain);

			dynamic payload = new ExpandoObject();
			payload.record = new ExpandoObject();
			payload.record.name = name;
			payload.record.record_type = record_type;
			payload.record.content = content;
			if (ttl.HasValue)
			{
				payload.record.ttl = ttl.Value;
			}
			if (priority.HasValue)
			{
				payload.record.prio = priority.Value;
			}
			request.AddBody(payload);

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Create a record for the given domain.
		/// Makes a POST request to the Domain Records List resource.
		/// </summary>
		/// <param name="domainId">The ID of the domain</param>
		/// <param name="name">The name of the DNS record</param>
		/// <param name="record_type">The type of the DNS record (A, CNAME, MX, etc.)</param>
		/// <param name="content">The value of the DNS record</param>
		/// <param name="ttl">The optional TTL (Time-To-Live) for this DNS record</param>
		/// <param name="priority">The optional priority for this DNS record</param>
		public dynamic AddRecord(int domainId, string name, string record_type, string content, int? ttl = null, int? priority = null)
		{
			Require.Argument(nameof(domainId), domainId);

			return AddRecord(domainId.ToString(), name, record_type, content, ttl, priority);
		}

		/// <summary>
		/// Update the given record for the given domain.
		/// Makes a PUT request to the Domain Records Instance resource.
		/// </summary>
		/// <param name="domain">The name of the domain</param>
		/// <param name="record_id">The ID of the DNS record to affect</param>
		/// <param name="name">The name of the DNS record</param>
		/// <param name="content">The value of the DNS record</param>
		/// <param name="ttl">The optional TTL (Time-To-Live) for this DNS record</param>
		/// <param name="priority">The optional priority for this DNS record</param>
		public dynamic UpdateRecord(string domain, int record_id, string name, string content, int? ttl = null, int? priority = null)
		{
			Require.Argument(nameof(domain), domain);
			Require.Argument(nameof(record_id), record_id);

			var request = new RestRequest(Method.PUT)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/records/{id}"
			};
			request.AddUrlSegment("domain", domain);
			request.AddUrlSegment("id", record_id.ToString());

			if (name.HasValue() || content.HasValue() || ttl.HasValue || priority.HasValue)
			{
				dynamic payload = new ExpandoObject();
				payload.record = new ExpandoObject();
				if (name.HasValue())
				{
					payload.record.name = name;
				}
				if (content.HasValue())
				{
					payload.record.content = content;
				}
				if (ttl.HasValue)
				{
					payload.record.ttl = ttl.Value;
				}
				if (priority.HasValue)
				{
					payload.record.prio = priority.Value;
				}
				request.AddBody(payload);
			}

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Update the given record for the given domain.
		/// Makes a PUT request to the Domain Records Instance resource.
		/// </summary>
		/// <param name="domain">The name of the domain</param>
		/// <param name="record_id">The ID of the DNS record to affect</param>
		/// <param name="name">The name of the DNS record</param>
		/// <param name="content">The value of the DNS record</param>
		/// <param name="ttl">The optional TTL (Time-To-Live) for this DNS record</param>
		/// <param name="priority">The optional priority for this DNS record</param>
		public dynamic UpdateRecord(int domainId, int record_id, string name, string content, int? ttl = null, int? priority = null)
		{
			Require.Argument(nameof(domainId), domainId);

			return UpdateRecord(domainId.ToString(), record_id, name, content, ttl, priority);
		}

		/// <summary>
		/// Remove a DNS Record from a domain.
		/// Makes a DELETE request to the Domain DNS Records Instance resource.
		/// </summary>
		/// <param name="domain">The domain of the domain</param>
		/// <param name="record_id">The ID of DNS Record to remove from the domain</param>
		public dynamic DeleteRecord(string domain, int record_id)
		{
			Require.Argument(nameof(domain), domain);
			Require.Argument(nameof(record_id), record_id);

			var request = new RestRequest(Method.DELETE)
			{
				RequestFormat = DataFormat.Json,
				Resource = "domains/{domain}/records/{id}"
			};
			request.AddUrlSegment("domain", domain);
			request.AddUrlSegment("id", record_id.ToString());

			return Execute<dynamic>(request);
		}

		/// <summary>
		/// Remove a DNS Record from a domain.
		/// Makes a DELETE request to the Domain DNS Records Instance resource.
		/// </summary>
		/// <param name="id">The ID of the domain</param>
		/// <param name="record_id">The ID of DNS Record to remove from the domain</param>
		public dynamic DeleteRecord(int id, int record_id)
		{
			Require.Argument(nameof(id), id);
			Require.Argument(nameof(record_id), record_id);

			return DeleteRecord(id.ToString(), record_id);
		}
	}
}