using System;

namespace AspMvcMovieApp.Models
{
	/// <summary>
	/// A ViewModel for the error.
	/// </summary>
	public class ErrorViewModel
	{
		/// <summary>
		/// Gets or sets the identifier of the request.
		/// </summary>
		/// <value>The identifier of the request.</value>
		public string RequestId { get; set; }

		/// <summary>
		/// Gets a value indicating whether the request identifier is shown.
		/// </summary>
		/// <value>True if show request identifier, false if not.</value>
		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}
