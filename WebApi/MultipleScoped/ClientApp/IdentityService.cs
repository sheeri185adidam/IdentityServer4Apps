using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace ClientApp
{
	/// <summary>
	/// A service for accessing identities information.
	/// </summary>
	public class IdentityService
	{
		private readonly string _address;
		private readonly HttpClient _client;

		/// <summary>
		/// Initializes a new instance of the ClientApp.IdentityService class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
		/// <param name="address">The address.</param>
		public IdentityService(string address)
		{
			_address = address ?? throw new ArgumentNullException(nameof(address));
			_client = new HttpClient();
		}

		/// <summary>
		/// Request token.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="secret">The secret.</param>
		/// <param name="scopes">The requested scopes</param>
		/// <returns>An asynchronous result that yields a TokenResponse.</returns>
		public async Task<TokenResponse> RequestToken(string id, string secret, IEnumerable<string> scopes)
		{
			var discovery = await DiscoveryDocument(true);
			if (discovery == null)
			{
				return null;
			}

			var request = new ClientCredentialsTokenRequest
			{
				Address = discovery.TokenEndpoint,
				ClientId = id,
				ClientSecret = secret,
				Scope = string.Join(" ", scopes)
			};

			var response = await _client.RequestClientCredentialsTokenAsync(request);
			if (response == null || response.IsError)
			{
				return null;
			}

			var parsedJson = JsonConvert.DeserializeObject(response.Raw);
			Console.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));
			return response;
		}

		private async Task<DiscoveryDocumentResponse> DiscoveryDocument(bool print = false)
		{
			var discovery = await _client.GetDiscoveryDocumentAsync(_address);
			if (discovery.IsError)
			{
				return null;
			}

			if (!print)
			{
				return discovery;
			}

			dynamic parsedJson = JsonConvert.DeserializeObject(discovery.Raw);
			Console.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));
			return discovery;
		}
	}
}