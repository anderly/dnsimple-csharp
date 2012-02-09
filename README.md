# DNSimple REST API Library for .NET

DNSimple provides a simple HTTP-based API for working with DNS, domain registrations and SSL certificates. Learn more at [https://dnsimple.com/documentation/api][0]

- This SDK utilizes the power of C# 4.0 dynamics to provide the quickest and most accurate representation of the DNSimple REST API. No models, no DTOs. Everything is an ExpandoObject or an Array of ExpandoObjects.
- Currently, the domains resource is the only one supported. But the plan is to eventually have a complete C# SDK for DNSimple when it's all said and done.

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
    // You can up to 6 nameservers
	dynamic result = dns.SetNameServers("yourdomain.com", "n1.dnsimple.com", "n2.dnsimple.com", "ns3.dnsimple.com", "ns4.dnsimple.com");

[0]: https://dnsimple.com/documentation/api