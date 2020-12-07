using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieResponseModel>> GetTopRevenueMovies();
        Task<MovieResponseModel> GetMoveById(int id);
        Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies();

        //Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "");
        //Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0);
        //Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId);
        //Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        //Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id);
        //Task<int> GetMoviesCount(string title = "");
        //Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies();
        Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId);
        //Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest);
        //Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest);
    }
}
