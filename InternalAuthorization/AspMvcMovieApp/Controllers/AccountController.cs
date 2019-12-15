using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AspMvcMovieApp.Identity;
using AspMvcMovieApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcMovieApp.Controllers
{
	/// <summary>
	/// A controller for handling accounts.
	/// </summary>
	/// <seealso cref="T:Microsoft.AspNetCore.Mvc.Controller"/>
	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly IdentityService _identityService;

		/// <summary>
		/// Initializes a new instance of the AspMvcMovieApp.Controllers.AccountController class.
		/// </summary>
		/// <param name="identityService">The identity service.</param>
		public AccountController(IdentityService identityService)
		{
			_identityService = identityService;
		}

		/// <summary>
		/// (An Action that handles HTTP GET requests) login.
		/// </summary>
		/// <param name="returnUrl">URL of the return.</param>
		/// <returns>An IActionResult.</returns>
		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			return View(new LoginModel { ReturnUrl = returnUrl });
		}

		/// <summary>
		/// (An Action that handles HTTP GET requests) login.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns>An IActionResult.</returns>
		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (model.Username.Equals(model.Password))
			{
				var claims = new List<Claim>
				{
					new Claim("sub", model.Username)
				};

				claims.AddRange(_identityService.GetClaimsForUser(model.Username));

				var ci = new ClaimsIdentity(claims, "password", "name", "role");
				var cp = new ClaimsPrincipal(ci);

				await HttpContext.SignInAsync("Cookies", cp);

				if (model.ReturnUrl != null)
				{
					return LocalRedirect(model.ReturnUrl);
				}

				return RedirectToAction("Index", "Movies");
			}

			ModelState.AddModelError("", "Invalid username or password");
			return View();
		}

		/// <summary>
		/// Logout.
		/// </summary>
		/// <returns>An asynchronous result that yields an IActionResult.</returns>
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("Cookies");
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// Access denied.
		/// </summary>
		/// <returns>An IActionResult.</returns>
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}