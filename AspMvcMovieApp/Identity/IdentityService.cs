using System.Collections.Generic;
using System.Security.Claims;

namespace AspMvcMovieApp.Identity
{
	/// <summary>
	/// A service for accessing identities information.
	/// </summary>
	public class IdentityService
	{
		/// <summary>
		/// Gets the claims for users in this collection.
		/// </summary>
		/// <param name="subject">The subject.</param>
		/// <returns>An enumerator that allows foreach to be used to process the claims for users in this collection.</returns>
		public IEnumerable<Claim> GetClaimsForUser(string subject)
		{
			var claims = new List<Claim>();

			switch (subject)
			{
				case "manik":
					claims.Add(new Claim("name", "Manik Sheeri"));
					break;
				case "jake":
					claims.Add(new Claim("name", "Jake O'Hara"));
					break;
				case "sean":
					claims.Add(new Claim("name", "Sean Gribbin"));
					break;
				case "ngp":
					claims.Add(new Claim("role", "Admin"));
					claims.Add(new Claim("name", "Administrator"));
					break;
				default:
					claims.Add(new Claim("name", subject));
					break;
			}

			return claims;
		}
	}
}