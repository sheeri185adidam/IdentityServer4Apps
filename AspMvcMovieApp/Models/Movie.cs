using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcMovieApp.Models
{
	/// <summary>
	/// A movie model
	/// </summary>
	public class Movie
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		/// <value>The release date.</value>
		[DataType(DataType.Date)]
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// Gets or sets the genre.
		/// </summary>
		/// <value>The genre.</value>
		public string Genre { get; set; }

		/// <summary>
		/// Gets or sets the price.
		/// </summary>
		/// <value>The price.</value>
		public decimal Price { get; set; }
	}
}
