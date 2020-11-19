using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    //One movie can have multiple trailers 
    public class Trailer
    {
        public int Id { get; set; }
        
        //foreign key from Movie table which is Id AS pk there
        public int MovieId { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        //Navigation Properties, help is navigate to related entities 
        //trailerid 24 => get me Movie Title and Movie Overview
        public Movie Movie { get; set; }
    }
}
