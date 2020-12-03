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
    public class AdminController : ControllerBase
    {
        [HttpPost]
        [Route("movie")]
        public async Task<IActionResult> CreatMovie()
        {
            return Ok();
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
