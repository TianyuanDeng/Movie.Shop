using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreatMovie([FromBody] MovieCreateRequest movieCreateRequest)
        {
            var createdMovie = await _movieService.CreateMovie(movieCreateRequest);
            return CreatedAtRoute("GetMovie", new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut]
        [Route("movie")]
        public async Task<IActionResult> UpdateMovie()
        {
            return Ok();
        }

        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetAllPurchased()
        {
            return Ok();
        }

        [HttpGet]
        [Route("top")]
        public async Task<IActionResult> GetTopMostPurchased()
        {
            return Ok();
        }
    }
}
