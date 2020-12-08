using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class FavoriteRequestModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
