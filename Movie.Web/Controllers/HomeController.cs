using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.Web.Models;
using MovieShop.Core.ServiceInterfaces;

namespace Movie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetTopRevenueMovies();
            return View(movies);

            //var testdata = "List of Movies";
            //ViewBag.myproperty = testdata;
            //return View();
            //if you wanna send some extra information along with the actual object then viewbag and viewdata are useful. 

            //By default where you do return View its gonna return View with Same name as action method
            //name inside the View folder of that controller name folder 

            //HttpContext in ASP.NET Core and ASP.NET which will provide you with all the information regarding your http request

            //Controller will call services ==> will call Repositories\

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
