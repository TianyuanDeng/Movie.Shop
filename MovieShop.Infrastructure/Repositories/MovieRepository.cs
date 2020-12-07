using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MovieShop.Infrastructure.Data;
using MovieShop.Core.RepositoryInterfaces;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Models.Response;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            var reviews = await _dbContext.Reviews.OrderByDescending(r => r.Rating).Take(20).ToListAsync();
            var movies = new List<MovieResponseModel>();
            foreach (var review in reviews)
            {
                var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == review.MovieId);

                movies.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });
            }

            return movies;
        }

        public async Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            var genre = _dbContext.MovieGenres.Where(g => g.GenreId == genreId).ToList();
            var movies = new List<MovieResponseModel>();
            foreach (var gen in genre)
            {
                var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == gen.MovieId);

                movies.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });
            }

            return movies;
        }

        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(50).ToListAsync();
            //skip and take need to know 
            //offset 10 and fetch 50 next rows
            return movies;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }
    }
}
