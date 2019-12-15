using AspMvcMovieApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspMvcMovieApp.Data
{
	/// <summary>
	/// A movie context.
	/// </summary>
	/// <seealso cref="T:Microsoft.EntityFrameworkCore.DbContext"/>
	public class MovieContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the AspMvcMovieApp.Data.MovieContext class.
		/// </summary>
		/// <param name="options">Options for controlling the operation.</param>
		public MovieContext(DbContextOptions<MovieContext> options)
			: base(options)
		{
		}

		/// <summary>
		/// Gets or sets the movie.
		/// </summary>
		/// <value>The movie.</value>
		public DbSet<Movie> Movie { get; set; }
	}
}
