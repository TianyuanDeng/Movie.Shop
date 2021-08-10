using MovieShop.Core.Entities;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserLoginResponseModel> ValidateUser(string email, string password);
        Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel);
        Task<UserRegisterResponseModel> GetUserDetails(int id);
        Task PurchaseMovie(PurchaseRequestModel purchaseRequest);
        Task AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task<bool> FavoriteExists(int id, int movieId);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest);
        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);

        Task<PurchaseResponseModel> GetAllPurchasesForUser(int id);
        Task<ReviewResponseModel> GetAllReviewsByUser(int id);
        Task<FavoriteResponseModel> GetAllFavoritesForUser(int id);
        Task<User> GetUser(string email);
        //Task<PagedResultSet<User>> GetAllUsersByPagination(int pageSize = 20, int page = 0, string lastName = "");
    }
}
