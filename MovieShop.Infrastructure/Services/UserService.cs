using MovieShop.Core.Entities;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IPurchaseRepository _purchaseRepository;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService, IPurchaseRepository purchaseRepository)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _purchaseRepository = purchaseRepository;
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
                TotalPrice = purchaseRequest.totalPrice,
                PurchaseDateTime = purchaseRequest.purchaseDateTime,
                MovieId = purchaseRequest.movieId
            };

            //var createdPurchased = await _purchaseRepository.AddAsync(purchased);
            //Console.WriteLine("Success add purchased movies");
        }

        public Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            throw new NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
