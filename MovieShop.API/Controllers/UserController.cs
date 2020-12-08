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
                var p = _userService.PurchaseMovie(purchaseRequest);
                return Ok(purchaseRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> FavoriteMovie(FavoriteRequestModel favoriteRequest)
        {
            if (ModelState.IsValid)
            {
                var f = _userService.AddFavorite(favoriteRequest);
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
                await _userService.RemoveFavorite(favoriteRequest);
                return Ok(favoriteRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }


        [HttpGet]
        [Route("{id}/movie/{movieId}/favorite")]
        public async Task<IActionResult> FavoriteOrNot(int id, int movieId)
        {
       
            if (await _userService.FavoriteExists(id, movieId))
            {
                return Ok("It's favorite movie");
            }else
            {
                return Ok("It's not favorite movie");
            }
        }


        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> AddMovieReview(ReviewRequestModel reviewRequest)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddMovieReview(reviewRequest);
                return Ok(reviewRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview(ReviewRequestModel reviewRequest)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateMovieReview(reviewRequest);
                return Ok(reviewRequest);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }

        [HttpDelete]
        [Route("{userId}/movie/{movieId}")]
        public async Task<IActionResult> DeleteMovie(int userId, int movieId)
        {
            if (ModelState.IsValid)
            {
                await _userService.DeleteMovieReview(userId, movieId);
                return Ok("Successful deleted");
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
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
