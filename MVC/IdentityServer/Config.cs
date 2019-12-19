// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

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
        public static IEnumerable<IdentityResource> Ids => new IdentityResource[] {
            new IdentityResources.OpenId (),
            new IdentityResources.Profile (),
        };

        /// <summary>
        /// Gets the apis.
        /// </summary>
        /// <value>The apis.</value>
        public static IEnumerable<ApiResource> Apis => new ApiResource[] {
            new ApiResource ("identity_api", "Protected Simple API")
        };

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <value>The clients.</value>
        public static IEnumerable<Client> Clients => new Client[] {
            new Client
            {
                ClientId = "simple_client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = 
				{
                	new Secret ("ngp".Sha256 ())
            	},
            	AllowedScopes = { "identity_api" }
            },
            
			new Client 
			{
				ClientId = "mvc_client",
				ClientSecrets = 
				{ 
					new Secret ("ngp".Sha256 ()) 
				},

				AllowedGrantTypes = GrantTypes.Code,
				RequireConsent = false,
				RequirePkce = true,

				// where to redirect to after login
				RedirectUris = { "http://localhost:5001/signin-oidc" },

				// where to redirect to after logout
				PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

				AllowedScopes = new List<string> 
				{
					IdentityServerConstants.StandardScopes.OpenId,
					IdentityServerConstants.StandardScopes.Profile,
					"identity_api"
				},

				AllowOfflineAccess = true
            }
        };
    }
}