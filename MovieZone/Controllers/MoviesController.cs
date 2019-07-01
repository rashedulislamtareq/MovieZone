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

        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie(){ Id = 1, Name = "Titanic"},
                new Movie(){ Id = 2, Name = "Dark"}
            };

            return View(movies);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Titanic" };
            var customers = new List<Customer>()
            {
                new Customer(){ Id = 1, Name = "Customer 1"},
                new Customer(){ Id = 2, Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
    }
}