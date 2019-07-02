using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            var movies = _context.Movies.Include(x=>x.Genre).ToList();

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

            if (movie==null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}