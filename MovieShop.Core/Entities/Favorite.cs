using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
