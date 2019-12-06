using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspMvcMovieApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspMvcMovieApp.Controllers
{
	/// <summary>
	/// A controller for handling homes.
	/// </summary>
	/// <seealso cref="T:Microsoft.AspNetCore.Mvc.Controller"/>
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		/// <summary>
		/// Initializes a new instance of the AspMvcMovieApp.Controllers.HomeController class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Gets the index.
		/// </summary>
		/// <returns>An IActionResult.</returns>
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Gets the privacy.
		/// </summary>
		/// <returns>An IActionResult.</returns>
		public IActionResult Privacy()
		{
			return View();
		}

		/// <summary>
		/// Gets the error.
		/// </summary>
		/// <returns>An IActionResult.</returns>
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
