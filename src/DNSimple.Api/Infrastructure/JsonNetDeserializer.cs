using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Deserializers;

namespace DNSimple.Infrastructure
{
	public class JsonNetDeserializer : IDeserializer
	{
		public JsonNetDeserializer()
		{
			//DateFormat = "yyyy-MM-ddTHH:mm:ssZ";
		}

		public T Deserialize<T>(IRestResponse response)
		{
			var converter = new ExpandoObjectConverter();
			if (response.Content.StartsWith("[") && response.Content.EndsWith("]"))
			{
				dynamic result = JsonConvert.DeserializeObject<ExpandoObject[]>(response.Content, converter);
				return result;
			}
			else
			{
				dynamic result = JsonConvert.DeserializeObject<ExpandoObject>(response.Content, converter);
				return result;
			}
		}

		public string RootElement { get; set; }

		public string Namespace { get; set; }

		public string DateFormat { get; set; }
	}
}