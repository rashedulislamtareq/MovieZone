using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
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
            var movies = _context.Movies.ToList();

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
    }
}