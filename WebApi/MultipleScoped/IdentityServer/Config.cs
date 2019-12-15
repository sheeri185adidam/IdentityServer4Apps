// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
	/// <summary>
	/// A configuration.
	/// </summary>
	public static class Config
	{
		/// <summary>
		/// Gets the identifiers.
		/// </summary>
		/// <value>The identifiers.</value>
		public static IEnumerable<IdentityResource> Ids => new IdentityResource[]
		{
			new IdentityResources.OpenId()
		};

		/// <summary>
		/// Gets the apis.
		/// </summary>
		/// <value>The apis.</value>
		public static IEnumerable<ApiResource> Apis => new ApiResource[]
		{
			new ApiResource("identity_api", "Protected Simple API")
		};

		/// <summary>
		/// Gets the clients.
		/// </summary>
		/// <value>The clients.</value>
		public static IEnumerable<Client> Clients => new Client[]
		{
			new Client
			{
				ClientId = "simple_client",
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				ClientSecrets =
				{
					new Secret("ngp".Sha256())
				},
				AllowedScopes = { "identity_api"}
			}
		};
	}
}