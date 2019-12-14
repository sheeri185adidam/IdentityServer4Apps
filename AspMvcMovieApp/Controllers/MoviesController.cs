using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspMvcMovieApp.Data;
using AspMvcMovieApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace AspMvcMovieApp.Controllers
{
    /// <summary>
    /// A controller for handling movies.
    /// </summary>
    /// <seealso cref="T:Microsoft.AspNetCore.Mvc.Controller"/>
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        /// <summary>
        /// Initializes a new instance of the AspMvcMovieApp.Controllers.MoviesController class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Movies.
        /// </summary>
        /// <returns>An asynchronous result that yields an IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        /// <summary>
        /// GET: Movies/Details/5.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An asynchronous result that yields an IActionResult.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

		/// <summary>
		/// GET: Movies/Create.
		/// </summary>
		/// <returns>An IActionResult.</returns>
		[Authorize("AdminPolicy")]
		public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Movies/Create To protect from overposting attacks, please enable the specific properties you want to bind to, for more details
        /// see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="movie">The movie.</param>
        /// <returns>An asynchronous result that yields an IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("AdminPolicy")]
		public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

		/// <summary>
		/// GET: Movies/Edit/5.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>An asynchronous result that yields an IActionResult.</returns>
		[Authorize("AdminPolicy")]
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        /// <summary>
        /// POST: Movies/Edit/5 To protect from overposting attacks, please enable the specific properties you want to bind to, for more details
        /// see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <exception cref="DbUpdateConcurrencyException">Thrown when a Database Update Concurrency error condition occurs.</exception>
        /// <param name="id">The identifier.</param>
        /// <param name="movie">The movie.</param>
        /// <returns>An asynchronous result that yields an IActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("AdminPolicy")]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

		/// <summary>
		/// GET: Movies/Delete/5.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>An asynchronous result that yields an IActionResult.</returns>
		[Authorize("AdminPolicy")]
		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        /// <summary>
        /// POST: Movies/Delete/5.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An asynchronous result that yields an IActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("AdminPolicy")]
		public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
