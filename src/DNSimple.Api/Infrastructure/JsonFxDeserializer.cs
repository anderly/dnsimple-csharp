using JsonFx.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace DNSimple.Api.Infrastructure
{
	public class JsonFxDeserializer : IDeserializer
	{
		public JsonFxDeserializer()
		{
			//DateFormat = "yyyy-MM-ddTHH:mm:ssZ";
		}

		public T Deserialize<T>(RestResponse response) where T : new()
		{
			var reader = new JsonReader();
			dynamic result = reader.Read(response.Content);
			return result;
		}

		public string RootElement { get; set; }

		public string Namespace { get; set; }

		public string DateFormat { get; set; }
	}
}
