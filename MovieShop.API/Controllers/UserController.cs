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
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            if (ModelState.IsValid)
            {
                return Ok(purchaseRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> favoriteMovie(FavoriteRequestModel favoriteRequest)
        {
            if (ModelState.IsValid)
            {
                return Ok(favoriteRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }


        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> unfavoriteMovie(FavoriteRequestModel favoriteRequest)
        {
            if (ModelState.IsValid)
            {
                return Ok(favoriteRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
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
