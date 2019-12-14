using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiApp.Controllers
{
	/// <summary>
	/// A controller for handling identities.
	/// </summary>
	/// <seealso cref="T:Microsoft.AspNetCore.Mvc.ControllerBase"/>
    [Route("identity")]
	[Authorize("AdminPolicy")]
	public class IdentityController : ControllerBase
	{
		private readonly IAuthorizationService _authService;

		/// <summary>
		/// Initializes a new instance of the WebApiApp.Controllers.IdentityController class.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
		/// <param name="authService">The authentication service.</param>
		//public IdentityController(IAuthorizationService authService)
		//{
		//	_authService = authService ?? throw new ArgumentNullException(nameof(authService));
		//}

		//[HttpGet]
		//   public async Task<IActionResult> Get()
		//   {
		//    var result = await _authService.AuthorizeAsync(User, "AdminPolicy");
		//    if (result.Succeeded)
		//    {
		//	    return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
		//	}

		//    return Forbid();
		//   }
		//   
		[HttpGet]
		public IActionResult Get()
		{
			return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
		}
	}
}