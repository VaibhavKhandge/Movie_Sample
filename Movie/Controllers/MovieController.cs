using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController
    {
        private readonly MovieDBContext _context;
        public MovieController(MovieDBContext movieDBContext)
        {
            _context = movieDBContext;
        }

        [HttpGet]
        public MovieResponse Details(string genere)
        {
            MovieResponse movieResponse = new MovieResponse();
            if (genere == null)
            {
                movieResponse.Message = "Genere can not be empty!";
                return movieResponse;
            }

            List<Movie> _movie = new List<Movie>();
            _movie = _context.Movie
                .Where(m => m.Genre.ToLower() == genere.ToLower()).ToList();

            if (_movie != null && _movie.Count > 0)
            {
                movieResponse.Movies = _movie;
                movieResponse.Message = "Movie fetch sucessfully!";
            }
            else
            {
                movieResponse.Message = "Movies not found!";
            }
            return movieResponse;
        }
    }
}
