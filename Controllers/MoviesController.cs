using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.Models.ViewModels;
namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");

            }
            return View("ReadOnlyList");
        }
        public ViewResult Details(int? id)
        {
            var movie = _context.Movies.Include(c=>c.Genre).FirstOrDefault(c => c.Id == id);

            return View(movie);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult NewMovie()
        {
            MovieFormViewModel movieVM = new MovieFormViewModel
            {
                
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm",movieVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                  
                    Genres = _context.Genres.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (movie.Id == 0)
            {
                
                 movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
  
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);

        }

    }
}
