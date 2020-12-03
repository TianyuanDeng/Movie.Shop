using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class FavoriteRequestModel
    {
        [Required]
        public int userId { get; set; }
        [Required]
        public int movieId { get; set; }
    }
}
