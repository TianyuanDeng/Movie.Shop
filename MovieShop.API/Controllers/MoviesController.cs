using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    //Attribute base Routing
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindMovieById(int id)
        {
            var movie = await _movieService.GetMoveById(id);

            if (movie == null)
            {
                return NotFound("No Movies Found");
            }

            return Ok(movie);
        }

        //api/movies/toprevenue 
        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        { 
            //call our serrvice and all the method

            var movies = await _movieService.GetTopRevenueMovies();
            
            if (!movies.Any())
            {
                return NotFound("No Movies Found");
            }

            return Ok(movies);
        }

        [HttpGet]
        [Route("genre/{genreId}")]
        public async Task<IActionResult> GetGenre()
        {
            return Ok();
        }
    }
}
