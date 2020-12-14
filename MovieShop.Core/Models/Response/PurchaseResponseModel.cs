using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class PurchaseResponseModel
    {
        public int UserId { get; set; }
        public List<PurchasedMovieResponseModel> PurchasedMovies { get; set; }
        public class PurchasedMovieResponseModel : MovieResponseModel
        {
            public DateTime PurchaseDateTime { get; set; }
        }
    }
}
