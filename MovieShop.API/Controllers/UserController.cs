using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PurchaseMovie()
        {
            return Ok();
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> favoriteMovie()
        {
            return Ok();
        }


        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> unfavoriteMovie()
        {
            return Ok();
        }


        [HttpGet]
        [Route("{id}/movie/{movieId}/faavorite")]
        public async Task<IActionResult> favoriteOrNot()
        {
            return Ok();
        }


        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> reviewMovie()
        {
            return Ok();
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> updateReview()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{userId}/movie/{movieId}")]
        public async Task<IActionResult> deleteMovie()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/purchases")]
        public async Task<IActionResult> GetAllPurchased()
        {
            return Ok();
        }


        [HttpGet]
        [Route("{id}/favorites")]
        public async Task<IActionResult> GetAllFavorite()
        {
            return Ok();
        }


        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            return Ok();
        }
    }
}
