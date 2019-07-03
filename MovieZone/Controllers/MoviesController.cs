using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using MovieZone.Models;
using MovieZone.Models.ViewModels;

namespace MovieZone.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList();

            return View(movies);
        }

        public ActionResult Random()
        {
            var viewModel = new RandomMovieViewModel()
            {
                Movie = _context.Movies.FirstOrDefault(),
                Customers = _context.Customers.ToList()
            };
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieFormViewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", movieFormViewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToUpdate = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);
                if (movieToUpdate!=null)
                {
                    movieToUpdate.Name = movie.Name;
                    movieToUpdate.GenreId = movie.GenreId;
                    movieToUpdate.NumberInStock = movie.NumberInStock;
                    movieToUpdate.ReleaseDate = movie.ReleaseDate;
                    movieToUpdate.DateAdded = movie.DateAdded;
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Details", new {Id = movie.Id});
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(x=>x.Genre).FirstOrDefault(x => x.Id == id);
            if (movie==null)
            {
                return HttpNotFound();
            }
            var movieFormViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieFormViewModel);
        }
    }
}