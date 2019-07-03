using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using MovieZone.Dtos;
using MovieZone.Models;

namespace MovieZone.Controllers.API
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.Select(Mapper.Map<Movie, MovieDto>).ToList();

            return Ok(movies);
        }
        
        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/movies
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/1
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieToUpdate = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieToUpdate==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieToUpdate);
            _context.SaveChanges();
        }
        
        //Delete /api/movies/1
        public void DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieToDelete==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

        }

    }
}
