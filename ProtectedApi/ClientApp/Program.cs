using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace ClientApp
{
	class Program
	{
		private const string IdentityServer = @"http://localhost:5000";

		static async Task Main(string[] args)
		{
			var identityService = new IdentityService(IdentityServer);
			var token = await identityService.RequestToken("simple_client_admin", "ngpadmin", new []{"identity_api", "roles"});
			if (token == null)
			{
				Console.WriteLine("Failed to get identity token from the identity server");
				return;
			}

			var client = new HttpClient();
			client.SetBearerToken(token.AccessToken);

			var response = await client.GetAsync(@"http://localhost:5001/identity");
			if (!response.IsSuccessStatusCode)
			{
				Console.WriteLine(response.StatusCode);
			}
			else
			{
				var content = await response.Content.ReadAsStringAsync();
				Console.WriteLine(JArray.Parse(content));
			}
		}
	}
}
