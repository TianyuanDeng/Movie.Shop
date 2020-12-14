using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class ReviewResponseModel
    {
        public int UserId { get; set; }
        public List<ReviewMovieResponseModel> MovieReviews { get; set; }


    }
    public class ReviewMovieResponseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public string Name { get; set; }
    }
}
