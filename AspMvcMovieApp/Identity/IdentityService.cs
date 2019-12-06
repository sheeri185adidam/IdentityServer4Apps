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
				case "user1":
					// we could do the role mappings here, but for this lab we won't
					// just to illustrate the different approach of using claims transformation
					//claims.Add(new Claim("role", "Reviewer"));
					claims.Add(new Claim("name", "User One"));
					break;
				case "user2":
					//claims.Add(new Claim("role", "Reviewer"));
					claims.Add(new Claim("name", "User Two"));
					break;
				case "user3":
					//claims.Add(new Claim("role", "Reviewer"));
					claims.Add(new Claim("name", "User Three"));
					break;
				case "user4":
					//claims.Add(new Claim("role", "Customer"));
					claims.Add(new Claim("name", "User Four"));
					break;
				case "user5":
					//claims.Add(new Claim("role", "Admin"));
					claims.Add(new Claim("name", "User Five"));
					break;
				default:
					claims.Add(new Claim("name", subject));
					break;
			}

			return claims;
		}
	}
}