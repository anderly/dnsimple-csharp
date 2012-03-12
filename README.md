# A C# dynamic wrapper for the DNSimple REST API

[DNSimple][0] provides a simple HTTP-based API for working with DNS, domain registrations and SSL certificates. Learn more at [https://dnsimple.com/documentation/api][1]

- This SDK utilizes C# 4.0 dynamics to provide the quickest and most accurate representation of the DNSimple REST API. No models, no DTOs. Everything is an ExpandoObject or an Array of ExpandoObjects.
- See the [Trello Board][2] for API Parity Status

## Current Release: [v0.4.1 on NuGet][3]

### Installation

#### Via NuGet

Install REST API wrapper:

    Install-Package DNSimple

### Sample Usage

## Retrieving a list of your DNSimple domains

    using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.ListDomains();
	for (var i = 0; i < result.Length; i++)
	{
		Console.WriteLine(result[i].domain.name);
	}

## Retrieving a specific domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.GetDomain("yourdomain.com");
	Console.WriteLine(result.domain.name);
	
## Adding a domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.AddDomain("yourdomain.com");
	Console.WriteLine(result.domain.name);
	
## Deleting a domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.DeleteDomain("yourdomain.com");
	
## Check domain availability

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.CheckDomain("yourdomain.com");
	
## Register a domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.RegisterDomain("yourdomain.com", registrant_id: an_existing_account_contact_id);
	
## Transfer a domain to DNSimple

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.TransferDomain("yourdomain.com", registrant_id: an_existing_account_contact_id);
	
## Renew a Domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.RenewDomain("yourdomain.com", renew_whois_privacy: false);
	
## Set Nameservers for a Domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
    // You can pass up to 6 nameservers
	dynamic result = dns.SetNameServers("yourdomain.com", "n1.dnsimple.com", "n2.dnsimple.com", "ns3.dnsimple.com", "ns4.dnsimple.com");
	
## Add a DNS Record for a Domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.AddRecord("yourdomain.com", name: "mail", record_type: "CNAME", content: "ghs.google.com");
	
## Update a DNS Record for a Domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.UpdateRecord("yourdomain.com", record_id: an_existing_dns_record_id, name: "email", content: "ghs.google.com");
	
## Delete a DNS Record for a Domain

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.DeleteRecord("yourdomain.com", record_id: an_existing_dns_record_id);

## Retrieving a list of your DNSimple contacts

    using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.ListContacts();
	for (var i = 0; i < result.Length; i++)
	{
		Console.WriteLine(result[i].contact.last_name);
	}

## Retrieving a specific contact

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.GetContact(an_existing_contact_id);
	Console.WriteLine(result.contact.last_name);
	
## Add a Contact

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.AddContact("Jane", "Doe", "123 Ave B", "Miami", "FL", "12345", "US", "jane.doe@example.com", "111 111 1111");
	
## Update a Contact

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.UpdateContact(an_existing_contact_id, "John", "Doe", "1 SW 1st Street", "Miami", "FL", "33143", "US", "john.doe@gmail.com", "+15551122323", label: "Home");
	
## Delete a Contact

	using DNSimple;
    var dns = new DNSimpleRestClient("yourname@yourdomain.com", "yourpassword");
	dynamic result = dns.DeleteContact(an_existing_contact_id);

[0]:http://dnsimple.com
[1]:https://dnsimple.com/documentation/api
[2]:https://trello.com/board/dnsimple-csharp/4f5e0494e22d5e333ff7816c
[3]:http://nuget.org/Packages/DNSimple