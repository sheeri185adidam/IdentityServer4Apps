using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcMovieApp.Models
{
	/// <summary>
	/// A data Model for the login.
	/// </summary>
	public class LoginModel
	{
		/// <summary>
		/// Gets or sets URL of the return.
		/// </summary>
		/// <value>The return URL.</value>
		public string ReturnUrl { get; set; }

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password { get; set; }
	}
}
