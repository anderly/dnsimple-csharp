using System.Collections.Generic;
using System.Dynamic;
using RestSharp;
using RestSharp.Validation;

namespace DNSimple
{
    public partial class DNSimpleRestClient
    {

        /// <summary>
        /// Returns a list of Contacts.
        /// </summary>
        public dynamic ListContacts()
        {
            var request = new RestRequest
            {
                Resource = "contacts"
            };

            return Execute<dynamic>(request);
        }


        /// <summary>
        /// Retrieve the details for a specific Contact.
        /// Makes a GET request to the Contact resource.
        /// </summary>
        /// <param name="id">The id of the contact to retrieve</param>
        public dynamic GetContact(int id)
        {
            Require.Argument("id", id);

            var request = new RestRequest
            {
                Resource = "contacts/{id}"
            };
            request.AddUrlSegment("id", id.ToString());

            return Execute<dynamic>(request);
        }


        /// <summary>
        /// Create a contact.
        /// Makes a POST request to the Contacts List resource.
        /// </summary>
        /// <param name="first_name">First Name</param>
        /// <param name="last_name">Last Name</param>
        /// <param name="address1">Address Line 1</param>
        /// <param name="city">City</param>
        /// <param name="state_province">State or Province</param>
        /// <param name="postal_code">Postal Code</param>
        /// <param name="country">Country</param>
        /// <param name="email_address">Email Address</param>
        /// <param name="phone">Phone Number</param>
        /// <param name="organization_name">Optional Organisation Name</param>
        /// <param name="job_title">Optional Job Title (Required if organisation_name specified)</param>
        /// <param name="fax">Optional Fax Number</param>
        /// <param name="phone_ext">Optional Phone Extension</param>
        /// <param name="label">Optional Label for this Contact</param>
        /// <param name="address2">Address Line 2</param>
        public dynamic AddContact(string first_name, string last_name, string address1, string city, string state_province, string postal_code,
                                    string country, string email_address, string phone, string organization_name = null, string job_title = null,
                                    string fax = null, string phone_ext = null, string label = null, string address2 = null)
        {
            Require.Argument("first_name", first_name);
            Require.Argument("last_name", last_name);
            Require.Argument("address1", address1);
            Require.Argument("city", city);
            Require.Argument("state_province", state_province);
            Require.Argument("postal_code", postal_code);
            Require.Argument("country", country);
            Require.Argument("email_address", email_address);
            Require.Argument("phone", phone);

            if (!string.IsNullOrWhiteSpace(organization_name))
            {
                Require.Argument("job_title", job_title);
            }

            var request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json,
                Resource = "contacts"
            };

            dynamic payload = new ExpandoObject();
            payload.contact = new ExpandoObject();
            payload.contact.first_name = first_name;
            payload.contact.last_name = last_name;
            payload.contact.address1 = address1;
            payload.contact.city = city;
            payload.contact.state_province = state_province;
            payload.contact.postal_code = postal_code;
            payload.contact.country = country;
            payload.contact.email_address = email_address;
            payload.contact.phone = phone;
            if (!string.IsNullOrWhiteSpace(organization_name))
            {
                payload.contact.organization_name = organization_name;
            }
            if (!string.IsNullOrWhiteSpace(job_title))
            {
                payload.contact.job_title = job_title;
            }
            if (!string.IsNullOrWhiteSpace(fax))
            {
                payload.contact.fax = fax;
            }
            if (!string.IsNullOrWhiteSpace(phone_ext))
            {
                payload.contact.phone_ext = phone_ext;
            }
            if (!string.IsNullOrWhiteSpace(label))
            {
                payload.contact.label = label;
            }
            if (!string.IsNullOrWhiteSpace(address2))
            {
                payload.contact.address2 = address2;
            }
            request.AddBody(payload);

            return Execute<dynamic>(request);
        }


        /// <summary>
        /// Updates an existing Contact.
        /// Makes a PUT request to the Contacts List resource.
        /// </summary>
        /// <param name="id">The id of the Contact to Update</param>
        /// <param name="first_name">First Name</param>
        /// <param name="last_name">Last Name</param>
        /// <param name="address1">Address Line 1</param>
        /// <param name="city">City</param>
        /// <param name="state_province">State or Province</param>
        /// <param name="postal_code">Postal Code</param>
        /// <param name="country">Country</param>
        /// <param name="email_address">Email Address</param>
        /// <param name="phone">Phone Number</param>
        /// <param name="organization_name">Optional Organisation Name</param>
        /// <param name="job_title">Optional Job Title (Required if organisation_name specified)</param>
        /// <param name="fax">Optional Fax Number</param>
        /// <param name="phone_ext">Optional Phone Extension</param>
        /// <param name="label">Optional Label for this Contact</param>
        /// <param name="address2">Address Line 2</param>
        public dynamic UpdateContact(int id, string first_name, string last_name, string address1, string city, string state_province, string postal_code,
                                    string country, string email_address, string phone, string organization_name = null, string job_title = null,
                                    string fax = null, string phone_ext = null, string label = null, string address2 = null)
        {
            Require.Argument("id", id);
            Require.Argument("first_name", first_name);
            Require.Argument("last_name", last_name);
            Require.Argument("address1", address1);
            Require.Argument("city", city);
            Require.Argument("state_province", state_province);
            Require.Argument("postal_code", postal_code);
            Require.Argument("country", country);
            Require.Argument("email_address", email_address);
            Require.Argument("phone", phone);

            if (!string.IsNullOrWhiteSpace(organization_name))
            {
                Require.Argument("job_title", job_title);
            }

            var request = new RestRequest(Method.PUT)
            {
                RequestFormat = DataFormat.Json,
                Resource = "contacts/{id}"
            };
            request.AddUrlSegment("id", id.ToString());

            dynamic payload = new ExpandoObject();
            payload.contact = new ExpandoObject();
            payload.contact.first_name = first_name;
            payload.contact.last_name = last_name;
            payload.contact.address1 = address1;
            payload.contact.city = city;
            payload.contact.state_province = state_province;
            payload.contact.postal_code = postal_code;
            payload.contact.country = country;
            payload.contact.email_address = email_address;
            payload.contact.phone = phone;
            if (!string.IsNullOrWhiteSpace(organization_name))
            {
                payload.contact.organization_name = organization_name;
            }
            if (!string.IsNullOrWhiteSpace(job_title))
            {
                payload.contact.job_title = job_title;
            }
            if (!string.IsNullOrWhiteSpace(fax))
            {
                payload.contact.fax = fax;
            }
            if (!string.IsNullOrWhiteSpace(phone_ext))
            {
                payload.contact.phone_ext = phone_ext;
            }
            if (!string.IsNullOrWhiteSpace(label))
            {
                payload.contact.label = label;
            }
            if (!string.IsNullOrWhiteSpace(address2))
            {
                payload.contact.address2 = address2;
            }
            request.AddBody(payload);

            return Execute<dynamic>(request);
        }


        /// <summary>
        /// Delete a single Contact in your DNSimple account.
        /// Makes a DELETE request to the Contacts resource.
        /// </summary>
        /// <param name="name">The id of the contact to delete.</param>
        public dynamic DeleteContact(int id)
        {
            Require.Argument("id", id);

            var request = new RestRequest(Method.DELETE)
            {
                Resource = "contacts/{id}"
            };
            request.AddUrlSegment("id", id.ToString());

            return Execute<dynamic>(request);
        }
    }
}