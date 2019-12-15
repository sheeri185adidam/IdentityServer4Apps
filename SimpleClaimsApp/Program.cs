using System;
using System.Security.Claims;

namespace ClaimsApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var claims = new[]{
				new Claim(ClaimTypes.Name, "Manik Sheeri"),
				new Claim(ClaimTypes.Email, "manik.sheeri@aristocrat.com"),
				new Claim(ClaimTypes.Role, "developer"),
			};

			var ci = new ClaimsIdentity(claims);
			var cp = new ClaimsPrincipal(ci);

			var emailClaim = cp.FindFirst(ClaimTypes.Email);
			var email = emailClaim?.Value;
			Console.WriteLine($"your email was {email}, {emailClaim?.Issuer}");
		}
	}
}
