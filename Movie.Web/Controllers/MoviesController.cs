using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Web.Controllers
{
    public class MoviesController : Controller
    {
        public string Index()
        {
            return "This is Index action should return top 20  moives";
        }

        public string MovieByGener(int genreId) {
            return "This is MovieByGener";     
        }

        public string Deatils(int movieId) 
        {
            return "This is Deatils";
        }
    }
}
