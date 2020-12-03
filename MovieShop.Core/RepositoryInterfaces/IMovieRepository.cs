using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    //3 methods + 8 methods: how many class should be implement
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
        Task<IEnumerable<Movie>> GetHighestRevenueMovies();
        Task<Movie> GetMovieById(int id);
    }
}
