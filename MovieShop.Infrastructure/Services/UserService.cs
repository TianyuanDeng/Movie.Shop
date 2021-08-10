using MovieShop.Core.Entities;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MovieShop.Core.Models.Response.PurchaseResponseModel;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMovieRepository _repository;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService, 
            IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository ,
            IReviewRepository reviewRepository, IMovieRepository repository)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
            _repository = repository;
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            // we are gonna check if the email exists in the database
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return null; //some one try to login without register

            var hashedPassword = _cryptoService.HashPassword(password, user.Salt);
            var isSuccess = user.HashedPassword == hashedPassword;

            var response = new UserLoginResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth
            };

            if (isSuccess)
                return response;
            else
                return null;

            //return isSuccess ? response : null;
        }

        public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel) 
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
         
            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");

            var salt = _cryptoService.CreateSalt();

            var hashedPassword = _cryptoService.HashPassword(requestModel.Password, salt);
            var user = new User
            {
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName
            };

            //Save the new User to db
            var createdUser = await _userRepository.AddAsync(user);

            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            //var response = _mapper.Map<>();
            return response;
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var dbUser = await _userRepository.GetByIdAsync(id);

            var response = new UserRegisterResponseModel
            {
                Id = dbUser.Id,
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName
            };

            return response;
        }

        public async Task PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            var purchased = new Purchase
            {
                UserId = purchaseRequest.userId,
                PurchaseNumber = purchaseRequest.purchaseNumber,
                TotalPrice = (decimal)purchaseRequest.totalPrice,
                PurchaseDateTime = purchaseRequest.purchaseDateTime,
                MovieId = purchaseRequest.movieId
            };

            var createdPurchased = await _purchaseRepository.AddAsync(purchased);
            Console.WriteLine("Success add purchased movies");
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var favor = new Favorite
            {
                MovieId = favoriteRequest.MovieId,
                UserId = favoriteRequest.UserId
            };

            var createFavorite = await _favoriteRepository.AddAsync(favor);
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            var favorite = await _favoriteRepository.ListAsync(f => f.MovieId == favoriteRequest.MovieId 
            && f.UserId == favoriteRequest.UserId);

            await _favoriteRepository.DeleteAsync(favorite.First());
        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            var res = await _favoriteRepository.GetExistsAsync(f => f.MovieId == movieId && f.UserId == id);
            return res;
        }

        public Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            throw new NotImplementedException();
        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new ReviewRequestModel
            {
                userId = reviewRequest.userId,
                movieId = reviewRequest.movieId,
                reviewTest = reviewRequest.reviewTest,
                rating = reviewRequest.rating
            };

            var rev = new Review
            {
                UserId = reviewRequest.userId,
                MovieId = reviewRequest.movieId,
                Rating = (decimal?)reviewRequest.rating,
                ReviewText = reviewRequest.reviewTest
            };


            await _reviewRepository.AddAsync(rev);
        }

        public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            var rev = new Review
            {
                UserId = reviewRequest.userId,
                MovieId = reviewRequest.movieId,
                Rating = (decimal?)reviewRequest.rating,
                ReviewText = reviewRequest.reviewTest
            };

            await _reviewRepository.UpdateAsync(rev);
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var rev = new Review
            {
                UserId = userId,
                MovieId = movieId,
            };

            await _reviewRepository.DeleteAsync(rev);
        }

        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            var res = await _purchaseRepository.GetAllPurchaseById(id);
            var model = new PurchaseResponseModel();

            var list = new List<PurchasedMovieResponseModel>();

            //foreach (var i in res)
            //{
            //    list.Add(new PurchasedMovieResponseModel
            //    {
            //        PurchaseDateTime = res.PurchaseDateTime
            //    }) ;
            //}
             

            return model;
        }

        public Task<ReviewResponseModel> GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
    }
}
