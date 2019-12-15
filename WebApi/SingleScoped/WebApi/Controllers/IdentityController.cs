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
	[Authorize]
	public class IdentityController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
		}
	}
}