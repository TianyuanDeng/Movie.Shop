using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public decimal? Rating { get; set; }

        public ICollection<Trailer> Trailers{ get; set;}
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
        public ICollection<MovieCrew> MovieCrews { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
