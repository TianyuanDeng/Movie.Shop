using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class ReviewRequestModel
    {
        [Required]
        public int userId { get; set; }
        [Required]
        public int movieId { get; set; }
        public string reviewTest { get; set; }
        [Required]
        public double rating { get; set; }
    }
}
